import axios from "axios";

//TODO: Move const to enviroment variables
const axiosInstance = axios.create({
  baseURL: "api",
  timeout: 5000,
  headers: {
    contentType: "application/json"
  }
});

axiosInstance.interceptors.request.use(request => requestHandler(request));

const requestHandler = request => {
  const accessToken = localStorage.getItem("access_token");
  if (accessToken) {
    request.headers["Authorization"] = accessToken;
  }
  return request;
};

export default axiosInstance;
