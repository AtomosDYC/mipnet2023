import { TipoFlujoResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  tipoflujos: TipoFlujoResponse[] | null;
  tipoflujo: TipoFlujoResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  tipoflujos: null,
  tipoflujo: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, tipoflujos: action.tipoflujos}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TIPOFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TIPOFLUJO_SUCCESS: {
        return {...state, loading: false, tipoflujo: action.tipoflujo}
      }

      case fromActions.Types.GET_TIPOFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TIPOFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TIPOFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, tipoflujo: action.tipoflujo}
      }

      case fromActions.Types.CREATE_TIPOFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TIPOFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TIPOFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, tipoflujo: action.tipoflujos}
      }

      case fromActions.Types.UPDATE_TIPOFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TIPOFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TIPOFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, tipoflujos: action.tipoflujos}
      }

      case fromActions.Types.DELETE_TIPOFLUJO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TIPOFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TIPOFLUJO_SUCCESS: {
        return {...state, loading: false, error: null, tipoflujos: action.tipoflujos}
      }

      case fromActions.Types.DESACTIVATE_TIPOFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_TIPOFLUJO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TIPOFLUJO_SUCCESS: {

        return {...state, loading: false, error: null, tipoflujos: action.tipoflujos}
      }

      case fromActions.Types.ACTIVATE_TIPOFLUJO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
