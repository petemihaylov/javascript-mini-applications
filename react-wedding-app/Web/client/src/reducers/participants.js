import { ADD_PARTICIPANT, DELETE_PARTICIPANT, FETCH_PARTICIPANTS } from "../actions/types";

const initialState = { items: [] };

export default function participants(state = initialState, action) {
  const { type, payload } = action;

  switch (type) {
    case ADD_PARTICIPANT:
      return {
        ...state,
        items: [...state.items, payload],
      };

    case DELETE_PARTICIPANT:
      return {
        ...state,
        items: state.items.filter((item, index) => index !== action.payload),
      };
    case FETCH_PARTICIPANTS:
      return {
        ...state,
        items: payload,
      };
    default:
      return state;
  }
}
