import { PlantillaResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  plantillas: PlantillaResponse[] | null;
  plantilla: PlantillaResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  plantillas: null,
  plantilla: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, plantillas: action.plantillas}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_PLANTILLA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_PLANTILLA_SUCCESS: {
        return {...state, loading: false, plantilla: action.plantilla}
      }

      case fromActions.Types.GET_PLANTILLA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_PLANTILLA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_PLANTILLA_SUCCESS: {
        return {...state, loading: false, error: null, plantilla: action.plantilla}
      }

      case fromActions.Types.CREATE_PLANTILLA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_PLANTILLA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_PLANTILLA_SUCCESS: {
        return {...state, loading: false, error: null, plantilla: action.plantillas}
      }

      case fromActions.Types.UPDATE_PLANTILLA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_PLANTILLA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_PLANTILLA_SUCCESS: {
        return {...state, loading: false, error: null, plantillas: action.plantillas}
      }

      case fromActions.Types.DELETE_PLANTILLA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_PLANTILLA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_PLANTILLA_SUCCESS: {
        return {...state, loading: false, error: null, plantillas: action.plantillas}
      }

      case fromActions.Types.DESACTIVATE_PLANTILLA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_PLANTILLA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_PLANTILLA_SUCCESS: {

        return {...state, loading: false, error: null, plantillas: action.plantillas}
      }

      case fromActions.Types.ACTIVATE_PLANTILLA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
