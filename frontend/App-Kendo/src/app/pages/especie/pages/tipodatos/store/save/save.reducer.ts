import { DanioEspecieResponse } from './save.models';
import * as fromActions from './save.actions';
import { DanioEspecie } from '../../../../../../models/backend/especie/index';


export interface ListState {
  danioespecies: DanioEspecieResponse[] | null;
  danioespecie: DanioEspecieResponse | null;
  loading: boolean | null;
  error: string | null;
  success: boolean | null;
}

export const initialState: ListState = {
  danioespecies: null,
  danioespecie: null,
  loading: null,
  error: null,
  success: false,
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

     
      case fromActions.Types.GET_DANIOESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_DANIOESPECIE_SUCCESS: {
        return {...state, loading: false, danioespecies: action.danioespecies}
      }

      case fromActions.Types.GET_DANIOESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_DANIOESPECIE: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_DANIOESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, danioespecies: action.danioespecies, success: action.success}
      }

      case fromActions.Types.CREATE_DANIOESPECIE_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


//Eliminar
      case fromActions.Types.DELETE_DANIOESPECIE: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_DANIOESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, danioespecies: action.danioespecies, success: action.success}
      }

      case fromActions.Types.DELETE_DANIOESPECIE_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
      
    }


}
