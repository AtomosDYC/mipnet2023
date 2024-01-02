import { TemporadaResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  temporadas: TemporadaResponse[] | null;
  temporada: TemporadaResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  temporadas: null,
  temporada: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, temporadas: action.temporadas}
      }

      case fromActions.Types.READ_ERROR: { 
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TEMPORADA_SUCCESS: {
        return {...state, loading: false, temporada: action.temporada}
      }

      case fromActions.Types.GET_TEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, temporada: action.temporada}
      }

      case fromActions.Types.CREATE_TEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, temporada: action.temporadas}
      }

      case fromActions.Types.UPDATE_TEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, temporadas: action.temporadas}
      }

      case fromActions.Types.DELETE_TEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, temporadas: action.temporadas}
      }

      case fromActions.Types.DESACTIVATE_TEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_TEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TEMPORADA_SUCCESS: {

        return {...state, loading: false, error: null, temporadas: action.temporadas}
      }

      case fromActions.Types.ACTIVATE_TEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      default: {
        return state;
      }
    }


}
