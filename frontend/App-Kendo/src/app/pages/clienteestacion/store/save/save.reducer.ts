import { ClienteEstacionResponse, ClienteEstacionActivaSource } from './save.models';
import * as fromActions from './save.actions';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  clienteestacionactivas: ClienteEstacionResponse[] | null;
  clienteestacionactiva: ClienteEstacionResponse | null;
  clienteestacionactivasource: GridDataResult | null;
  clienteestacion: ClienteEstacionResponse | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  clienteestacionactivas: null,
  clienteestacionactiva: null,
  clienteestacionactivasource: null,
  clienteestacion: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_CLIENTEESTACIONACTIVA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_CLIENTEESTACIONACTIVA_SUCCESS: {
        return {...state, loading: false, clienteestacionactivasource: action.clienteestacionactivasource}
      }

      case fromActions.Types.READ_CLIENTEESTACIONACTIVA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //getbyid
      case fromActions.Types.GET_CLIENTEESTACION_BYID: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_CLIENTEESTACION_BYID_SUCCESS: {
        return {...state, loading: false, clienteestacion: action.clienteestacion}
      }

      case fromActions.Types.GET_CLIENTEESTACION_BYID_ERROR: {
        return  {...state, loading: false, error: action.error, clienteestacion:null}
      }

      //getbyrut
      case fromActions.Types.GET_CLIENTEESTACION_BYRUT: {
        return {...state, loading: true, error: null, clienteestacion:null}
      }

      case fromActions.Types.GET_CLIENTEESTACION_BYRUT_SUCCESS: {
        return {...state, loading: false, clienteestacion: action.clienteestacion}
      }

      case fromActions.Types.GET_CLIENTEESTACION_BYRUT_ERROR: {
        return  {...state, loading: false, error: action.error, clienteestacion:null}
      }

      //crear
      case fromActions.Types.CREATE_CLIENTEESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_CLIENTEESTACION_SUCCESS: {
        return {...state, loading: false, error: null, clienteestacion: action.clienteestacion, success: action.success}
      }

      case fromActions.Types.CREATE_CLIENTEESTACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //update
      case fromActions.Types.UPDATE_CLIENTEESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_CLIENTEESTACION_SUCCESS: {
        return {...state, loading: false, error: null, monitor: action.monitor, success: action.success}
      }

      case fromActions.Types.UPDATE_CLIENTEESTACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //delete
      case fromActions.Types.DELETE_CLIENTEESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_CLIENTEESTACION_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_CLIENTEESTACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }



      case fromActions.Types.DESACTIVATE_CLIENTEESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DESACTIVATE_CLIENTEESTACION_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DESACTIVATE_CLIENTEESTACION_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }


      case fromActions.Types.ACTIVATE_CLIENTEESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.ACTIVATE_CLIENTEESTACION_SUCCESS: {

        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.ACTIVATE_CLIENTEESTACION_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
      
    }


}
