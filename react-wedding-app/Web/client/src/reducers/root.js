import { combineReducers } from "redux";
import auth from "./auth";
import message from "./message";
import images from "./images";
import participants from './participants';

const rootReducer = combineReducers({
  auth,
  message,
  images,
  participants
});

export default rootReducer;
