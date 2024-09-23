import { EstacionResponse, EstacionSource } from './save.models';

import * as fromActions from './save.actions';


import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  Estaciones: EstacionResponse[] | null;
  Estacion: EstacionResponse | null;
  Estacionsource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  Estaciones: null,
  Estacion: null,
  Estacionsource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_ESTACION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_ESTACION_SUCCESS: {
        return {...state, loading: false, Estacionsource: action.Estacionsource}
      }

      case fromActions.Types.READ_ESTACION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      
      //getbyid
      case fromActions.Types.GET_ESTACION_BYID: {
        return {...state, loading: true, Estacion: null, error: null}
      }

      case fromActions.Types.GET_ESTACION_BYID_SUCCESS: {
        return {...state, loading: false, Estacion: action.Estacion}
      }

      case fromActions.Types.GET_ESTACION_BYID_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_ESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_ESTACION_SUCCESS: {
        return {...state, loading: false, error: null, Estacion: action.Estacion, success: action.success}
      }

      case fromActions.Types.CREATE_ESTACION_ERROR : {
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
      case fromActions.Types.DELETE_ESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_ESTACION_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_ESTACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
      
    }


}
