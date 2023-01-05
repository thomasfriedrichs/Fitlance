import React from "react";
import { Form, Formik } from "formik";
import Cookies  from "js-cookie";

import { AppointmentSchema } from "../../validators/Validate";

const AppointmentForm = props => {
  const userId = Cookies.get("Id");
  const currentDate = new Date().toLocaleDateString();
  const { toggleView, query, reqType, trainerId, address, appointmentDate, id } = props;

  const initialValues = {
    clientId: userId,
    trainerId: trainerId,
    address: address === null ? "" : address,
    createTime: currentDate,
    appointmentDate: appointmentDate === null ? "" : appointmentDate,
    isActive: true
  };

  const onPut = (values) => {
    query(id, values);
    toggleView();
  };

  const onPost = (values) => {
    query(values)
    toggleView();
  };

  return (
    <Formik
      initialValues={initialValues}
      validationSchema={AppointmentSchema}
      onSubmit={reqType === "put" ? onPut : onPost}
      enableReinitialize={true}
    >
      {(formik) => {
        const {
          values,
          handleChange,
          handleSubmit,
          errors,
          touched,
          isValid,
          dirty
        } = formik;
        return(
          <Form
            onSubmit={handleSubmit}
            className="flex flex-col justify-center">
            <input
              type="text"
              name="address"
              id="address"
              placeholder="Address/Location"
              value={values.address}
              onChange={handleChange}
              className={`border w-[95%] rounded-lg text-center p-1 m-2
              ${errors.address && touched.address ? "border-red-500" : "border-lime-500"}
            `}/>
            {errors.address && touched.address && (
            <span className="text-red-500">{errors.address}</span>
            )}
            <input
              type="text"
              name="appointmentDate"
              id="appointmentDate"
              placeholder="MM/DD/YYYY"
              value={values.appointmentDate}
              onChange={handleChange}
              className={`border w-[95%] rounded-lg text-center p-1 m-2
              ${errors.appointmentDate && touched.appointmentDate ? "border-red-500" : "border-lime-500"}
            `}/>
            {errors.appointmentDate && touched.appointmentDate && (
            <span className="text-red-500 m-auto">{errors.appointmentDate}</span>
            )}
            <div className="flex flex-row justify-center">
              <button
                disabled={!(dirty && isValid)}
                type="submit"
                className={`my-4 w-1/2 md:w-1/4 border rounded-full ${!(dirty && isValid) ? "" : "bg-green"}`}
              >
                Make Appointment
              </button>
            </div>
          </Form>
        )
      }}
    </Formik>
  );
};

export default AppointmentForm;