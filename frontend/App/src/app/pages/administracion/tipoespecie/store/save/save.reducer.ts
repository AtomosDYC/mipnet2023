import { TipoEspecieResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  tipoespecies: TipoEspecieResponse[] | null;
  tipoespecie: TipoEspecieResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  tipoespecies: null,
  tipoespecie: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, tipoespecies: action.tipoespecies}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_TIPOESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_TIPOESPECIE_SUCCESS: {
        return {...state, loading: false, tipoespecie: action.tipoespecie}
      }

      case fromActions.Types.GET_TIPOESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_TIPOESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_TIPOESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, tipoespecie: action.tipoespecie}
      }

      case fromActions.Types.CREATE_TIPOESPECIE_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_TIPOESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_TIPOESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, tipoespecie: action.tipoespecies}
      }

      case fromActions.Types.UPDATE_TIPOESPECIE_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_TIPOESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_TIPOESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, tipoespecies: action.tipoespecies}
      }

      case fromActions.Types.DELETE_TIPOESPECIE_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_TIPOESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_TIPOESPECIE_SUCCESS: {
        return {...state, loading: false, error: null, tipoespecies: action.tipoespecies}
      }

      case fromActions.Types.DESACTIVATE_TIPOESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_TIPOESPECIE: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_TIPOESPECIE_SUCCESS: {

        return {...state, loading: false, error: null, tipoespecies: action.tipoespecies}
      }

      case fromActions.Types.ACTIVATE_TIPOESPECIE_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
