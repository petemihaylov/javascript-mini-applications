

import ParticipantService from "../services/participants.service";
import { ADD_PARTICIPANT, DELETE_PARTICIPANT, FETCH_PARTICIPANTS } from "./types";


export const fetchParticipants = () => (dispatch) => {

  console.log('fetch images')
  ParticipantService.getParticipant().then(
    (response) => {
      dispatch({
        type: FETCH_PARTICIPANTS,
        payload: response,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};

export const createParticipants = (participant) => (dispatch) => {
  ParticipantService.addParticipant(participant).then(
    (response) => {
      dispatch({
        type: ADD_PARTICIPANT,
        payload:  response,
      });
    },
    (error) => {
      console.log(error);
    }
  );
}

export const deleteParticipants = (id, index) => (dispatch) => {
  ParticipantService.deleteParticipant(id).then(
    (response) => {
      dispatch({
        type: DELETE_PARTICIPANT,
        payload: index,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};