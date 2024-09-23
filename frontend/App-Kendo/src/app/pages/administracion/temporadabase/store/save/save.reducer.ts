import { TemporadaBaseResponse } from './save.models';
import * as fromActions from './save.actions';
import { GridDataResult } from '@progress/kendo-angular-grid';


export interface ListState {
  temporadabases: TemporadaBaseResponse[] | null;
  temporadabase: TemporadaBaseResponse | null;
  temporadabasesource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  temporadabases: null,
  temporadabase: null,
  temporadabasesource: null,
  loading: null,
  success: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_TEMPORADABASE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_TEMPORADABASE_SUCCESS: {
        return {...state, loading: false, temporadabasesource: action.temporadabasesource}
      }

      case fromActions.Types.READ_TEMPORADABASE_ERROR: { 
        return  {...state, loading: false, error: action.error, temporadabasesource: null}
      }



      case fromActions.Types.GET_TEMPORADABASE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TEMPORADABASE_SUCCESS: {
        return {...state, loading: false, temporadabase: action.temporadabase}
      }

      case fromActions.Types.GET_TEMPORADABASE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TEMPORADABASE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TEMPORADABASE_SUCCESS: {
        return {...state, loading: false, error: null, temporadabase: action.temporadabase}
      }

      case fromActions.Types.CREATE_TEMPORADABASE_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TEMPORADABASE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TEMPORADABASE_SUCCESS: {
        return {...state, loading: false, error: null, temporadabase: action.temporadabases}
      }

      case fromActions.Types.UPDATE_TEMPORADABASE_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TEMPORADABASE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TEMPORADABASE_SUCCESS: {
        return {...state, loading: false, error: null, temporadabases: action.temporadabases}
      }

      case fromActions.Types.DELETE_TEMPORADABASE_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TEMPORADABASE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TEMPORADABASE_SUCCESS: {
        return {...state, loading: false, error: null, temporadabasesource: action.temporadabasesource}
      }

      case fromActions.Types.DESACTIVATE_TEMPORADABASE_ERROR: {
        return  {...state, loading: false, error: action.error, temporadabasesource: null}
      }


      case fromActions.Types.ACTIVATE_TEMPORADABASE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TEMPORADABASE_SUCCESS: {

        return {...state, loading: false, error: null, temporadabasesource: action.temporadabasesource}
      }

      case fromActions.Types.ACTIVATE_TEMPORADABASE_ERROR: {
        return  {...state, loading: false, error: action.error, temporadabasesource: null}
      }




      default: {
        return state;
      }
    }


}
