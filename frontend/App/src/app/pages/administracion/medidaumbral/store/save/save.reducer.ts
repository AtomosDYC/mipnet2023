import { MedidaUmbralResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  medidaumbrales: MedidaUmbralResponse[] | null;
  medidaumbral: MedidaUmbralResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  medidaumbrales: null,
  medidaumbral: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, medidaumbrales: action.medidaumbrales}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_MEDIDAUMBRAL: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_MEDIDAUMBRAL_SUCCESS: {
        return {...state, loading: false, medidaumbral: action.medidaumbral}
      }

      case fromActions.Types.GET_MEDIDAUMBRAL_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_MEDIDAUMBRAL: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_MEDIDAUMBRAL_SUCCESS: {
        return {...state, loading: false, error: null, medidaumbral: action.medidaumbral}
      }

      case fromActions.Types.CREATE_MEDIDAUMBRAL_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_MEDIDAUMBRAL: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_MEDIDAUMBRAL_SUCCESS: {
        return {...state, loading: false, error: null, medidaumbrales: action.medidaumbrales}
      }

      case fromActions.Types.UPDATE_MEDIDAUMBRAL_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_MEDIDAUMBRAL: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_MEDIDAUMBRAL_SUCCESS: {
        return {...state, loading: false, error: null, medidaumbrales: action.medidaumbrales}
      }

      case fromActions.Types.DELETE_MEDIDAUMBRAL_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_MEDIDAUMBRAL: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_MEDIDAUMBRAL_SUCCESS: {
        return {...state, loading: false, error: null, medidaumbrales: action.medidaumbrales}
      }

      case fromActions.Types.DESACTIVATE_MEDIDAUMBRAL_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_MEDIDAUMBRAL: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_MEDIDAUMBRAL_SUCCESS: {

        return {...state, loading: false, error: null, medidaumbrales: action.medidaumbrales}
      }

      case fromActions.Types.ACTIVATE_MEDIDAUMBRAL_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
