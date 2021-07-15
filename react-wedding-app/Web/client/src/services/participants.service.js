import axios from "axios";
import authHeader from "./auth.header";

const { REACT_APP_API_URL } = process.env;

export default class ParticipantService {
  static addParticipant = async (participant) => {
    console.log(participant);
    return axios
      .post(REACT_APP_API_URL + "api/participants", participant)
      .then((response) => {
        return response.data;
      });
  };

  static deleteParticipant = async (id) => {
    return axios.delete(REACT_APP_API_URL + "api/participants/" + id, {
        headers: authHeader(),
      });
  }

  static getParticipant = async () => {
    return axios
      .get(REACT_APP_API_URL + "api/participants", {
        headers: authHeader(),
      })
      .then((response) => {
        return response.data;
      });
  };
}
