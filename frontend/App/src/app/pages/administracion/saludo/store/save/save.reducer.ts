import { SaludoResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  saludos: SaludoResponse[] | null;
  saludo: SaludoResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  saludos: null,
  saludo: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, saludos: action.saludos}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_SALUDO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_SALUDO_SUCCESS: {
        return {...state, loading: false, saludo: action.saludo}
      }

      case fromActions.Types.GET_SALUDO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_SALUDO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_SALUDO_SUCCESS: {
        return {...state, loading: false, error: null, saludo: action.saludo}
      }

      case fromActions.Types.CREATE_SALUDO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_SALUDO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_SALUDO_SUCCESS: {
        return {...state, loading: false, error: null, saludo: action.saludos}
      }

      case fromActions.Types.UPDATE_SALUDO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_SALUDO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_SALUDO_SUCCESS: {
        return {...state, loading: false, error: null, saludos: action.saludos}
      }

      case fromActions.Types.DELETE_SALUDO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_SALUDO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_SALUDO_SUCCESS: {
        return {...state, loading: false, error: null, saludos: action.saludos}
      }

      case fromActions.Types.DESACTIVATE_SALUDO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_SALUDO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_SALUDO_SUCCESS: {

        return {...state, loading: false, error: null, saludos: action.saludos}
      }

      case fromActions.Types.ACTIVATE_SALUDO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
