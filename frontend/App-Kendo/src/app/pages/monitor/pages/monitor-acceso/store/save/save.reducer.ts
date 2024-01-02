import { MonitorAccesoResponse } from './save.models';
import * as fromActions from './save.actions';

export interface ListState {
  monitoracceso: MonitorAccesoResponse | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  monitoracceso: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      //getbyid
      case fromActions.Types.GET_MONITOR_ACCESO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_MONITOR_ACCESO_SUCCESS: {
        return {...state, loading: false, monitoracceso: action.monitoracceso}
      }

      case fromActions.Types.GET_MONITOR_ACCESO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_MONITOR_ACCESO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_MONITOR_ACCESO_SUCCESS: {
        return {...state, loading: false, error: null, monitoracceso: action.monitoracceso, success: action.success}
      }

      case fromActions.Types.CREATE_MONITOR_ACCESO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //update
      case fromActions.Types.UPDATE_MONITOR_ACCESO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_MONITOR_ACCESO_SUCCESS: {
        return {...state, loading: false, error: null, monitoracceso: action.monitoracceso, success: action.success}
      }

      case fromActions.Types.UPDATE_MONITOR_ACCESO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
    }


}
