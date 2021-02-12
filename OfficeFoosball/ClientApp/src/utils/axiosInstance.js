import axios from 'axios';
import Auth from './auth/auth';

//TODO: Move const to enviroment variables
const axiosInstance = axios.create({
  baseURL: 'api',
  timeout: 5000,
  headers: {
    contentType: 'application/json'
  }
});

axiosInstance.interceptors.request.use(request => requestHandler(request));
axiosInstance.interceptors.response.use(
  response => responseHandler(response),
  error => errorHandler(error));

const requestHandler = request => {
  const accessToken = new Auth().getToken();
  if (accessToken) {
    request.headers["Authorization"] = `Bearer ${accessToken}`;
  }
  return request;
};

const errorHandler = async (error) =>  {
  const originalRequest = error.config;
  const auth = new Auth();
  if(!error.response){
    return Promise.reject(error);
  }
  if(error.response.status === 401 && originalRequest.url.endsWith('auth/token')){
    auth.logout();
    goTo('/login');
    return Promise.reject(error);
  }
  if(error.response.status === 403){
    goTo('/');
    return Promise.reject(error);
  }
  if((error.response.status === 401) && !originalRequest._retry){
    originalRequest._retry = true;
    const refreshResult = await auth.refreshToken();
    if(refreshResult.success){
      originalRequest.headers['Authorization'] = `Bearer ${refreshResult.accessToken}`;
      return axiosInstance(originalRequest);
    }
    auth.logout();
    goTo('/login');
    return Promise.reject(error);
  }
  return Promise.reject(error);
};

const responseHandler = response => response;

const goTo = (path) => {
  window.location.href = path;
}

export default axiosInstance;
