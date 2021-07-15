import axios from "axios";
import Image from "../entities/Image";
import authHeader from "./auth.header";

const { REACT_APP_API_URL } = process.env;

export default class ImageService {
  static addImage = async (url) => {
    console.log(url);
    return axios
      .post(REACT_APP_API_URL + "api/image", new Image(url), {
        headers: authHeader(),
      })
      .then((response) => {
        return response.data;
      });
  };

  static deleteImage = async (id) => {
    return axios.delete(REACT_APP_API_URL + "api/image/" + id, {
        headers: authHeader(),
      });
  }

  static getImages = async () => {
    return axios
      .get(REACT_APP_API_URL + "api/image")
      .then((response) => {
        return response.data;
      });
  };
}
