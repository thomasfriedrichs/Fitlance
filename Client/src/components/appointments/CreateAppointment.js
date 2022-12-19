import React from "react";
import { Form, Formik } from "formik";
import Cookies  from "js-cookie";

import { AppointmentSchema } from "../../validators/Validate";
import { postAppointment } from "../../services/AppointmentService";

const CreateAppointment = (trainerId) => {
  const userId = Cookies.get("Id");
  const currentDate = new Date().toLocaleDateString();
  
  const initialValues = {
    clientId: userId,
    trainerId: trainerId.trainerId,
    adrress: "",
    createTime: currentDate,
    appointmentDate: "",
    isActive: true
  };

  return (
    <Formik
      initialValues={initialValues}
      validationSchema={AppointmentSchema}
      onSubmit={postAppointment}
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
              name="adrress"
              id="adrress"
              placeholder="Address/Location"
              value={values.adrress}
              onChange={handleChange}
              className={`border w-[95%] rounded-lg text-center p-1 m-2
              ${errors.adrress && touched.adrress ? "border-red-500" : "border-lime-500"}
            `}/>
            {errors.adrress && touched.adrress && (
            <span className="text-red-500">{errors.adrress}</span>
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
                className={`my-4 w-1/4 border rounded-full ${!(dirty && isValid) ? "" : "bg-green"}`}
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

export default CreateAppointment;