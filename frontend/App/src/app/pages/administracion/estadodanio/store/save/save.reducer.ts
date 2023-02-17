import { EstadoDanioResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  estadosdanios: EstadoDanioResponse[] | null;
  estadodanio: EstadoDanioResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  estadosdanios: null,
  estadodanio: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, estadosdanios: action.estadosdanios}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_ESTADODANIO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_ESTADODANIO_SUCCESS: {
        return {...state, loading: false, estadodanio: action.estadodanio}
      }

      case fromActions.Types.GET_ESTADODANIO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_ESTADODANIO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_ESTADODANIO_SUCCESS: {
        return {...state, loading: false, error: null, estadodanio: action.estadodanio}
      }

      case fromActions.Types.CREATE_ESTADODANIO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_ESTADODANIO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_ESTADODANIO_SUCCESS: {
        return {...state, loading: false, error: null, estadosdanios: action.estadosdanios}
      }

      case fromActions.Types.UPDATE_ESTADODANIO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_ESTADODANIO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_ESTADODANIO_SUCCESS: {
        return {...state, loading: false, error: null, estadosdanios: action.estadosdanios}
      }

      case fromActions.Types.DELETE_ESTADODANIO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_ESTADODANIO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_ESTADODANIO_SUCCESS: {
        return {...state, loading: false, error: null, estadosdanios: action.estadosdanios}
      }

      case fromActions.Types.DESACTIVATE_ESTADODANIO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_ESTADODANIO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_ESTADODANIO_SUCCESS: {

        return {...state, loading: false, error: null, estadosdanios: action.estadosdanios}
      }

      case fromActions.Types.ACTIVATE_ESTADODANIO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
