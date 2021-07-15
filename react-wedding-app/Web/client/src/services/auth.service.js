import axios from "axios";

const { REACT_APP_API_URL } = process.env;

export default class AuthService {

  static login = async (username, password) => {
    console.log(username + " " + password);
    return axios
      .post(REACT_APP_API_URL + "api/account/authenticate", {
        username,
        password,
      })
      .then((response) => {
        if (response.data.accessToken) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }
        return response.data;
      });
  };

  static logout() {
    localStorage.removeItem("user");
  }
}
