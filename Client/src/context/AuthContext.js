import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

import { setAxiosHeaderToken } from "../services/SetAxiosHeaderToken";
import { BaseUrl } from "../services/ApiRoutes";

const AuthContext = React.createContext();

export const useAuth = () => {
  return React.useContext(AuthContext);
};


const AuthContextProvider = ({children}) => {
  const [ token, setToken ] = useState();
  const API_EXTN = "Auth/";
  const navigate = useNavigate();
  const [ isFormVisible, setIsFormVisible ] = useState(true);


  const onLogin = (email, password) => {
    return axios
      .post(BaseUrl + API_EXTN + "login", {
        email,
        password
      })
      .then(response => {
        if (response.data.accessToken) {
          setToken(JSON.stringify(response.data));
          setAxiosHeaderToken(JSON.stringify(response.data));
          navigate("/home");
        }
        return response.data;
      })
      .catch(console.error());
  };

  const onLogout = () => {
    setToken(null);
  };

  const onRegister = (username, email, password) => {
    return axios.post(BaseUrl + API_EXTN + "register", {
      username,
      email,
      password
    }).then(response => {
      if (response.data.accessToken) {
        setToken(JSON.stringify(response.data));
        setAxiosHeaderToken(JSON.stringify(response.data));
        navigate("/home");
      }
      return response.data;
    })
    .catch(console.error());
  };

  const value = {
    token,
    onLogin,
    onLogout,
    onRegister,
    isFormVisible,
    setIsFormVisible
  };

  return (
    <AuthContext.Provider 
      value={value}
    >
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContextProvider;