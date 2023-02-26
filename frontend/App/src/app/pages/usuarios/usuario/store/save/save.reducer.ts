import { UsuarioResponse } from './save.models';
import * as fromActions from './save.actions';

export interface ListState {
  usuarios: UsuarioResponse[] | null;
  usuario: UsuarioResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  usuarios: null,
  usuario: null,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, usuarios: action.usuarios}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      default: {
        return state;
      }
    }


}
