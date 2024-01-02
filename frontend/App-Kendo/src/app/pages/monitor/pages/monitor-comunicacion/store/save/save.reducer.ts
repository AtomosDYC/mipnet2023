import { MonitorcomunicacionResponse, MonitorcomunicacionSource } from './save.models';
import * as fromActions from './save.actions';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { Personacomunicacion } from '../../../../../../models/backend/persona/index';

export interface ListState {
  monitorcomunicaciones: MonitorcomunicacionResponse[] | null;
  monitorcomunicacion: MonitorcomunicacionResponse | null;
  monitorcomunicacionsource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  monitorcomunicaciones: null,
  monitorcomunicacion: null,
  monitorcomunicacionsource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_MONITOR_COMUNICACION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_MONITOR_COMUNICACION_SUCCESS: {
        return {...state, loading: false, monitorcomunicacionsource: action.monitorcomunicacionsource}
      }

      case fromActions.Types.READ_MONITOR_COMUNICACION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      
      //getbyid
      case fromActions.Types.GET_MONITOR_COMUNICACION: {
        return {...state, loading: true, monitorcomunicacion: null, error: null}
      }

      case fromActions.Types.GET_MONITOR_COMUNICACION_SUCCESS: {
        return {...state, loading: false, monitorcomunicacion: action.monitorcomunicacion}
      }

      case fromActions.Types.GET_MONITOR_COMUNICACION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_MONITOR_COMUNICACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_MONITOR_COMUNICACION_SUCCESS: {
        return {...state, loading: false, error: null, monitorcomunicacion: action.monitorcomunicacion, success: action.success}
      }

      case fromActions.Types.CREATE_MONITOR_COMUNICACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
/*
      //update
      case fromActions.Types.UPDATE_MONITOR: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_MONITOR_SUCCESS: {
        return {...state, loading: false, error: null, monitor: action.monitor, success: action.success}
      }

      case fromActions.Types.UPDATE_MONITOR_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
*/
      //delete
      case fromActions.Types.DELETE_MONITOR_COMUNICACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_MONITOR_COMUNICACION_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_MONITOR_COMUNICACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
      
      default: {
        return state;
      }
    }


}
