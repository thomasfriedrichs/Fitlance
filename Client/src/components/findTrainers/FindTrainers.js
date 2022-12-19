import React, { useState } from "react";
import { useQuery } from "@tanstack/react-query";

import { fetchTrainers } from "../../services/TrainerService";
import CreateAppointment from "../appointments/CreateAppointment";

const FindTrainers = () => {
  const { data, isLoading, isError, error } = useQuery(["profile"], fetchTrainers);
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
      <div className="mt-8 md:mt-12 mb-20 p-8 w-full md:w-[80vw] h-[100vh] border-x">
        <div className="border-b-2 flex justify-start">
          <h1 className="text-4xl">
            Find Trainers
          </h1>
        </div>
        <div className="border mt-10 rounded-sm">
          {data.map((trainer, i) => {
            const { bio, firstName, lastName, city, zipCode, id } = trainer;
            return(
              <div key={i} className={`relative ${appointmentFormView ? "h-64" : "h-32"}`}>
                <div className="flex flex-row justify-between">
                  <div className="flex flex-row">
                    <h1 className="p-2 font-semibold">{firstName}</h1>
                    <h1 className="p-2 font-semibold">{lastName}</h1>
                  </div>
                  <div className="flex flex-row mr-6">
                    <p className="p-2 font-semibold">{city}</p>
                    <p className="p-2 font-semibold">{zipCode}</p>
                  </div>
                </div>
                <p className="p-2">{bio}</p>
                {appointmentFormView ?
                  <CreateAppointment trainerId={id}/>
                : null}
                <button 
                  onClick={toggleDropdownForm}
                  className="absolute bottom-0 left-0 p-2">
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