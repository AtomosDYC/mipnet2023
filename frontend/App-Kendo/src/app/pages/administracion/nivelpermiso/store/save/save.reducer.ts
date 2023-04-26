import { NivelPermisoResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  nivelpermisos: NivelPermisoResponse[] | null;
  nivelpermiso: NivelPermisoResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  nivelpermisos: null,
  nivelpermiso: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, nivelpermisos: action.nivelpermisos}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_NIVELPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_NIVELPERMISO_SUCCESS: {
        return {...state, loading: false, nivelpermiso: action.nivelpermiso}
      }

      case fromActions.Types.GET_NIVELPERMISO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_NIVELPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_NIVELPERMISO_SUCCESS: {
        return {...state, loading: false, error: null, nivelpermiso: action.nivelpermiso}
      }

      case fromActions.Types.CREATE_NIVELPERMISO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_NIVELPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_NIVELPERMISO_SUCCESS: {
        return {...state, loading: false, error: null, nivelpermiso: action.nivelpermisos}
      }

      case fromActions.Types.UPDATE_NIVELPERMISO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_NIVELPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_NIVELPERMISO_SUCCESS: {
        return {...state, loading: false, error: null, nivelpermisos: action.nivelpermisos}
      }

      case fromActions.Types.DELETE_NIVELPERMISO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_NIVELPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_NIVELPERMISO_SUCCESS: {
        return {...state, loading: false, error: null, nivelpermisos: action.nivelpermisos}
      }

      case fromActions.Types.DESACTIVATE_NIVELPERMISO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_NIVELPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_NIVELPERMISO_SUCCESS: {

        return {...state, loading: false, error: null, nivelpermisos: action.nivelpermisos}
      }

      case fromActions.Types.ACTIVATE_NIVELPERMISO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
