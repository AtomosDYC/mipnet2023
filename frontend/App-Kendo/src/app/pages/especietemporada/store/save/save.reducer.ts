import { EspecieTemporada } from './save.models';


import * as fromActions from './save.actions';
import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  especietemporadas: EspecieTemporada[] | null;
  especietemporada: EspecieTemporada | null;
  especietemporadasource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  especietemporadas: null,
  especietemporada: null,
  especietemporadasource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_ESPECIETEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_ESPECIETEMPORADA_SUCCESS: {
        return {...state, loading: false, especietemporadasource: action.especietemporadasource}
      }

      case fromActions.Types.READ_ESPECIETEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error, especietemporadasource: null}
      }

      
      //getbyid
      case fromActions.Types.GET_ESPECIETEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_ESPECIETEMPORADA_SUCCESS: {
        return {...state, loading: false, especietemporada: action.especietemporada}
      }

      case fromActions.Types.GET_ESPECIETEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error, especietemporada: null}
      }


      //crear
      case fromActions.Types.CREATE_ESPECIETEMPORADA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_ESPECIETEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, especietemporada: action.especietemporada, success: action.success}
      }

      case fromActions.Types.CREATE_ESPECIETEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //update
      case fromActions.Types.UPDATE_ESPECIETEMPORADA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_ESPECIETEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, especietemporada: null, success: action.success}
      }

      case fromActions.Types.UPDATE_ESPECIETEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //delete
      case fromActions.Types.DELETE_ESPECIETEMPORADA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_ESPECIETEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, especietemporada: null, success: action.success}
      }

      case fromActions.Types.DELETE_ESPECIETEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


      case fromActions.Types.DESACTIVATE_ESPECIETEMPORADA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DESACTIVATE_ESPECIETEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, especietemporadas: null, success: action.success}
      }

      case fromActions.Types.DESACTIVATE_ESPECIETEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }


      case fromActions.Types.ACTIVATE_ESPECIETEMPORADA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.ACTIVATE_ESPECIETEMPORADA_SUCCESS: {

        return {...state, loading: false, error: null, especietemporadas: null, success: action.success}
      }

      case fromActions.Types.ACTIVATE_ESPECIETEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error, success: false}
      }
      

      default: {
        return state;
      }
    }


}
