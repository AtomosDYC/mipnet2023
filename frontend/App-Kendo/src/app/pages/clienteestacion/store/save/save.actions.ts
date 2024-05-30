import {Action} from '@ngrx/store';
import {  ClienteEstacionRequest, ClienteEstacionResponse, ClienteEstacionRequestUpdate, clienteestaciondesactivateRequest } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_CLIENTEESTACIONACTIVA = '[ClienteEstacion] Read_ClienteEstacionActiva',
  READ_CLIENTEESTACIONACTIVA_SUCCESS = '[ClienteEstacion] Read_ClienteEstacionActiva:Success',
  READ_CLIENTEESTACIONACTIVA_ERROR = '[ClienteEstacion] Read_ClienteEstacionActiva:Error',

  GET_CLIENTEESTACION_BYID = '[ClienteEstacion] Get_ClienteEstacion_byid',
  GET_CLIENTEESTACION_BYID_SUCCESS = '[ClienteEstacion] Get_ClienteEstacion_byid:Success',
  GET_CLIENTEESTACION_BYID_ERROR = '[ClienteEstacion] Get_ClienteEstacion_byid:Error',

  GET_CLIENTEESTACION_BYRUT = '[ClienteEstacion] Get_ClienteEstacion_byrut',
  GET_CLIENTEESTACION_BYRUT_SUCCESS = '[ClienteEstacion] Get_ClienteEstacion_byrut:Success',
  GET_CLIENTEESTACION_BYRUT_ERROR = '[ClienteEstacion] Get_ClienteEstacion_byrut:Error',

  CREATE_CLIENTEESTACION = '[ClienteEstacion] Create_ClienteEstacion',
  CREATE_CLIENTEESTACION_SUCCESS = '[ClienteEstacion] Create_ClienteEstacion:Success',
  CREATE_CLIENTEESTACION_ERROR = '[ClienteEstacion] Create_ClienteEstacion:Error',

  UPDATE_CLIENTEESTACION = '[ClienteEstacion] Update_ClienteEstacion',
  UPDATE_CLIENTEESTACION_SUCCESS = '[ClienteEstacion] Update_ClienteEstacion:Success',
  UPDATE_CLIENTEESTACION_ERROR = '[ClienteEstacion] Update_ClienteEstacion:Error',

  DELETE_CLIENTEESTACION = '[DELETE_CLIENTEESTACION] Delete_ClienteEstacion',
  DELETE_CLIENTEESTACION_SUCCESS = '[DELETE_CLIENTEESTACION] Delete_ClienteEstacion:Success',
  DELETE_CLIENTEESTACION_ERROR = '[DELETE_CLIENTEESTACION] Delete_ClienteEstacion:Error',

  ACTIVATE_CLIENTEESTACION = '[CLIENTEESTACION] activate_ClienteEstacion',
  ACTIVATE_CLIENTEESTACION_SUCCESS = '[CLIENTEESTACION] activate_ClienteEstacion:Success',
  ACTIVATE_CLIENTEESTACION_ERROR = '[CLIENTEESTACION] activate_ClienteEstacion:Error',

  DESACTIVATE_CLIENTEESTACION = '[CLIENTEESTACION] desactivate_ClienteEstacion',
  DESACTIVATE_CLIENTEESTACION_SUCCESS = '[CLIENTEESTACION] desactivate_ClienteEstacion:Success',
  DESACTIVATE_CLIENTEESTACION_ERROR = '[CLIENTEESTACION] desactivate_ClienteEstacion:Error',
  
}

export class ReadClienteEstacionActiva implements Action {
  readonly type = Types.READ_CLIENTEESTACIONACTIVA;
  constructor(public clienteestacion: RequestState){}
}

export class ReadClienteEstacionActivaSuccess implements Action {
  readonly type = Types.READ_CLIENTEESTACIONACTIVA_SUCCESS;
  constructor(public clienteestacionactivasource: GridDataResult){}
}

export class ReadClienteEstacionActivaError implements Action {
  readonly type = Types.READ_CLIENTEESTACIONACTIVA_ERROR;
  constructor(public error: string){}
}

export class GetClienteEstacionbyid implements Action {
  readonly type = Types.GET_CLIENTEESTACION_BYID;
  constructor(public id: string){}
}

