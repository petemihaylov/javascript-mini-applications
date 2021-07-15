import { ADD_IMAGE, DELETE_IMAGE, FETCH_IMAGES } from "../actions/types";

const initialState = { items: [] };

export default function images(state = initialState, action) {
  const { type, payload } = action;

  switch (type) {
    case ADD_IMAGE:
      return {
        ...state,
        items: [...state.items, payload],
      };

    case DELETE_IMAGE:
      return {
        ...state,
        items: state.items.filter((item, index) => index !== action.payload),
      };
    case FETCH_IMAGES:
      return {
        ...state,
        items: payload,
      };
    default:
      return state;
  }
}
