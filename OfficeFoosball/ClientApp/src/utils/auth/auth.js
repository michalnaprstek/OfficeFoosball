import { axiosInstance, axiosWithoutInterceptors } from "../axiosInstance";

export class RefreshTokenResult {
  success;
  accessToken;
  constructor(success, accessToken) {
    if (success && !accessToken) {
      throw new Error('Refresh token result require token for success state.');
    }
    this.success = success;
    this.accessToken = accessToken;
  }
}

export default class Auth {
  login = async (username, password) => {
    const response = await axiosWithoutInterceptors.post('auth/login', { username: username, password: password },);

    const { data } = response;
    this.storeTokens(data.accessToken, data.refreshToken);
  };

  register = async (username, email, password, accessCode) => {
    try {
      await axiosWithoutInterceptors.post('auth/register', {
        username,
        email,
        password,
        accessCode
      }, { headers: { 'Content-Type': 'application/json' } });
      return { ok: true };
    } catch (error) {
      return { ok: false, errorMessage: error.response.data };
    }
  }

  isAuth = () => {
    const accessToken = localStorage.getItem('access_token');
    return accessToken ? true : false;
  }

  logout = () => {
    localStorage.removeItem("access_token");
    localStorage.removeItem("refresh_token");
    localStorage.clear();
  }

  getAccessCode = async () => {
    try{
      const response = await axiosInstance.get('auth/access-code');
      return response.data;
    } catch (error){
      console.error(`Loading access code failed: ${error.response.data}`);
    }
  }

  refreshToken = async () => {
    const refreshResponse = await axiosInstance.post('auth/token', {
      'refreshToken': localStorage.getItem('refresh_token')
    });

    if (refreshResponse.status === 201) {
      const { data } = refreshResponse;
      this.storeTokens(data.accessToken, data.refreshToken)
      return new RefreshTokenResult(true, data.accessToken);
    }

    return new RefreshTokenResult(false, undefined);
  }

  getToken = () => {
    return localStorage.getItem('access_token');
  }

  storeTokens(accessToken, refreshToken) {
    localStorage.setItem("access_token", accessToken);
    localStorage.setItem("refresh_token", refreshToken);
  }
}