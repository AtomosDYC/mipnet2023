import { ComunaResponse } from './save.models';
import * as fromActions from './save.actions';



export interface ListState {
  comunas: ComunaResponse[] | null;
  comuna: ComunaResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  comunas: null,
  comuna: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, comunas: action.comunas}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_COMUNA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_COMUNA_SUCCESS: {
        return {...state, loading: false, comuna: action.comuna}
      }

      case fromActions.Types.GET_COMUNA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_COMUNA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_COMUNA_SUCCESS: {
        return {...state, loading: false, error: null, comuna: action.comuna}
      }

      case fromActions.Types.CREATE_COMUNA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_COMUNA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_COMUNA_SUCCESS: {
        return {...state, loading: false, error: null, comuna: action.comunas}
      }

      case fromActions.Types.UPDATE_COMUNA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_COMUNA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_COMUNA_SUCCESS: {
        return {...state, loading: false, error: null, comunas: action.comunas}
      }

      case fromActions.Types.DELETE_COMUNA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_COMUNA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_COMUNA_SUCCESS: {
        return {...state, loading: false, error: null, comunas: action.comunas}
      }

      case fromActions.Types.DESACTIVATE_COMUNA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_COMUNA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_COMUNA_SUCCESS: {

        return {...state, loading: false, error: null, comunas: action.comunas}
      }

      case fromActions.Types.ACTIVATE_COMUNA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
