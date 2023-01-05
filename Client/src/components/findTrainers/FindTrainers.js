import React, { useState } from "react";
import { useQuery } from "@tanstack/react-query";

import { fetchTrainers } from "../../services/TrainerService";
import { postAppointment } from "../../services/AppointmentService";
import AppointmentForm from "../appointments/AppointmentForm";
import images from './../../assets/profileImages/index';

const FindTrainers = () => {
  const { data, isLoading, isError, error } = useQuery(["findTrainers"], fetchTrainers);
  const [ appointmentFormView, setAppointmentFormView ] = useState(false);

  const toggleDropdownForm = () => {
    setAppointmentFormView(!appointmentFormView);
  };

  if (isLoading) {
    return <span>Loading...</span>
  };

  if (isError) {
    return <span className="mt-32">Error: {error.message}</span>
  };

  return (
    <div className="flex justify-center">
      <div className="mt-8 md:mt-12 mb-20 p-4 md:p-8 w-full md:w-[80vw] h-full">
        <div className="border-b-2 flex justify-start">
          <h1 className="text-4xl">
            Find Trainers
          </h1>
        </div>
        <div className="mt-10">
          {data.map((trainer, i) => {
            const { bio, firstName, lastName, city, zipCode, id } = trainer;
            const imageIndex = Math.floor(Math.random() * 4)
            return(
              <div key={i} className={`relative border rounded-sm md:m-4 flex flex-col md:flex-row 
                ${appointmentFormView ? "h-80 md:h-64" : "h-48 md:h-32"}`}>
                <div className="flex flex-row">
                  <div className="p-2 h-24 w-24">
                    <img
                      className="object-cover h-24 w-24"
                      src={images[imageIndex].image}
                      alt={images[imageIndex].alt}/>
                  </div>
                  <div className="flex flex-col md:flex-row md:justify-between w-2/3">
                    <div className="flex flex-row h-4">
                      <h1 className="p-2 font-semibold">{firstName}</h1>
                      <h1 className="p-2 font-semibold">{lastName}</h1>
                    </div>
                    <div className="flex flex-row mr-1 md:mr-6">
                      <p className="p-2 font-semibold">{city}</p>
                      <p className="p-2 font-semibold">{zipCode}</p>
                    </div>
                    <div>
                      <p className="p-2">{bio}</p>
                    </div>
                  </div>
                </div>
                <section>
                  {appointmentFormView ?
                    <AppointmentForm
                      toggleView={toggleDropdownForm}
                      query={postAppointment}
                      reqType={"post"}
                      trainerId={id}/>
                  : null}
                </section>
                <button 
                  onClick={toggleDropdownForm}
                  className="absolute bottom-0 right-0 p-2">
                  {appointmentFormView ? "Cancel" : "Make Appointment"} 
                </button>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default FindTrainers;