import { UnirEspecieResponse } from './save.models';
import * as fromActions from './save.actions';
import { UnirEspecie } from '../../../../../../models/backend/especie/index';


export interface ListState {
  unirespecies: UnirEspecieResponse[] | null;
  unirespecie: UnirEspecieResponse | null;
  loading: boolean | null;
  error: string | null;
  success: boolean | null;
}

export const initialState: ListState = {
  unirespecies: null,
  unirespecie: null,
  loading: null,
  error: null,
  success: false,
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

     
      case fromActions.Types.GET_UNIRESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_UNIRESPECIE_SUCCESS: {
        return {...state, loading: false, unirespecies: action.unirespecies}
      }

      case fromActions.Types.GET_UNIRESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_UNIRESPECIE: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_UNIRESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, unirespecies: action.unirespecies, success: action.success}
      }

      case fromActions.Types.CREATE_UNIRESPECIE_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


//Eliminar
      case fromActions.Types.DELETE_UNIRESPECIE: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_UNIRESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, unirespecies: action.unirespecies, success: action.success}
      }

      case fromActions.Types.DELETE_UNIRESPECIE_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
      
    }


}
