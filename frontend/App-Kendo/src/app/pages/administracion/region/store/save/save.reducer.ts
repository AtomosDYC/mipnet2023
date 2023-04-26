import { RegionResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  regiones: RegionResponse[] | null;
  region: RegionResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  regiones: null,
  region: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, regiones: action.regiones}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_REGION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_REGION_SUCCESS: {
        return {...state, loading: false, region: action.region}
      }

      case fromActions.Types.GET_REGION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_REGION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_REGION_SUCCESS: {
        return {...state, loading: false, error: null, region: action.region}
      }

      case fromActions.Types.CREATE_REGION_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_REGION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_REGION_SUCCESS: {
        return {...state, loading: false, error: null, region: action.regiones}
      }

      case fromActions.Types.UPDATE_REGION_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_REGION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_REGION_SUCCESS: {
        return {...state, loading: false, error: null, regiones: action.regiones}
      }

      case fromActions.Types.DELETE_REGION_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_REGION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_REGION_SUCCESS: {
        return {...state, loading: false, error: null, regiones: action.regiones}
      }

      case fromActions.Types.DESACTIVATE_REGION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_REGION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_REGION_SUCCESS: {

        return {...state, loading: false, error: null, regiones: action.regiones}
      }

      case fromActions.Types.ACTIVATE_REGION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
