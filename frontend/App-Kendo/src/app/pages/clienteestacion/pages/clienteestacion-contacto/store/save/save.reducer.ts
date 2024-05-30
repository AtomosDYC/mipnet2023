import { ClienteestacioncontactoResponse, ClienteestacioncontactoSource } from './save.models';
import { PersonaResponse } from './save.models';
import * as fromActions from './save.actions';


import { GridDataResult } from "@progress/kendo-angular-grid";

export interface ListState {
  clienteestacioncontactoes: ClienteestacioncontactoResponse[] | null;
  clienteestacioncontacto: ClienteestacioncontactoResponse | null;
  clienteestacioncontactosource: GridDataResult | null;
  persona: PersonaResponse | null;
  loading: boolean | null;
  success: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  clienteestacioncontactoes: null,
  clienteestacioncontacto: null,
  clienteestacioncontactosource: null,
  persona: null,
  success: false,
  loading: null,
  error: null
}

export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ_CLIENTEESTACION_CONTACTO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_CLIENTEESTACION_CONTACTO_SUCCESS: {
        return {...state, loading: false, clienteestacioncontactosource: action.clienteestacioncontactosource}
      }

      case fromActions.Types.READ_CLIENTEESTACION_CONTACTO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      
      //getbyid
      case fromActions.Types.GET_CLIENTEESTACION_CONTACTO_BYID: {
        return {...state, loading: true, clienteestacioncontacto: null, error: null}
      }

      case fromActions.Types.GET_CLIENTEESTACION_CONTACTO_BYID_SUCCESS: {
        return {...state, loading: false, clienteestacioncontacto: action.clienteestacioncontacto}
      }

      case fromActions.Types.GET_CLIENTEESTACION_CONTACTO_BYID_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      //crear
      case fromActions.Types.CREATE_CLIENTEESTACION_CONTACTO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_CLIENTEESTACION_CONTACTO_SUCCESS: {
        return {...state, loading: false, error: null, clienteestacioncontacto: action.clienteestacioncontacto, success: action.success}
      }

      case fromActions.Types.CREATE_CLIENTEESTACION_CONTACTO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
/*
      //update
      case fromActions.Types.UPDATE_CLIENTEESTACION: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.UPDATE_CLIENTEESTACION_SUCCESS: {
        return {...state, loading: false, error: null, clienteestacion: action.clienteestacion, success: action.success}
      }

      case fromActions.Types.UPDATE_CLIENTEESTACION_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }
*/
      //delete
      case fromActions.Types.DELETE_CLIENTEESTACION_CONTACTO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.DELETE_CLIENTEESTACION_CONTACTO_SUCCESS: {
        return {...state, loading: false, error: null, success: action.success}
      }

      case fromActions.Types.DELETE_CLIENTEESTACION_CONTACTO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }

      //getbyrut
      case fromActions.Types.GET_PERSONA_BYRUT: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_PERSONA_BYRUT_SUCCESS: {
        return {...state, loading: false, persona: action.persona}
      }

      case fromActions.Types.GET_PERSONA_BYRUT_ERROR: {
        return  {...state, loading: false, error: action.error, persona:null}
      }
      
      default: {
        return state;
      }
    }


}
