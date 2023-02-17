import { ZonaResponse } from './save.models';
import * as fromActions from './save.actions';



export interface ListState {
  zonas: ZonaResponse[] | null;
  zona: ZonaResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  zonas: null,
  zona: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, zonas: action.zonas}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_ZONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_ZONA_SUCCESS: {
        return {...state, loading: false, zona: action.zona}
      }

      case fromActions.Types.GET_ZONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_ZONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_ZONA_SUCCESS: {
        return {...state, loading: false, error: null, zona: action.zona}
      }

      case fromActions.Types.CREATE_ZONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_ZONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_ZONA_SUCCESS: {
        return {...state, loading: false, error: null, zona: action.zonas}
      }

      case fromActions.Types.UPDATE_ZONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_ZONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_ZONA_SUCCESS: {
        return {...state, loading: false, error: null, zonas: action.zonas}
      }

      case fromActions.Types.DELETE_ZONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_ZONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_ZONA_SUCCESS: {
        return {...state, loading: false, error: null, zonas: action.zonas}
      }

      case fromActions.Types.DESACTIVATE_ZONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_ZONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_ZONA_SUCCESS: {

        return {...state, loading: false, error: null, zonas: action.zonas}
      }

      case fromActions.Types.ACTIVATE_ZONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
