import * as Yup from "yup";

export const LogInSchema = Yup.object().shape({
  email: Yup.string().email().required("Email is required"),
  password: Yup.string()
    .required("Password is required")
    .min(8, "Password is too short, must be atleast 8 characters")
});

export const RegisterSchema = Yup.object().shape({
  username: Yup.string()
    .required("Username is required"),
  email: Yup.string().email().required("Email is required"),
  password: Yup.string()
    .required("Password is required")
    .min(8, "Password is too short, must be atleast 8 characters")
});