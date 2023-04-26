import { TipoPersonaResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  tipopersonas: TipoPersonaResponse[] | null;
  tipopersona: TipoPersonaResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  tipopersonas: null,
  tipopersona: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, tipopersonas: action.tipopersonas}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TIPOPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TIPOPERSONA_SUCCESS: {
        return {...state, loading: false, tipopersona: action.tipopersona}
      }

      case fromActions.Types.GET_TIPOPERSONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TIPOPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TIPOPERSONA_SUCCESS: {
        return {...state, loading: false, error: null, tipopersona: action.tipopersona}
      }

      case fromActions.Types.CREATE_TIPOPERSONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TIPOPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TIPOPERSONA_SUCCESS: {
        return {...state, loading: false, error: null, tipopersona: action.tipopersonas}
      }

      case fromActions.Types.UPDATE_TIPOPERSONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TIPOPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TIPOPERSONA_SUCCESS: {
        return {...state, loading: false, error: null, tipopersonas: action.tipopersonas}
      }

      case fromActions.Types.DELETE_TIPOPERSONA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TIPOPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TIPOPERSONA_SUCCESS: {
        return {...state, loading: false, error: null, tipopersonas: action.tipopersonas}
      }

      case fromActions.Types.DESACTIVATE_TIPOPERSONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_TIPOPERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TIPOPERSONA_SUCCESS: {

        return {...state, loading: false, error: null, tipopersonas: action.tipopersonas}
      }

      case fromActions.Types.ACTIVATE_TIPOPERSONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
