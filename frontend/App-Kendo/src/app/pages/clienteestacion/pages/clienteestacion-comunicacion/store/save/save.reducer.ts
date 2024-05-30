import { ClienteestacioncomunicacionResponse, ClienteestacioncomunicacionSource } from './save.models';
import * as fromActions from './save.actions';


import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  clienteestacioncomunicaciones: ClienteestacioncomunicacionResponse[] | null;
  clienteestacioncomunicacion: ClienteestacioncomunicacionResponse | null;
  clienteestacioncomunicacionsource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  clienteestacioncomunicaciones: null,
  clienteestacioncomunicacion: null,
  clienteestacioncomunicacionsource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_CLIENTEESTACION_COMUNICACION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_CLIENTEESTACION_COMUNICACION_SUCCESS: {
        return {...state, loading: false, clienteestacioncomunicacionsource: action.clienteestacioncomunicacionsource}
      }

      case fromActions.Types.READ_CLIENTEESTACION_COMUNICACION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      
      //getbyid
      case fromActions.Types.GET_CLIENTEESTACION_COMUNICACION_BYID: {
        return {...state, loading: true, clienteestacioncomunicacion: null, error: null}
      }

      case fromActions.Types.GET_CLIENTEESTACION_COMUNICACION_BYID_SUCCESS: {
        return {...state, loading: false, clienteestacioncomunicacion: action.clienteestacioncomunicacion}
      }

      case fromActions.Types.GET_CLIENTEESTACION_COMUNICACION_BYID_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_CLIENTEESTACION_COMUNICACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_CLIENTEESTACION_COMUNICACION_SUCCESS: {
        return {...state, loading: false, error: null, clienteestacioncomunicacion: action.clienteestacioncomunicacion, success: action.success}
      }

      case fromActions.Types.CREATE_CLIENTEESTACION_COMUNICACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
/*
      //update
      case fromActions.Types.UPDATE_CLIENTEESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_CLIENTEESTACION_SUCCESS: {
        return {...state, loading: false, error: null, clienteestacion: action.clienteestacion, success: action.success}
      }

      case fromActions.Types.UPDATE_CLIENTEESTACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
*/
      //delete
      case fromActions.Types.DELETE_CLIENTEESTACION_COMUNICACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_CLIENTEESTACION_COMUNICACION_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_CLIENTEESTACION_COMUNICACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
      
      default: {
        return state;
      }
    }


}
