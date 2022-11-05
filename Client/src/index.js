import React from "react";
import ReactDOM from "react-dom/client";
import reportWebVitals from "./reportWebVitals";
import { BrowserRouter } from "react-router-dom";

import './index.css';
import App from './App';
import { history } from './common/History';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter history={history}>
      <App/>
    </BrowserRouter>
  </React.StrictMode>
);

reportWebVitals();