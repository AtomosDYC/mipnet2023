import { PersonaResponse, PersonaSource } from './save.models';
import * as fromActions from './save.actions';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  personas: PersonaResponse[] | null;
  persona: PersonaResponse | null;
  personasource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  personas: null,
  persona: null,
  personasource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_PERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_PERSONA_SUCCESS: {
        return {...state, loading: false, personasource: action.personasource}
      }

      case fromActions.Types.READ_PERSONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //getbyid
      case fromActions.Types.GET_PERSONA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_PERSONA_SUCCESS: {
        return {...state, loading: false, persona: action.persona}
      }

      case fromActions.Types.GET_PERSONA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_PERSONA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_PERSONA_SUCCESS: {
        return {...state, loading: false, error: null, persona: action.persona, success: action.success}
      }

      case fromActions.Types.CREATE_PERSONA_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //update
      case fromActions.Types.UPDATE_PERSONA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_PERSONA_SUCCESS: {
        return {...state, loading: false, error: null, persona: action.persona, success: action.success}
      }

      case fromActions.Types.UPDATE_PERSONA_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //delete
      case fromActions.Types.DELETE_PERSONA: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_PERSONA_SUCCESS: {
        return {...state, loading: false, error: null, persona: action.persona, success: action.success}
      }

      case fromActions.Types.DELETE_PERSONA_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      default: {
        return state;
      }
    }


}
