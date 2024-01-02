import { UsuarioResponse } from './save.models';
import * as fromActions from './save.actions';
import { usuarioregistro } from '../../../../../models/backend/usuario/index';

export interface ListState {
  usuarioregistros: UsuarioResponse[] | null;
  usuarioregistro: UsuarioResponse | null;
  success: boolean | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  usuarioregistros: null,
  usuarioregistro: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, usuarioregistros: action.usuarioregistros}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      case fromActions.Types.GET_USUARIOREGISTRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_USUARIOREGISTRO_SUCCESS: {
        return {...state, loading: false, usuarioregistro: action.usuarioregistro}
      }

      case fromActions.Types.GET_USUARIOREGISTRO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.CREATE_USUARIOREGISTRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_USUARIOREGISTRO_SUCCESS: {
        return {...state, loading: false, error: null, usuarioregistros: action.usuarioregistros}
      }

      case fromActions.Types.CREATE_USUARIOREGISTRO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

      //actualizar
      case fromActions.Types.UPDATE_USUARIOREGISTRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_USUARIOREGISTRO: {
        return {...state, loading: false, error: null, usuarioregistro: action.usuarioregistro}
      }

      case fromActions.Types.UPDATE_USUARIOREGISTRO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.SEND_MAILCONFIRMATION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.SEND_MAILCONFIRMATION_SUCCESS: {
        return {...state, loading: false, success: true}
      }

      case fromActions.Types.SEND_MAILCONFIRMATION_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
    }


}
