import { EspecieResponse } from './save.models';
import * as fromActions from './save.actions';

export interface ListState {
  especies: EspecieResponse[] | null;
  especie: EspecieResponse | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  especies: null,
  especie: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_ESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_ESPECIE_SUCCESS: {
        return {...state, loading: false, especies: action.especies}
      }

      case fromActions.Types.READ_ESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.GET_ESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_ESPECIE_SUCCESS: {
        return {...state, loading: false, especie: action.especie}
      }

      case fromActions.Types.GET_ESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_ESPECIE_DATOSGENERALES: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_ESPECIE_DATOSGENERALES_SUCCESS: {
        return {...state, loading: false, error: null, especie: action.especie}
      }

      case fromActions.Types.CREATE_ESPECIE_DATOSGENERALES_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

      //actualizar
      case fromActions.Types.UPDATE_ESPECIE_DATOSGENERALES: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_ESPECIE_DATOSGENERALES_SUCCESS: {
        return {...state, loading: false, error: null, especie: action.especie}
      }

      case fromActions.Types.UPDATE_ESPECIE_DATOSGENERALES_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

      default: {
        return state;
      }
    }


}
