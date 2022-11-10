import axios from "axios";
import Cookies from "js-cookie";
import jwt_decode from "jwt-decode";

import { setAxiosHeaderToken } from "../services/SetAxiosHeaderToken";

  export const login = (email, password) => {
    return axios
      .post("api/Auth/login", {
        email,
        password
      })
      .then(() => {
        const jwt = Cookies.get("X-Access-Token");
        setAxiosHeaderToken(jwt);
        const decoded = jwt_decode(jwt);
        Cookies.set("Email", decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"], { path: "/"});
        Cookies.set("Role", decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"], { path: "/"});
        window.location.href = "/";
      })
      .catch(console.error());
  };

  export const logout = () => {
    Cookies.remove("X-Access-Token");
    Cookies.remove("Role");
    Cookies.remove("Email");

  };

  export const register = (username, email, password, role) => {
    return axios.post("api/Auth/login", {
      username,
      email,
      password,
      role
    }).then(() => {
      const jwt = Cookies.get("X-Access-Token");
        setAxiosHeaderToken(jwt);
        const decoded = jwt_decode(jwt);
        Cookies.set("Email", decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"], { path: "/"});
        Cookies.set("Role", decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"], { path: "/"});
        window.location.href = "/";
    })
    .catch(console.error());
  };