import {Action} from '@ngrx/store';

import {  PersonacomunicacionResponse, PersonacomunicacionRequest, PersonacomunicacionbyidRequest } from './save.models';



import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";



export enum Types {
  READ_PERSONA_COMUNICACION = '[Persona] Read_Persona_Comunicacion',
  READ_PERSONA_COMUNICACION_SUCCESS = '[Persona] Read_Persona_Comunicacion:Success',
  READ_PERSONA_COMUNICACION_ERROR = '[Persona] Read_Persona_Comunicacion:Error',

  CREATE_PERSONA_COMUNICACION = '[CREATE_PERSONA_COMUNICACION] create_persona_comunicacion',
  CREATE_PERSONA_COMUNICACION_SUCCESS = '[CREATE_PERSONA_COMUNICACION] create_persona_comunicacion:Success',
  CREATE_PERSONA_COMUNICACION_ERROR = '[CREATE_PERSONA_COMUNICACION] create_persona_comunicacion:Error',

  DELETE_PERSONA_COMUNICACION = '[DELETE_PERSONA_COMUNICACION] Delete_persona_comunicacion',
  DELETE_PERSONA_COMUNICACION_SUCCESS = '[DELETE_PERSONA_COMUNICACION] Delete_persona_comunicacion:Success',
  DELETE_PERSONA_COMUNICACION_ERROR = '[DELETE_PERSONA_COMUNICACION] Delete_persona_comunicacion:Error',


  /*
  GET_PERSONA = '[GET_PERSONA] Get_persona',
  GET_PERSONA_SUCCESS = '[GET_PERSONA] Get_persona:Success',
  GET_PERSONA_ERROR = '[GET_PERSONA] Get_persona:Error',

  
  
  UPDATE_PERSONA = '[UPDATE_PERSONA] Update_persona',
  UPDATE_PERSONA_SUCCESS = '[UPDATE_PERSONA] Update_persona:Success',
  UPDATE_PERSONA_ERROR = '[UPDATE_PERSONA] Update_persona:Error',


*/
}

export class ReadPersonacomunicacion implements Action {
  readonly type = Types.READ_PERSONA_COMUNICACION;
  constructor(public personacomunicacion: RequestState){}
}

export class ReadPersonacomunicacionSuccess implements Action {
  readonly type = Types.READ_PERSONA_COMUNICACION_SUCCESS;
  constructor(public personacomunicacionsource: GridDataResult){}
}

export class ReadPersonacomunicacionError implements Action {
  readonly type = Types.READ_PERSONA_COMUNICACION_ERROR;
  constructor(public error: string){}
}

export class CreatePersonacomunicacion implements Action {
  readonly type = Types.CREATE_PERSONA_COMUNICACION;
  constructor(public personacomunicacion: PersonacomunicacionRequest){}
}

export class CreatePersonacomunicacionSuccess implements Action {
  readonly type = Types.CREATE_PERSONA_COMUNICACION_SUCCESS;
  constructor(public personacomunicacion: PersonacomunicacionResponse , public success: boolean){}
}

export class CreatePersonacomunicacionError implements Action {
  readonly type = Types.CREATE_PERSONA_COMUNICACION_ERROR;
  constructor(public error: string) {}
}


//eliminar
export class DeletePersonacomunicacion implements Action {
  readonly type = Types.DELETE_PERSONA_COMUNICACION;
  constructor(public requestbyid: PersonacomunicacionbyidRequest){}
}

export class DeletePersonacomunicacionSuccess implements Action {
  readonly type = Types.DELETE_PERSONA_COMUNICACION_SUCCESS;
  constructor(public success: boolean){}
}

export class DeletePersonacomunicacionError implements Action {
  readonly type = Types.DELETE_PERSONA_COMUNICACION_ERROR;
  constructor(public error: string) {}
}



export type All =
  ReadPersonacomunicacion | ReadPersonacomunicacionSuccess |   ReadPersonacomunicacionError
  | CreatePersonacomunicacion | CreatePersonacomunicacionSuccess | CreatePersonacomunicacionError
  | DeletePersonacomunicacion | DeletePersonacomunicacionSuccess | DeletePersonacomunicacionError