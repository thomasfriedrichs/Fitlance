import React from "react";

const UserInfo = ({data}) => {
  const { firstName, lastName, zipCode, city, bio } = data;

  return (
    <section>
      <div className="flex flex-row mt-4">
        <div className="basis-1/4 h-full">
          <div className="border h-48">image</div>
        </div>
        <div className="basis-3/4 h-full text-left">
          <div className="py-6 px-12 text-2xl">
            {
              firstName === null || lastName === null ?
              <p className="text-red-400">Please update Name</p>
              : 
              <div>
                <p>{firstName}</p>
                <p>{lastName}</p>
              </div>
            }
          </div>
          <div className="py-6 px-12 text-2xl">
            {
              city === null ?
              <p className="text-red-400">Please update City</p>
              :
              <div>
                <p>{city}</p>
              </div>
            }
          </div>
          <div className="py-6 px-12 text-2xl">
            {
              zipCode === null ?
              <p className="text-red-400">Please update Zipcode</p>
              :
              <div>
                <p>{zipCode}</p>
              </div>
            }
          </div>
          <div className="py-6 px-12 text-2xl">
            {
              bio === null ?
              <p className="text-red-400">Please update Bio</p>
              :
              <div>
                <p>{bio}</p>
              </div>
            }
          </div>
        </div>
      </div>
    </section>
  );
};

export default UserInfo;