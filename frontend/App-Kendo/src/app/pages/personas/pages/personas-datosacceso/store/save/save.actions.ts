import {Action} from '@ngrx/store';
import {  PersonaAccesoResponse, PersonaAccesoRequest } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {

  GET_PERSONA_ACCESO = '[GET_PERSONA_ACCESO] Get_persona_acceso',
  GET_PERSONA_ACCESO_SUCCESS = '[GET_PERSONA_ACCESO] Get_persona_acceso:Success',
  GET_PERSONA_ACCESO_ERROR = '[GET_PERSONA_ACCESO] Get_persona_acceso:Error',

  CREATE_PERSONA_ACCESO = '[CREATE_PERSONA_ACCESO] create_persona_acceso',
  CREATE_PERSONA_ACCESO_SUCCESS = '[CREATE_PERSONA_ACCESO] create_persona_acceso:Success',
  CREATE_PERSONA_ACCESO_ERROR = '[CREATE_PERSONA_ACCESO] Create_persona_acceso:Error',
  
  UPDATE_PERSONA_ACCESO = '[UPDATE_PERSONA_ACCESO] Update_persona_acceso',
  UPDATE_PERSONA_ACCESO_SUCCESS = '[UPDATE_PERSONA_ACCESO] Update_persona_acceso:Success',
  UPDATE_PERSONA_ACCESO_ERROR = '[UPDATE_PERSONA_ACCESO] Update_persona_acceso:Error',

}


export class GetPersonaAcceso implements Action {
  readonly type = Types.GET_PERSONA_ACCESO;
  constructor(public id: string){}
}

export class GetPersonaAccesoSuccess implements Action {
  readonly type = Types.GET_PERSONA_ACCESO_SUCCESS;
  constructor(public personaacceso: PersonaAccesoResponse){}
}

export class GetPersonaAccesoError implements Action {
  readonly type = Types.GET_PERSONA_ACCESO_ERROR;
  constructor(public error: string){}
}



export class CreatePersonaAcceso implements Action {
  readonly type = Types.CREATE_PERSONA_ACCESO;
  constructor(public personaacceso: PersonaAccesoRequest){}
}

export class CreatePersonaAccesoSuccess implements Action {
  readonly type = Types.CREATE_PERSONA_ACCESO_SUCCESS;
  constructor(public personaacceso: PersonaAccesoResponse , public success: boolean){}
}

export class CreatePersonaAccesoError implements Action {
  readonly type = Types.CREATE_PERSONA_ACCESO_ERROR;
  constructor(public error: string) {}
}

export class UpdatePersonaAcceso implements Action {
  readonly type = Types.UPDATE_PERSONA_ACCESO;
  constructor(public personaacceso: PersonaAccesoRequest){}
}

export class UpdatePersonaAccesoSuccess implements Action {
  readonly type = Types.UPDATE_PERSONA_ACCESO_SUCCESS;
  constructor(public personaacceso: PersonaAccesoResponse, public success: boolean){}
}

export class UpdatePersonaAccesoError implements Action {
  readonly type = Types.UPDATE_PERSONA_ACCESO_ERROR;
  constructor(public error: string) {}
}


export type All =
  | GetPersonaAcceso | GetPersonaAccesoSuccess | GetPersonaAccesoError
  | CreatePersonaAcceso | CreatePersonaAccesoSuccess | CreatePersonaAccesoError
  | UpdatePersonaAcceso | UpdatePersonaAccesoSuccess | UpdatePersonaAccesoError
