import { successAction, failureAction } from "../types";
import axios from "axios";

export function get() {
  return dispatch =>
    axios
      .get("")
      .then(data => dispatch({ type: successAction(SAME_DATA), data }))
      .catch(err => dispatch({ type: failureAction(SAME_DATA), err }));

}

