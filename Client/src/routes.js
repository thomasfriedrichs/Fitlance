import React from "react";
import { Routes, Route } from "react-router-dom";

import Home from "./components/home/Home";
import NotFound from "./components/layout/NotFound";
import AuthWrapper from "./components/authentication/AuthWrapper";
import UserHome from "./components/user/UserHome";
import ProtectedRoute from "./components/authentication/ProtectedRoute";
import TrainerHome from "./components/trainer/TrainerHome";

const Routing = () => {
  return (
    <Routes>
      <Route
        index 
        element={<Home/>}
      />
      <Route
        exact
        path="home"
        element={<Home/>}
      />
      <Route
        path="client"
        element={
          <ProtectedRoute>
            <UserHome/>
          </ProtectedRoute>
        }
      />
      <Route
        path="trainer"
        element={
          <ProtectedRoute>
            <TrainerHome/>
          </ProtectedRoute>
        }
      />
      <Route
        path="login"
        element={<AuthWrapper/>}
      />
      <Route 
        to="*" 
        element={<NotFound/>}
      />
    </Routes>
  );
};

export default Routing;