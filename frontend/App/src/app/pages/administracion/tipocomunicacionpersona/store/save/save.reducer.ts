import { TipoComPersonaResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  tipocompersonas: TipoComPersonaResponse[] | null;
  tipocompersona: TipoComPersonaResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  tipocompersonas: null,
  tipocompersona: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, tipocompersonas: action.tipocompersonas}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TIPOCOMPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TIPOCOMPERSONA_SUCCESS: {
        return {...state, loading: false, tipocompersona: action.tipocompersona}
      }

      case fromActions.Types.GET_TIPOCOMPERSONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TIPOCOMPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TIPOCOMPERSONA_SUCCESS: {
        return {...state, loading: false, error: null, tipocompersona: action.tipocompersona}
      }

      case fromActions.Types.CREATE_TIPOCOMPERSONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TIPOCOMPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TIPOCOMPERSONA_SUCCESS: {
        return {...state, loading: false, error: null, tipocompersona: action.tipocompersonas}
      }

      case fromActions.Types.UPDATE_TIPOCOMPERSONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TIPOCOMPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TIPOCOMPERSONA_SUCCESS: {
        return {...state, loading: false, error: null, tipocompersonas: action.tipocompersonas}
      }

      case fromActions.Types.DELETE_TIPOCOMPERSONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TIPOCOMPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TIPOCOMPERSONA_SUCCESS: {
        return {...state, loading: false, error: null, tipocompersonas: action.tipocompersonas}
      }

      case fromActions.Types.DESACTIVATE_TIPOCOMPERSONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_TIPOCOMPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TIPOCOMPERSONA_SUCCESS: {

        return {...state, loading: false, error: null, tipocompersonas: action.tipocompersonas}
      }

      case fromActions.Types.ACTIVATE_TIPOCOMPERSONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
