import axios from "axios";
import Cookies from "js-cookie";

export const postAppointment = async (reqObj) => {
  const token = Cookies.get("X-Access-Token");
  try {
    axios.post("api/Appointments", reqObj, { headers: { authorization: `bearer ${token}`}});
  } catch(err) {
    console.log(err)
  }
};