import { PersonacomunicacionResponse, PersonacomunicacionSource } from './save.models';
import * as fromActions from './save.actions';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { Personacomunicacion } from '../../../../../../models/backend/persona/index';

export interface ListState {
  personacomunicaciones: PersonacomunicacionResponse[] | null;
  personacomunicacion: PersonacomunicacionResponse | null;
  personacomunicacionsource: GridDataResult | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  personacomunicaciones: null,
  personacomunicacion: null,
  personacomunicacionsource: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_PERSONA_COMUNICACION: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_PERSONA_COMUNICACION_SUCCESS: {
        return {...state, loading: false, personacomunicacionsource: action.personacomunicacionsource}
      }

      case fromActions.Types.READ_PERSONA_COMUNICACION_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      /*
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
*/
      //crear
      case fromActions.Types.CREATE_PERSONA_COMUNICACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_PERSONA_COMUNICACION_SUCCESS: {
        return {...state, loading: false, error: null, personacomunicacion: action.personacomunicacion, success: action.success}
      }

      case fromActions.Types.CREATE_PERSONA_COMUNICACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
/*
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
*/
      //delete
      case fromActions.Types.DELETE_PERSONA_COMUNICACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_PERSONA_COMUNICACION_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_PERSONA_COMUNICACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
      
      default: {
        return state;
      }
    }


}
