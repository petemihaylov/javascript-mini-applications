import ImageService from "../services/image.service";

import { ADD_IMAGE, DELETE_IMAGE, FETCH_IMAGES } from "./types";


export const fetchImages = () => (dispatch) => {

  console.log('fetch images')
  ImageService.getImages().then(
    (response) => {
      dispatch({
        type: FETCH_IMAGES,
        payload: response,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};

export const createImage = (url) => (dispatch) => {
  ImageService.addImage(url).then(
    (response) => {
      dispatch({
        type: ADD_IMAGE,
        payload:  response,
      });
    },
    (error) => {
      console.log(error);
    }
  );
}

export const deleteImage = (id, index) => (dispatch) => {
  ImageService.deleteImage(id).then(
    (response) => {
      dispatch({
        type: DELETE_IMAGE,
        payload: index,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};