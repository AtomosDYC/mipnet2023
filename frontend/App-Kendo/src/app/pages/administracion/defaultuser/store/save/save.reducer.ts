import { DefaultUserResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  defaultusers: DefaultUserResponse[] | null;
  defaultuser: DefaultUserResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  defaultusers: null,
  defaultuser: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, defaultuser: action.defaultuser}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_DEFAULTUSER: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_DEFAULTUSER_SUCCESS: {
        return {...state, loading: false, defaultuser: action.defaultuser}
      }

      case fromActions.Types.GET_DEFAULTUSER_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_DEFAULTUSER: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_DEFAULTUSER_SUCCESS: {
        return {...state, loading: false, error: null, defaultuser: action.defaultuser}
      }

      case fromActions.Types.CREATE_DEFAULTUSER_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_DEFAULTUSER: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_DEFAULTUSER_SUCCESS: {
        return {...state, loading: false, error: null, defaultuser: action.defaultusers}
      }

      case fromActions.Types.UPDATE_DEFAULTUSER_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

      default: {
        return state;
      }
    }


}
