import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";

import { setAxiosHeaderToken } from "../services/SetAxiosHeaderToken";

const AuthContext = React.createContext();

export const useAuth = () => {
  return React.useContext(AuthContext);
};


const AuthContextProvider = ({children}) => {
  const [ token, setToken ] = useState();
  const [ role, setRole ] = useState("");
  const navigate = useNavigate();
  const [ isFormVisible, setIsFormVisible ] = useState(true);

  const onLogin = (email, password) => {
    return axios
      .post("api/Auth/login", {
        email,
        password
      })
      .then(response => {
        if (response.data.accessToken) {
          setToken(JSON.stringify(response.data));
          setAxiosHeaderToken(JSON.stringify(response.data));
          navigate("/home");
        }
        const jwt = JSON.stringify(response.data);
        const decoded = jwt_decode(jwt);
        setRole(decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
        return response.data;
      })
      .catch(console.error());
  };

  const onLogout = () => {
    setToken(null);
  };

  const onRegister = (username, email, password, role) => {
    return axios.post("api/Auth/register", {
      username,
      email,
      password,
      role
    }).then(response => {
      if (response.data.accessToken) {
        setToken(JSON.stringify(response.data));
        setAxiosHeaderToken(JSON.stringify(response.data));
        navigate("/home");
      }
      const jwt = JSON.stringify(response.data)
      const decoded = jwt_decode(jwt);
      setRole(decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
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
    setIsFormVisible,
    role
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