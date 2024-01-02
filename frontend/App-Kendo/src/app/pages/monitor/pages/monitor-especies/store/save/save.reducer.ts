import { MonitorespecieResponse, MonitorespecieSource } from './save.models';
import * as fromActions from './save.actions';

import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  monitorespeciees: MonitorespecieResponse[] | null;
  monitorespecie: MonitorespecieResponse | null;
  monitorespeciesource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  monitorespeciees: null,
  monitorespecie: null,
  monitorespeciesource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_MONITOR_ESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_MONITOR_ESPECIE_SUCCESS: {
        return {...state, loading: false, monitorespeciesource: action.monitorespeciesource}
      }

      case fromActions.Types.READ_MONITOR_ESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      
      //getbyid
      case fromActions.Types.GET_MONITOR_ESPECIE: {
        return {...state, loading: true, monitorespecie: null, error: null}
      }

      case fromActions.Types.GET_MONITOR_ESPECIE_SUCCESS: {
        return {...state, loading: false, monitorespecie: action.monitorespecie}
      }

      case fromActions.Types.GET_MONITOR_ESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_MONITOR_ESPECIE: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_MONITOR_ESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, monitorespecie: action.monitorespecie, success: action.success}
      }

      case fromActions.Types.CREATE_MONITOR_ESPECIE_ERROR : {
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
      case fromActions.Types.DELETE_MONITOR_ESPECIE: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_MONITOR_ESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_MONITOR_ESPECIE_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
      
      default: {
        return state;
      }
    }


}
