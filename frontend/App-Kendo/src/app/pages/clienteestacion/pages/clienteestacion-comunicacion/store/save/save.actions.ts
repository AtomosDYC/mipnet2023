import {Action} from '@ngrx/store';

import { ClienteestacioncomunicacionResponse, ClienteestacioncomunicacionRequest, ClienteestacioncomunicacionbyidRequest } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_CLIENTEESTACION_COMUNICACION = '[CLIENTEESTACION_COMUNICACION] Read_Clienteestacion_Comunicacion',
  READ_CLIENTEESTACION_COMUNICACION_SUCCESS = '[CLIENTEESTACION_COMUNICACION] Read_Clienteestacion_Comunicacion:Success',
  READ_CLIENTEESTACION_COMUNICACION_ERROR = '[CLIENTEESTACION_COMUNICACION] Read_Clienteestacion_Comunicacion:Error',

  CREATE_CLIENTEESTACION_COMUNICACION = '[CREATE_CLIENTEESTACION_COMUNICACION] create_clienteestacion_comunicacion',
  CREATE_CLIENTEESTACION_COMUNICACION_SUCCESS = '[CREATE_CLIENTEESTACION_COMUNICACION] create_clienteestacion_comunicacion:Success',
  CREATE_CLIENTEESTACION_COMUNICACION_ERROR = '[CREATE_CLIENTEESTACION_COMUNICACION] create_clienteestacion_comunicacion:Error',

  DELETE_CLIENTEESTACION_COMUNICACION = '[DELETE_CLIENTEESTACION_COMUNICACION] Delete_clienteestacion_comunicacion',
  DELETE_CLIENTEESTACION_COMUNICACION_SUCCESS = '[DELETE_CLIENTEESTACION_COMUNICACION] Delete_clienteestacion_comunicacion:Success',
  DELETE_CLIENTEESTACION_COMUNICACION_ERROR = '[DELETE_CLIENTEESTACION_COMUNICACION] Delete_clienteestacion_comunicacion:Error',

  GET_CLIENTEESTACION_COMUNICACION_BYID = '[GET_CLIENTEESTACION_COMUNICACION] Get_clienteestacion_Comunicacion_byid',
  GET_CLIENTEESTACION_COMUNICACION_BYID_SUCCESS = '[GET_CLIENTEESTACION_COMUNICACION] Get_clienteestacion_Comunicacion_byid:Success',
  GET_CLIENTEESTACION_COMUNICACION_BYID_ERROR = '[GET_CLIENTEESTACION_COMUNICACION] Get_clienteestacion_Comunicacion_byid:Error',

}

export class ReadClienteestacioncomunicacion implements Action {
  readonly type = Types.READ_CLIENTEESTACION_COMUNICACION;
  constructor(public clienteestacioncomunicacion: RequestState){}
}

export class ReadClienteestacioncomunicacionSuccess implements Action {
  readonly type = Types.READ_CLIENTEESTACION_COMUNICACION_SUCCESS;
  constructor(public clienteestacioncomunicacionsource: GridDataResult){}
}

export class ReadClienteestacioncomunicacionError implements Action {
  readonly type = Types.READ_CLIENTEESTACION_COMUNICACION_ERROR;
  constructor(public error: string){}
}


export class GetClienteestacionCommunicacionbyid implements Action {
  readonly type = Types.GET_CLIENTEESTACION_COMUNICACION_BYID;
  constructor(public requestbyid: ClienteestacioncomunicacionbyidRequest){}
}

export class GetClienteestacionCommunicacionbyidSuccess implements Action {
  readonly type = Types.GET_CLIENTEESTACION_COMUNICACION_BYID_SUCCESS;
  constructor(public clienteestacioncomunicacion: ClienteestacioncomunicacionResponse){}
}

export class GetClienteestacionCommunicacionbyidError implements Action {
  readonly type = Types.GET_CLIENTEESTACION_COMUNICACION_BYID_ERROR;
  constructor(public error: string){}
}

export class CreateClienteestacioncomunicacion implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION_COMUNICACION;
  constructor(public clienteestacioncomunicacion: ClienteestacioncomunicacionRequest){}
}

export class CreateClienteestacioncomunicacionSuccess implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION_COMUNICACION_SUCCESS;
  constructor(public clienteestacioncomunicacion: ClienteestacioncomunicacionRequest , public success: boolean){}
}

export class CreateClienteestacioncomunicacionError implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION_COMUNICACION_ERROR;
  constructor(public error: string) {}
}


//eliminar
export class DeleteClienteestacioncomunicacion implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION_COMUNICACION;
  constructor(public requestbyid: ClienteestacioncomunicacionbyidRequest){}
}

export class DeleteClienteestacioncomunicacionSuccess implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION_COMUNICACION_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteClienteestacioncomunicacionError implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION_COMUNICACION_ERROR;
  constructor(public error: string) {}
}



export type All =
  ReadClienteestacioncomunicacion | ReadClienteestacioncomunicacionSuccess |   ReadClienteestacioncomunicacionError
  | GetClienteestacionCommunicacionbyid | GetClienteestacionCommunicacionbyidSuccess | GetClienteestacionCommunicacionbyidError
  | CreateClienteestacioncomunicacion | CreateClienteestacioncomunicacionSuccess | CreateClienteestacioncomunicacionError
  | DeleteClienteestacioncomunicacion | DeleteClienteestacioncomunicacionSuccess | DeleteClienteestacioncomunicacionError