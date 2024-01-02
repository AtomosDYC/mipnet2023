import {Action} from '@ngrx/store';
import {  PersonaResponse, PersonaRequest, PersonaRequestUpdate } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_PERSONA = '[Persona] Read_Persona',
  READ_PERSONA_SUCCESS = '[Persona] Read_Persona:Success',
  READ_PERSONA_ERROR = '[Persona] Read_Persona:Error',

  GET_PERSONA = '[GET_PERSONA] Get_persona',
  GET_PERSONA_SUCCESS = '[GET_PERSONA] Get_persona:Success',
  GET_PERSONA_ERROR = '[GET_PERSONA] Get_persona:Error',

  CREATE_PERSONA = '[CREATE_PERSONA] create_persona',
  CREATE_PERSONA_SUCCESS = '[CREATE_PERSONA] create_persona:Success',
  CREATE_PERSONA_ERROR = '[CREATE_PERSONA] Create_persona:Error',
  
  UPDATE_PERSONA = '[UPDATE_PERSONA] Update_persona',
  UPDATE_PERSONA_SUCCESS = '[UPDATE_PERSONA] Update_persona:Success',
  UPDATE_PERSONA_ERROR = '[UPDATE_PERSONA] Update_persona:Error',

  DELETE_PERSONA = '[DELETE_PERSONA] Delete_persona',
  DELETE_PERSONA_SUCCESS = '[DELETE_PERSONA] Delete_persona:Success',
  DELETE_PERSONA_ERROR = '[DELETE_PERSONA] Delete_persona:Error',

}

export class ReadPersona implements Action {
  readonly type = Types.READ_PERSONA;
  constructor(public persona: RequestState){}
}

export class ReadPersonaSuccess implements Action {
  readonly type = Types.READ_PERSONA_SUCCESS;
  constructor(public personasource: GridDataResult){}
}

export class ReadPersonaError implements Action {
  readonly type = Types.READ_PERSONA_ERROR;
  constructor(public error: string){}
}


export class GetPersonabyid implements Action {
  readonly type = Types.GET_PERSONA;
  constructor(public id: string){}
}

export class GetPersonabyidSuccess implements Action {
  readonly type = Types.GET_PERSONA_SUCCESS;
  constructor(public persona: PersonaResponse){}
}

export class GetPersonabyidError implements Action {
  readonly type = Types.GET_PERSONA_ERROR;
  constructor(public error: string){}
}

export class CreatePersona implements Action {
  readonly type = Types.CREATE_PERSONA;
  constructor(public persona: PersonaRequest){}
}

export class CreatePersonaSuccess implements Action {
  readonly type = Types.CREATE_PERSONA_SUCCESS;
  constructor(public persona: PersonaResponse , public success: boolean){}
}

export class CreatePersonaError implements Action {
  readonly type = Types.CREATE_PERSONA_ERROR;
  constructor(public error: string) {}
}

export class UpdatePersona implements Action {
  readonly type = Types.UPDATE_PERSONA;
  constructor(public persona: PersonaRequestUpdate){}
}

export class UpdatePersonaSuccess implements Action {
  readonly type = Types.UPDATE_PERSONA_SUCCESS;
  constructor(public persona: PersonaResponse, public success: boolean){}
}

export class UpdatePersonaError implements Action {
  readonly type = Types.UPDATE_PERSONA_ERROR;
  constructor(public error: string) {}
}

export class DeletePersona implements Action {
  readonly type = Types.DELETE_PERSONA;
  constructor(public persona: PersonaRequest){}
}

export class DeletePersonaSuccess implements Action {
  readonly type = Types.DELETE_PERSONA_SUCCESS;
  constructor(public persona: PersonaResponse, public success: boolean){}
}

export class DeletePersonaError implements Action {
  readonly type = Types.DELETE_PERSONA_ERROR;
  constructor(public error: string) {}
}

export type All =
  ReadPersona | ReadPersonaSuccess | ReadPersonaError
  | GetPersonabyid | GetPersonabyidSuccess | GetPersonabyidError
  | CreatePersona | CreatePersonaSuccess | CreatePersonaError
  | UpdatePersona | UpdatePersonaSuccess | UpdatePersonaError
  | DeletePersona | DeletePersonaSuccess | DeletePersonaError