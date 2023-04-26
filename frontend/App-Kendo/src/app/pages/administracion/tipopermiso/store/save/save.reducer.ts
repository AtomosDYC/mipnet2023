import { TipoPermisoResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  tipopermisos: TipoPermisoResponse[] | null;
  tipopermiso: TipoPermisoResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  tipopermisos: null,
  tipopermiso: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, tipopermisos: action.tipopermisos}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TIPOPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TIPOPERMISO_SUCCESS: {
        return {...state, loading: false, tipopermiso: action.tipopermiso}
      }

      case fromActions.Types.GET_TIPOPERMISO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TIPOPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TIPOPERMISO_SUCCESS: {
        return {...state, loading: false, error: null, tipopermiso: action.tipopermiso}
      }

      case fromActions.Types.CREATE_TIPOPERMISO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TIPOPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TIPOPERMISO_SUCCESS: {
        return {...state, loading: false, error: null, tipopermiso: action.tipopermisos}
      }

      case fromActions.Types.UPDATE_TIPOPERMISO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TIPOPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TIPOPERMISO_SUCCESS: {
        return {...state, loading: false, error: null, tipopermisos: action.tipopermisos}
      }

      case fromActions.Types.DELETE_TIPOPERMISO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TIPOPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TIPOPERMISO_SUCCESS: {
        return {...state, loading: false, error: null, tipopermisos: action.tipopermisos}
      }

      case fromActions.Types.DESACTIVATE_TIPOPERMISO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_TIPOPERMISO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TIPOPERMISO_SUCCESS: {

        return {...state, loading: false, error: null, tipopermisos: action.tipopermisos}
      }

      case fromActions.Types.ACTIVATE_TIPOPERMISO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
