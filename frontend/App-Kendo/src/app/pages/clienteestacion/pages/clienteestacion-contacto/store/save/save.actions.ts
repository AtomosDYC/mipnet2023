import {Action} from '@ngrx/store';

import { ClienteestacioncontactoResponse, ClienteestacioncontactoRequest, ClienteestacioncontactobyidRequest } from './save.models';
import { PersonaResponse, PersonaBuscarRutRequest } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_CLIENTEESTACION_CONTACTO = '[CLIENTEESTACION_CONTACTO] Read_Clienteestacion_Comunicacion',
  READ_CLIENTEESTACION_CONTACTO_SUCCESS = '[CLIENTEESTACION_CONTACTO] Read_Clienteestacion_Comunicacion:Success',
  READ_CLIENTEESTACION_CONTACTO_ERROR = '[CLIENTEESTACION_CONTACTO] Read_Clienteestacion_Comunicacion:Error',

  CREATE_CLIENTEESTACION_CONTACTO = '[CREATE_CLIENTEESTACION_CONTACTO] create_clienteestacion_contacto',
  CREATE_CLIENTEESTACION_CONTACTO_SUCCESS = '[CREATE_CLIENTEESTACION_CONTACTO] create_clienteestacion_contacto:Success',
  CREATE_CLIENTEESTACION_CONTACTO_ERROR = '[CREATE_CLIENTEESTACION_CONTACTO] create_clienteestacion_contacto:Error',

  DELETE_CLIENTEESTACION_CONTACTO = '[DELETE_CLIENTEESTACION_CONTACTO] Delete_clienteestacion_contacto',
  DELETE_CLIENTEESTACION_CONTACTO_SUCCESS = '[DELETE_CLIENTEESTACION_CONTACTO] Delete_clienteestacion_contacto:Success',
  DELETE_CLIENTEESTACION_CONTACTO_ERROR = '[DELETE_CLIENTEESTACION_CONTACTO] Delete_clienteestacion_contacto:Error',

  GET_CLIENTEESTACION_CONTACTO_BYID = '[GET_CLIENTEESTACION_CONTACTO] Get_clienteestacion_Comunicacion_byid',
  GET_CLIENTEESTACION_CONTACTO_BYID_SUCCESS = '[GET_CLIENTEESTACION_CONTACTO] Get_clienteestacion_Comunicacion_byid:Success',
  GET_CLIENTEESTACION_CONTACTO_BYID_ERROR = '[GET_CLIENTEESTACION_CONTACTO] Get_clienteestacion_Comunicacion_byid:Error',

  GET_PERSONA_BYRUT = '[GET_PERSONA_BYRUT] Get_persona_byrut',
  GET_PERSONA_BYRUT_SUCCESS = '[GET_PERSONA_BYRUT] Get_persona_byrut:Success',
  GET_PERSONA_BYRUT_ERROR = '[GET_PERSONA_BYRUT] Get_persona_byrut:Error',

}

export class ReadClienteestacioncontacto implements Action {
  readonly type = Types.READ_CLIENTEESTACION_CONTACTO;
  constructor(public clienteestacioncontacto: RequestState){}
}

export class ReadClienteestacioncontactoSuccess implements Action {
  readonly type = Types.READ_CLIENTEESTACION_CONTACTO_SUCCESS;
  constructor(public clienteestacioncontactosource: GridDataResult){}
}

export class ReadClienteestacioncontactoError implements Action {
  readonly type = Types.READ_CLIENTEESTACION_CONTACTO_ERROR;
  constructor(public error: string){}
}


export class GetClienteestacioncontactobyid implements Action {
  readonly type = Types.GET_CLIENTEESTACION_CONTACTO_BYID;
  constructor(public requestbyid: ClienteestacioncontactobyidRequest){}
}

export class GetClienteestacioncontactobyidSuccess implements Action {
  readonly type = Types.GET_CLIENTEESTACION_CONTACTO_BYID_SUCCESS;
  constructor(public clienteestacioncontacto: ClienteestacioncontactoResponse){}
}

export class GetClienteestacioncontactobyidError implements Action {
  readonly type = Types.GET_CLIENTEESTACION_CONTACTO_BYID_ERROR;
  constructor(public error: string){}
}

export class CreateClienteestacioncontacto implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION_CONTACTO;
  constructor(public clienteestacioncontacto: ClienteestacioncontactoRequest){}
}

export class CreateClienteestacioncontactoSuccess implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION_CONTACTO_SUCCESS;
  constructor(public clienteestacioncontacto: ClienteestacioncontactoRequest , public success: boolean){}
}

export class CreateClienteestacioncontactoError implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION_CONTACTO_ERROR;
  constructor(public error: string) {}
}


//eliminar
export class DeleteClienteestacioncontacto implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION_CONTACTO;
  constructor(public requestbyid: ClienteestacioncontactobyidRequest){}
}

export class DeleteClienteestacioncontactoSuccess implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION_CONTACTO_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteClienteestacioncontactoError implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION_CONTACTO_ERROR;
  constructor(public error: string) {}
}

export class GetPersonabyrut implements Action {
  readonly type = Types.GET_PERSONA_BYRUT;
  constructor(public persona: PersonaBuscarRutRequest){}
}

export class GetPersonabyrutSuccess implements Action {
  readonly type = Types.GET_PERSONA_BYRUT_SUCCESS;
  constructor(public persona: PersonaResponse){}
}

export class GetPersonabyrutError implements Action {
  readonly type = Types.GET_PERSONA_BYRUT_ERROR;
  constructor(public error: string){}
}

export type All =
  ReadClienteestacioncontacto | ReadClienteestacioncontactoSuccess |   ReadClienteestacioncontactoError
  | GetClienteestacioncontactobyid | GetClienteestacioncontactobyidSuccess | GetClienteestacioncontactobyidError
  | CreateClienteestacioncontacto | CreateClienteestacioncontactoSuccess | CreateClienteestacioncontactoError
  | DeleteClienteestacioncontacto | DeleteClienteestacioncontactoSuccess | DeleteClienteestacioncontactoError
  | GetPersonabyrut | GetPersonabyrutSuccess | GetPersonabyrutError