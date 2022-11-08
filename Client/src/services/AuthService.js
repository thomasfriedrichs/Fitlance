import axios from "axios";

import { setAuthToken } from "../common/SetAxiosHeaderToken";
import BaseUrl from "./ApiRoutes";

const API_EXT = "Auth/";

  export const login = (email, password, setToken) => {
    return axios
      .post(BaseUrl + API_EXT + "login", {
        email,
        password
      })
      .then(response => {
        if (response.data.accessToken) {
          setToken(JSON.stringify(response.data));
          setAuthToken(JSON.stringify(response.data));
          window.location.href = "/";
        }
        return response.data;
      })
      .catch(console.error());
  };

  export const logout = (setToken) => {
    setToken(null);
  };

  export const register = (username, email, password, role, setToken) => {
    return axios.post(BaseUrl + API_EXT + "register", {
      username,
      email,
      password,
      role
    }).then(response => {
      if (response.data.accessToken) {
        setToken(JSON.stringify(response.data));
        setAuthToken(JSON.stringify(response.data));
        window.location.href = "/";
      }
      return response.data;
    })
    .catch(console.error());
  };

  export const getCurrentUser = () => {
    return JSON.parse(localStorage.getItem('user'));
  };   