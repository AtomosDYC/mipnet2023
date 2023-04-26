import { PlantillaflujoResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  plantillaflujos: PlantillaflujoResponse[] | null;
  plantillaflujo: PlantillaflujoResponse | null;
  loading: boolean | null;
  error: string | null;
  success: boolean | null;
}

export const initialState: ListState = {
  plantillaflujos: null,
  plantillaflujo: null,
  loading: null,
  error: null,
  success: false,
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, plantillaflujos: action.plantillaflujos}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_PLANTILLAFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_PLANTILLAFLUJO_SUCCESS: {
        return {...state, loading: false, plantillaflujo: action.plantillaflujo}
      }

      case fromActions.Types.GET_PLANTILLAFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_PLANTILLAFLUJO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_PLANTILLAFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, plantillaflujo: action.plantillaflujo, success: false}
      }

      case fromActions.Types.CREATE_PLANTILLAFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

//actualizar
      case fromActions.Types.UPDATE_PLANTILLAFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_PLANTILLAFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, plantillaflujo: action.plantillaflujos}
      }

      case fromActions.Types.UPDATE_PLANTILLAFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_PLANTILLAFLUJO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_PLANTILLAFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, plantillafliujos: action.plantillaflujos, success: false}
      }

      case fromActions.Types.DELETE_PLANTILLAFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }



      case fromActions.Types.DESACTIVATE_PLANTILLAFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_PLANTILLAFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, plantillaflujos: action.plantillaflujos}
      }

      case fromActions.Types.DESACTIVATE_PLANTILLAFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_PLANTILLAFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_PLANTILLAFLUJO_SUCCESS: {

        return {...state, loading: false, error: null, plantillaflujos: action.plantillaflujos}
      }

      case fromActions.Types.ACTIVATE_PLANTILLAFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      default: {
        return state;
      }
    }


}
