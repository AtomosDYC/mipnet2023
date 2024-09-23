import { ClienteUsuarioResponse, ClienteUsuarioActivaSource, MenuUsuarioResponse } from './save.models';
import * as fromActions from './save.actions';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  clienteusuarioactivas: ClienteUsuarioResponse[] | null;
  clienteusuarioactiva: ClienteUsuarioResponse | null;
  clienteusuarioactivasource: GridDataResult | null;
  clienteusuarioinactivasource: GridDataResult | null;
  MenuUsuario: MenuUsuarioResponse | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  clienteusuarioactivas: null,
  clienteusuarioactiva: null,
  clienteusuarioactivasource: null,
  clienteusuarioinactivasource: null,
  MenuUsuario: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_CLIENTEUSUARIOACTIVA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_CLIENTEUSUARIOACTIVA_SUCCESS: {
        return {...state, loading: false, clienteusuarioactivasource: action.clienteusuarioactivasource}
      }

      case fromActions.Types.READ_CLIENTEUSUARIOACTIVA_ERROR: {
        return  {...state, loading: false, error: action.error, clienteusuarioactivasource: null}
      }

      case fromActions.Types.READ_CLIENTEUSUARIOINACTIVA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_CLIENTEUSUARIOINACTIVA_SUCCESS: {
        return {...state, loading: false, clienteusuarioinactivasource: action.clienteusuarioinactivasource}
      }

      case fromActions.Types.READ_CLIENTEUSUARIOINACTIVA_ERROR: {
        return  {...state, loading: false, error: action.error, clienteusuarioinactivasource: null}
      }


      
      //getbyid
      case fromActions.Types.GET_CLIENTEUSUARIO_BYID: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_CLIENTEUSUARIO_BYID_SUCCESS: {
        return {...state, loading: false, clienteusuario: action.clienteusuario}
      }

      case fromActions.Types.GET_CLIENTEUSUARIO_BYID_ERROR: {
        return  {...state, loading: false, error: action.error, clienteusuario:null}
      }

      //getbyrut
      case fromActions.Types.GET_CLIENTEUSUARIO_BYRUT: {
        return {...state, loading: true, error: null, clienteusuario:null}
      }

      case fromActions.Types.GET_CLIENTEUSUARIO_BYRUT_SUCCESS: {
        return {...state, loading: false, clienteusuario: action.clienteusuario}
      }

      case fromActions.Types.GET_CLIENTEUSUARIO_BYRUT_ERROR: {
        return  {...state, loading: false, error: action.error, clienteusuario:null}
      }

      //getmenu
      case fromActions.Types.GET_CLIENTEUSUARIO_MENU: {
        return {...state, loading: true, error: null, menuusuario:null}
      }

      case fromActions.Types.GET_CLIENTEUSUARIO_MENU_SUCCESS: {
        return {...state, loading: false, menuusuario: action.menuusuario}
      }

      case fromActions.Types.GET_CLIENTEUSUARIO_MENU_ERROR: {
        return  {...state, loading: false, error: action.error, menuusuario:null}
      }

      //crear
      case fromActions.Types.CREATE_CLIENTEUSUARIO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_CLIENTEUSUARIO_SUCCESS: {
        return {...state, loading: false, error: null, clienteusuario: action.clienteusuario, success: action.success}
      }

      case fromActions.Types.CREATE_CLIENTEUSUARIO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //update
      case fromActions.Types.UPDATE_CLIENTEUSUARIO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_CLIENTEUSUARIO_SUCCESS: {
        return {...state, loading: false, error: null, monitor: action.monitor, success: action.success}
      }

      case fromActions.Types.UPDATE_CLIENTEUSUARIO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //delete
      case fromActions.Types.DELETE_CLIENTEUSUARIO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_CLIENTEUSUARIO_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_CLIENTEUSUARIO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }



      case fromActions.Types.DESACTIVATE_CLIENTEUSUARIO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DESACTIVATE_CLIENTEUSUARIO_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DESACTIVATE_CLIENTEUSUARIO_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }


      case fromActions.Types.ACTIVATE_CLIENTEUSUARIO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.ACTIVATE_CLIENTEUSUARIO_SUCCESS: {

        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.ACTIVATE_CLIENTEUSUARIO_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }
        

      default: {
        return state;
      }
      
    }


}
