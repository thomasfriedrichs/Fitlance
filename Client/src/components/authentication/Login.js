import React from "react";
import { Formik } from "formik";

import { LogInSchema } from "../../validators/Validate";
import { useAuth } from "../../context/AuthContext";

const Login = () => {
  const { onLogin } = useAuth();

  const initialValues = {
    email: "",
    password: ""
  };

  const handleLogin = (values) => {
      onLogin(values.email, values.password);
      console.log(values.email, values.password);
  };

  return (
    <Formik
      initialValues={initialValues}
      validationSchema={LogInSchema}
      onSubmit={handleLogin}
    >
      {(formik) => {
        const {
          values,
          handleChange,
          handleSubmit,
          errors,
          touched,
          handleBlur,
          isValid,
          dirty
        } = formik;

        return (
          <div className="flex flex-col gap-y-4">
            <h1 className="text-3xl text-center">Log in to continue</h1>
            <form onSubmit={handleSubmit}>
              <div className="my-4">
                <div className="w-full">
                  <input
                    type="email"
                    name="email"
                    placeholder="Email"
                    value={values.email}
                    onChange={handleChange}
                    onBlur={handleBlur}
                    className={`border w-full rounded-full text-center p-2
                      ${errors.email && touched.email ? "border-red-500" : "border-lime-500"}
                    `}
                  />
                </div>
                {errors.email && touched.email && (
                  <span className="text-red-500">{errors.email}</span>
                )}
              </div>
              <div >
                <div className="w-full"> 
                  <input
                    type="password"
                    name="password"
                    placeholder="Password"
                    value={values.password}
                    onChange={handleChange}
                    onBlur={handleBlur}
                    className={`border w-full rounded-full text-center p-2
                      ${errors.password && touched.password ? "border-red-500" : "border-lime-500"}
                    `}
                  />
                  {errors.password && touched.password && (
                    <span className="text-red-500">{errors.password}</span>
                  )}
                </div>
              </div>
              <div className="flex justify-center">
                <button
                  type="submit"
                  className={`my-4 w-[8rem] h-[2rem] border rounded-full ${!(dirty && isValid) ? "" : "bg-green"}`}
                  disabled={!(dirty && isValid)}
                >
                  Log In
                </button>
              </div>
            </form>
          </div>
        );
      }}
    </Formik>
  );
};

export default Login; 