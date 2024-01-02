import { PersonaAccesoResponse } from './save.models';
import * as fromActions from './save.actions';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  personaacceso: PersonaAccesoResponse | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  personaacceso: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      //getbyid
      case fromActions.Types.GET_PERSONA_ACCESO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_PERSONA_ACCESO_SUCCESS: {
        return {...state, loading: false, personaacceso: action.personaacceso}
      }

      case fromActions.Types.GET_PERSONA_ACCESO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_PERSONA_ACCESO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_PERSONA_ACCESO_SUCCESS: {
        return {...state, loading: false, error: null, personaacceso: action.personaacceso, success: action.success}
      }

      case fromActions.Types.CREATE_PERSONA_ACCESO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //update
      case fromActions.Types.UPDATE_PERSONA_ACCESO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_PERSONA_ACCESO_SUCCESS: {
        return {...state, loading: false, error: null, personaacceso: action.personaacceso, success: action.success}
      }

      case fromActions.Types.UPDATE_PERSONA_ACCESO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
    }


}
