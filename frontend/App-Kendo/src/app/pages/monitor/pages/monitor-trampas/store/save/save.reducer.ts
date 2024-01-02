import { MonitortrampaResponse, MonitortrampaSource } from './save.models';
import * as fromActions from './save.actions';

import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  monitortrampaes: MonitortrampaResponse[] | null;
  monitortrampa: MonitortrampaResponse | null;
  monitortrampasource: GridDataResult | null;
  monitorbuscartrampasource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  monitortrampaes: null,
  monitortrampa: null,
  monitortrampasource: null,
  monitorbuscartrampasource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_MONITOR_TRAMPA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_MONITOR_TRAMPA_SUCCESS: {
        return {...state, loading: false, monitortrampasource: action.monitortrampasource}
      }

      case fromActions.Types.READ_MONITOR_TRAMPA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      //getbyid
      case fromActions.Types.GET_MONITOR_BUSCAR_TRAMPA: {
        return {...state, loading: true, monitortrampa: null, error: null}
      }

      case fromActions.Types.GET_MONITOR_BUSCAR_TRAMPA_SUCCESS: {
        return {...state, loading: false, monitorbuscartrampasource: action.monitortrampabuscarsource}
      }

      case fromActions.Types.GET_MONITOR_BUSCAR_TRAMPA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      
      //getbyid
      case fromActions.Types.GET_MONITOR_TRAMPA: {
        return {...state, loading: true, monitortrampa: null, error: null}
      }

      case fromActions.Types.GET_MONITOR_TRAMPA_SUCCESS: {
        return {...state, loading: false, monitortrampa: action.monitortrampa}
      }

      case fromActions.Types.GET_MONITOR_TRAMPA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.ASIGNAR_MONITOR_TRAMPA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.ASIGNAR_MONITOR_TRAMPA_SUCCESS: {
        return {...state, loading: false, error: null, monitortrampa: action.monitortrampa, success: action.success}
      }

      case fromActions.Types.ASIGNAR_MONITOR_TRAMPA_ERROR : {
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
      case fromActions.Types.DELETE_MONITOR_TRAMPA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_MONITOR_TRAMPA_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_MONITOR_TRAMPA_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


      //replicar
      case fromActions.Types.REPLICAR_TEMPORADA_MONITOR: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.REPLICAR_TEMPORADA_MONITOR_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.REPLICAR_TEMPORADA_MONITOR_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


      
      default: {
        return state;
      }
    }


}