export class GetClienteEstacionbyidSuccess implements Action {
  readonly type = Types.GET_CLIENTEESTACION_BYID_SUCCESS;
  constructor(public clienteestacion: ClienteEstacionResponse){}
}

export class GetClienteEstacionbyidError implements Action {
  readonly type = Types.GET_CLIENTEESTACION_BYID_ERROR;
  constructor(public error: string){}
}

export class GetClienteEstacionbyrut implements Action {
  readonly type = Types.GET_CLIENTEESTACION_BYRUT;
  constructor(public rut: string){}
}

export class GetClienteEstacionbyrutSuccess implements Action {
  readonly type = Types.GET_CLIENTEESTACION_BYRUT_SUCCESS;
  constructor(public clienteestacion: ClienteEstacionResponse){}
}

export class GetClienteEstacionbyrutError implements Action {
  readonly type = Types.GET_CLIENTEESTACION_BYRUT_ERROR;
  constructor(public error: string){}
}


export class CreateClienteEstacion implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION;
  constructor(public clienteestacion: ClienteEstacionRequest){}
}

export class CreateClienteEstacionSuccess implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION_SUCCESS;
  constructor(public clienteestacion: ClienteEstacionResponse , public success: boolean){}
}

export class CreateClienteEstacionError implements Action {
  readonly type = Types.CREATE_CLIENTEESTACION_ERROR;
  constructor(public error: string) {}
}

export class UpdateClienteEstacion implements Action {
  readonly type = Types.UPDATE_CLIENTEESTACION;
  constructor(public clienteestacion: ClienteEstacionRequestUpdate){}
}

export class UpdateClienteEstacionSuccess implements Action {
  readonly type = Types.UPDATE_CLIENTEESTACION_SUCCESS;
  constructor(public clienteestacion: ClienteEstacionResponse, public success: boolean){}
}

export class UpdateClienteEstacionError implements Action {
  readonly type = Types.UPDATE_CLIENTEESTACION_ERROR;
  constructor(public error: string) {}
}

export class DeleteClienteEstacion implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION;
  constructor(public id: string){}
}

export class DeleteClienteEstacionSuccess implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteClienteEstacionError implements Action {
  readonly type = Types.DELETE_CLIENTEESTACION_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class ActivateClienteEstacion implements Action {
  readonly type = Types.ACTIVATE_CLIENTEESTACION;
  constructor(public clienteestaciones: clienteestaciondesactivateRequest[]){}
}

export class ActivateClienteEstacionSuccess implements Action {
  readonly type = Types.ACTIVATE_CLIENTEESTACION_SUCCESS;
  constructor(public success: boolean){}
}

export class ActivateClienteEstacionError implements Action {
  readonly type = Types.ACTIVATE_CLIENTEESTACION_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class DesactivateClienteEstacion implements Action {
  readonly type = Types.DESACTIVATE_CLIENTEESTACION;
  constructor(public clienteestaciones: clienteestaciondesactivateRequest[]){}
}

export class DesactivateClienteEstacionSuccess implements Action {
  readonly type = Types.DESACTIVATE_CLIENTEESTACION_SUCCESS;
  constructor(public success: boolean){}
}

export class DesactivateClienteEstacionError implements Action {
  readonly type = Types.DESACTIVATE_CLIENTEESTACION_ERROR;
  constructor(public error: string) {}
}



export type All =
ReadClienteEstacionActiva | ReadClienteEstacionActivaSuccess | ReadClienteEstacionActivaError |
GetClienteEstacionbyid | GetClienteEstacionbyidSuccess | GetClienteEstacionbyidError |
GetClienteEstacionbyrut | GetClienteEstacionbyrutSuccess | GetClienteEstacionbyrutError |
CreateClienteEstacion | CreateClienteEstacionSuccess | CreateClienteEstacionError |
UpdateClienteEstacion | UpdateClienteEstacionSuccess | UpdateClienteEstacionError |
DeleteClienteEstacion | DeleteClienteEstacionSuccess | DeleteClienteEstacionError |
ActivateClienteEstacion | ActivateClienteEstacionSuccess | ActivateClienteEstacionError |
DesactivateClienteEstacion | DesactivateClienteEstacionSuccess | DesactivateClienteEstacionError 
