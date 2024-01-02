import { EspecieUmbralResponse } from './save.models';
import * as fromActions from './save.actions';
import { EspecieUmbral } from '../../../../../../models/backend/especie/index';


export interface ListState {
  especieumbrals: EspecieUmbralResponse[] | null;
  especieumbral: EspecieUmbralResponse | null;
  loading: boolean | null;
  error: string | null;
  success: boolean | null;
}

export const initialState: ListState = {
  especieumbrals: null,
  especieumbral: null,
  loading: null,
  error: null,
  success: false,
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

     
      case fromActions.Types.GET_ESPECIEUMBRAL: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_ESPECIEUMBRAL_SUCCESS: {
        return {...state, loading: false, especieumbrals: action.especieumbrals}
      }

      case fromActions.Types.GET_ESPECIEUMBRAL_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_ESPECIEUMBRAL: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_ESPECIEUMBRAL_SUCCESS: {
        return {...state, loading: false, error: null, especieumbrals: action.especieumbrals, success: action.success}
      }

      case fromActions.Types.CREATE_ESPECIEUMBRAL_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


//Eliminar
      case fromActions.Types.DELETE_ESPECIEUMBRAL: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_ESPECIEUMBRAL_SUCCESS: {
        return {...state, loading: false, error: null, especieumbrals: action.especieumbrals, success: action.success}
      }

      case fromActions.Types.DELETE_ESPECIEUMBRAL_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
      
    }


}
