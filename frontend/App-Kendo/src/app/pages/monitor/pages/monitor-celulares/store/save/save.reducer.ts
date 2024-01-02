import { MonitorSincronizacionResponse, MonitorSincronizacionesResponse, dataMonitorSincronizacionSource } from './save.models';
import * as fromActions from './save.actions';

import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  monitorsincronizaciones: MonitorSincronizacionesResponse[] | null;
  monitorsincronizacion: MonitorSincronizacionResponse | null;
  monitorsincronizacionsource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  monitorsincronizaciones: null,
  monitorsincronizacion: null,
  monitorsincronizacionsource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_MONITOR_SINCRONIZACION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_MONITOR_SINCRONIZACION_SUCCESS: {
        return {...state, loading: false, monitorsincronizacionsource: action.monitorsincronizacionsource}
      }

      case fromActions.Types.READ_MONITOR_SINCRONIZACION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.SINCRONIZAR_MONITOR_TRAMPA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.SINCRONIZAR_MONITOR_TRAMPA_SUCCESS: {
        return {...state, loading: false, error: null, monitortrampa: action.monitortrampa, success: action.success}
      }

      case fromActions.Types.SINCRONIZAR_MONITOR_TRAMPA_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
      
      default: {
        return state;
      }
    }


}
