import { TipoDocumentoResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  tipodocumentos: TipoDocumentoResponse[] | null;
  tipodocumento: TipoDocumentoResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  tipodocumentos: null,
  tipodocumento: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, tipodocumentos: action.tipodocumentos}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TIPODOCUMENTO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TIPODOCUMENTO_SUCCESS: {
        return {...state, loading: false, tipodocumento: action.tipodocumento}
      }

      case fromActions.Types.GET_TIPODOCUMENTO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TIPODOCUMENTO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TIPODOCUMENTO_SUCCESS: {
        return {...state, loading: false, error: null, tipodocumento: action.tipodocumento}
      }

      case fromActions.Types.CREATE_TIPODOCUMENTO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TIPODOCUMENTO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TIPODOCUMENTO_SUCCESS: {
        return {...state, loading: false, error: null, tipodocumento: action.tipodocumentos}
      }

      case fromActions.Types.UPDATE_TIPODOCUMENTO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TIPODOCUMENTO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TIPODOCUMENTO_SUCCESS: {
        return {...state, loading: false, error: null, tipodocumentos: action.tipodocumentos}
      }

      case fromActions.Types.DELETE_TIPODOCUMENTO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TIPODOCUMENTO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TIPODOCUMENTO_SUCCESS: {
        return {...state, loading: false, error: null, tipodocumentos: action.tipodocumentos}
      }

      case fromActions.Types.DESACTIVATE_TIPODOCUMENTO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_TIPODOCUMENTO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TIPODOCUMENTO_SUCCESS: {

        return {...state, loading: false, error: null, tipodocumentos: action.tipodocumentos}
      }

      case fromActions.Types.ACTIVATE_TIPODOCUMENTO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
