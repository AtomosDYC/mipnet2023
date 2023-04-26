import { TipoPerComunicacionResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  tipopercomunicaciones: TipoPerComunicacionResponse[] | null;
  tipopercomunicacion: TipoPerComunicacionResponse | null;
  loading: boolean | null;
  error: string | null;
  success: boolean | null;
}

export const initialState: ListState = {
  tipopercomunicaciones: null,
  tipopercomunicacion: null,
  loading: null,
  error: null,
  success: null,
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, tipopercomunicaciones: action.tipopercomunicaciones}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TIPOPERCOMUNICACION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TIPOPERCOMUNICACION_SUCCESS: {
        return {...state, loading: false, tipopercomunicaciones: action.tipopercomunicaciones}
      }

      case fromActions.Types.GET_TIPOPERCOMUNICACION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TIPOPERCOMUNICACION: {
        return {...state, loading: true, error: null, success: false}
      }
      
      case fromActions.Types.CREATE_TIPOPERCOMUNICACION_SUCCESS: {
        return {...state, loading: false, error: null, tipopercomunicaciones: action.tipopercomunicaciones, success: action.success}
      }

      case fromActions.Types.CREATE_TIPOPERCOMUNICACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


//Eliminar
      case fromActions.Types.DELETE_TIPOPERCOMUNICACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_TIPOPERCOMUNICACION_SUCCESS: {
        return {...state, loading: false, error: null, tipopercomunicaciones: action.tipopercomunicaciones, success: true}
      }

      case fromActions.Types.DELETE_TIPOPERCOMUNICACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


      default: {
        return state;
      }
    }


}
