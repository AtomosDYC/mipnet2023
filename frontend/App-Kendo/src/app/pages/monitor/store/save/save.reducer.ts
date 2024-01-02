import { MonitorResponse } from './save.models';

import { PersonaResponse } from './save.models';

import * as fromActions from './save.actions';
import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  monitores: MonitorResponse[] | null;
  monitor: MonitorResponse | null;
  monitorsource: GridDataResult | null;
  persona: PersonaResponse | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  monitores: null,
  monitor: null,
  monitorsource: null,
  persona:null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_MONITOR: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_MONITOR_SUCCESS: {
        return {...state, loading: false, monitorsource: action.monitorsource}
      }

      case fromActions.Types.READ_MONITOR_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //getbyid
      case fromActions.Types.GET_MONITOR: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_MONITOR_SUCCESS: {
        return {...state, loading: false, monitor: action.monitor}
      }

      case fromActions.Types.GET_MONITOR_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      

      //getbyrut
      case fromActions.Types.GET_MONITOR_BYRUT: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_MONITOR_BYRUT_SUCCESS: {
        return {...state, loading: false, persona: action.persona}
      }

      case fromActions.Types.GET_MONITOR_BYRUT_ERROR: {
        return  {...state, loading: false, error: action.error, persona:null}
      }




      //crear
      case fromActions.Types.CREATE_MONITOR: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_MONITOR_SUCCESS: {
        return {...state, loading: false, error: null, monitor: action.monitor, success: action.success}
      }

      case fromActions.Types.CREATE_MONITOR_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

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

      //delete
      case fromActions.Types.DELETE_MONITOR: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_MONITOR_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_MONITOR_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }



      case fromActions.Types.DESACTIVATE_MONITOR: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DESACTIVATE_MONITOR_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DESACTIVATE_MONITOR_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }


      case fromActions.Types.ACTIVATE_MONITOR: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.ACTIVATE_MONITOR_SUCCESS: {

        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.ACTIVATE_MONITOR_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
    }


}
