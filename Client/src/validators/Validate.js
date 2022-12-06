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

export const ProfileSchema = Yup.object().shape({
  firstName: Yup.string().required("First name required"),
  lastName: Yup.string().required("Last name required"),
  city: Yup.string().required("City required"),
  zipcode: Yup.number().required("Zipcode required"),
  bio: Yup.string().required("Bio required")
})