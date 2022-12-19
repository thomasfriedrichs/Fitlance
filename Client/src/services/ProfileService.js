import axios from "axios";
import Cookies from "js-cookie";

export const fetchProfile = async () => {
  const token = Cookies.get("X-Access-Token");
  const id = Cookies.get("Id");
  try {
    const response = await axios
      .get(`/api/Users/${id}`, { headers: { authorization: `bearer ${token}`}});
    return response.data;
  } catch (err) {
    console.log(err);
  };
};

export const putProfile = async (reqObj) => {
  const token = Cookies.get("X-Access-Token");
  const id = Cookies.get("Id");
  try {
    axios.put(`/api/Users/${id}`, reqObj ,  { headers: { authorization: `bearer ${token}`}})
  } catch(err) {
    console.log(err)
  };
};