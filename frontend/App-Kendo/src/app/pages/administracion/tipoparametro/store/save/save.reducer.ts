import { TipoParametroResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  tipoparametros: TipoParametroResponse[] | null;
  tipoparametro: TipoParametroResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  tipoparametros: null,
  tipoparametro: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, tipoparametros: action.tipoparametros}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TIPOPARAMETRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TIPOPARAMETRO_SUCCESS: {
        return {...state, loading: false, tipoparametro: action.tipoparametro}
      }

      case fromActions.Types.GET_TIPOPARAMETRO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TIPOPARAMETRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TIPOPARAMETRO_SUCCESS: {
        return {...state, loading: false, error: null, tipoparametro: action.tipoparametro}
      }

      case fromActions.Types.CREATE_TIPOPARAMETRO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TIPOPARAMETRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TIPOPARAMETRO_SUCCESS: {
        return {...state, loading: false, error: null, tipoparametro: action.tipoparametros}
      }

      case fromActions.Types.UPDATE_TIPOPARAMETRO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TIPOPARAMETRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TIPOPARAMETRO_SUCCESS: {
        return {...state, loading: false, error: null, tipoparametros: action.tipoparametros}
      }

      case fromActions.Types.DELETE_TIPOPARAMETRO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TIPOPARAMETRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TIPOPARAMETRO_SUCCESS: {
        return {...state, loading: false, error: null, tipoparametros: action.tipoparametros}
      }

      case fromActions.Types.DESACTIVATE_TIPOPARAMETRO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_TIPOPARAMETRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TIPOPARAMETRO_SUCCESS: {

        return {...state, loading: false, error: null, tipoparametros: action.tipoparametros}
      }

      case fromActions.Types.ACTIVATE_TIPOPARAMETRO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
