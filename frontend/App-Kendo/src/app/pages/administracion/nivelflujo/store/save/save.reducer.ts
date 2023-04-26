import { NivelFlujoResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  nivelflujos: NivelFlujoResponse[] | null;
  nivelflujo: NivelFlujoResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  nivelflujos: null,
  nivelflujo: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, nivelflujos: action.nivelflujos}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_NIVELFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_NIVELFLUJO_SUCCESS: {
        return {...state, loading: false, nivelflujo: action.nivelflujo}
      }

      case fromActions.Types.GET_NIVELFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_NIVELFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_NIVELFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, nivelflujo: action.nivelflujo}
      }

      case fromActions.Types.CREATE_NIVELFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_NIVELFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_NIVELFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, nivelflujo: action.nivelflujos}
      }

      case fromActions.Types.UPDATE_NIVELFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_NIVELFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_NIVELFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, nivelflujos: action.nivelflujos}
      }

      case fromActions.Types.DELETE_NIVELFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_NIVELFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_NIVELFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, nivelflujos: action.nivelflujos}
      }

      case fromActions.Types.DESACTIVATE_NIVELFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_NIVELFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_NIVELFLUJO_SUCCESS: {

        return {...state, loading: false, error: null, nivelflujos: action.nivelflujos}
      }

      case fromActions.Types.ACTIVATE_NIVELFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
