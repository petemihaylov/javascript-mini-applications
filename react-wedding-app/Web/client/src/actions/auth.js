import { LOGIN_SUCCESS, LOGIN_FAIL, SET_MESSAGE, LOGOUT } from './types';
import AuthService from '../services/auth.service';


export const login = (username, password) => (dispatch) => {
    console.log(username); 

    return AuthService.login(username, password).then(
      (response) => {
        dispatch({
          type: LOGIN_SUCCESS,
          payload: { user: response },
        });
  
        return Promise.resolve();
      },
      (error) => {
        const message =
          (error.response &&
            error.response.data &&
            error.response.data.message) ||
          error.message ||
          error.toString();
  
        dispatch({
          type: LOGIN_FAIL,
        });
  
        dispatch({
          type: SET_MESSAGE,
          payload: message,
        });
  
        return Promise.reject();
      }
    );
};

export const logout = () => (dispatch) => {
  dispatch({
    type: LOGOUT,
  });
  AuthService.logout();
};