import {Action} from '@ngrx/store';
import {  ClienteUsuarioRequest, ClienteUsuarioResponse, ClienteUsuarioActivaSource, ClienteUsuarioRequestUpdate, clienteusuariodesactivateRequest, menuclienteusuarioRequest, MenuUsuarioResponse } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_CLIENTEUSUARIOACTIVA = '[ClienteUsuario] Read_ClienteUsuarioActiva',
  READ_CLIENTEUSUARIOACTIVA_SUCCESS = '[ClienteUsuario] Read_ClienteUsuarioActiva:Success',
  READ_CLIENTEUSUARIOACTIVA_ERROR = '[ClienteUsuario] Read_ClienteUsuarioActiva:Error',

  READ_CLIENTEUSUARIOINACTIVA = '[ClienteUsuario] Read_ClienteUsuarioInactiva',
  READ_CLIENTEUSUARIOINACTIVA_SUCCESS = '[ClienteUsuario] Read_ClienteUsuarioInactiva:Success',
  READ_CLIENTEUSUARIOINACTIVA_ERROR = '[ClienteUsuario] Read_ClienteUsuarioInactiva:Error',

  GET_CLIENTEUSUARIO_BYID = '[ClienteUsuario] Get_ClienteUsuario_byid',
  GET_CLIENTEUSUARIO_BYID_SUCCESS = '[ClienteUsuario] Get_ClienteUsuario_byid:Success',
  GET_CLIENTEUSUARIO_BYID_ERROR = '[ClienteUsuario] Get_ClienteUsuario_byid:Error',

  GET_CLIENTEUSUARIO_BYRUT = '[ClienteUsuario] Get_ClienteUsuario_byrut',
  GET_CLIENTEUSUARIO_BYRUT_SUCCESS = '[ClienteUsuario] Get_ClienteUsuario_byrut:Success',
  GET_CLIENTEUSUARIO_BYRUT_ERROR = '[ClienteUsuario] Get_ClienteUsuario_byrut:Error',

  CREATE_CLIENTEUSUARIO = '[ClienteUsuario] Create_ClienteUsuario',
  CREATE_CLIENTEUSUARIO_SUCCESS = '[ClienteUsuario] Create_ClienteUsuario:Success',
  CREATE_CLIENTEUSUARIO_ERROR = '[ClienteUsuario] Create_ClienteUsuario:Error',

  UPDATE_CLIENTEUSUARIO = '[ClienteUsuario] Update_ClienteUsuario',
  UPDATE_CLIENTEUSUARIO_SUCCESS = '[ClienteUsuario] Update_ClienteUsuario:Success',
  UPDATE_CLIENTEUSUARIO_ERROR = '[ClienteUsuario] Update_ClienteUsuario:Error',

  DELETE_CLIENTEUSUARIO = '[DELETE_CLIENTEUSUARIO] Delete_ClienteUsuario',
  DELETE_CLIENTEUSUARIO_SUCCESS = '[DELETE_CLIENTEUSUARIO] Delete_ClienteUsuario:Success',
  DELETE_CLIENTEUSUARIO_ERROR = '[DELETE_CLIENTEUSUARIO] Delete_ClienteUsuario:Error',

  ACTIVATE_CLIENTEUSUARIO = '[CLIENTEUSUARIO] activate_ClienteUsuario',
  ACTIVATE_CLIENTEUSUARIO_SUCCESS = '[CLIENTEUSUARIO] activate_ClienteUsuario:Success',
  ACTIVATE_CLIENTEUSUARIO_ERROR = '[CLIENTEUSUARIO] activate_ClienteUsuario:Error',

  DESACTIVATE_CLIENTEUSUARIO = '[CLIENTEUSUARIO] desactivate_ClienteUsuario',
  DESACTIVATE_CLIENTEUSUARIO_SUCCESS = '[CLIENTEUSUARIO] desactivate_ClienteUsuario:Success',
  DESACTIVATE_CLIENTEUSUARIO_ERROR = '[CLIENTEUSUARIO] desactivate_ClienteUsuario:Error',

  GET_CLIENTEUSUARIO_MENU = '[ClienteUsuario] Get_ClienteUsuario_menu',
  GET_CLIENTEUSUARIO_MENU_SUCCESS = '[ClienteUsuario] Get_ClienteUsuario_menu:Success',
  GET_CLIENTEUSUARIO_MENU_ERROR = '[ClienteUsuario] Get_ClienteUsuario_menu:Error',
  
}

export class ReadClienteUsuarioActiva implements Action {
  readonly type = Types.READ_CLIENTEUSUARIOACTIVA;
  constructor(public clienteusuario: RequestState){}
}

export class ReadClienteUsuarioActivaSuccess implements Action {
  readonly type = Types.READ_CLIENTEUSUARIOACTIVA_SUCCESS;
  constructor(public clienteusuarioactivasource: GridDataResult){}
}

export class ReadClienteUsuarioActivaError implements Action {
  readonly type = Types.READ_CLIENTEUSUARIOACTIVA_ERROR;
  constructor(public error: string){}
}

export class ReadClienteUsuarioInactiva implements Action {
  readonly type = Types.READ_CLIENTEUSUARIOINACTIVA;
  constructor(public clienteusuario: RequestState){}
}

export class ReadClienteUsuarioInactivaSuccess implements Action {
  readonly type = Types.READ_CLIENTEUSUARIOINACTIVA_SUCCESS;
  constructor(public clienteusuarioinactivasource: GridDataResult){}
}

export class ReadClienteUsuarioInactivaError implements Action {
  readonly type = Types.READ_CLIENTEUSUARIOINACTIVA_ERROR;
  constructor(public error: string){}
}



export class GetClienteUsuariobyid implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_BYID;
  constructor(public id: string){}
}

export class GetClienteUsuariobyidSuccess implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_BYID_SUCCESS;
  constructor(public clienteusuario: ClienteUsuarioResponse){}
}

export class GetClienteUsuariobyidError implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_BYID_ERROR;
  constructor(public error: string){}
}

export class GetClienteUsuariobyrut implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_BYRUT;
  constructor(public rut: string){}
}

export class GetClienteUsuariobyrutSuccess implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_BYRUT_SUCCESS;
  constructor(public clienteusuario: ClienteUsuarioResponse){}
}

export class GetClienteUsuariobyrutError implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_BYRUT_ERROR;
  constructor(public error: string){}
}


export class CreateClienteUsuario implements Action {
  readonly type = Types.CREATE_CLIENTEUSUARIO;
  constructor(public clienteusuario: ClienteUsuarioRequest){}
}

export class CreateClienteUsuarioSuccess implements Action {
  readonly type = Types.CREATE_CLIENTEUSUARIO_SUCCESS;
  constructor(public clienteusuario: ClienteUsuarioResponse , public success: boolean){}
}

export class CreateClienteUsuarioError implements Action {
  readonly type = Types.CREATE_CLIENTEUSUARIO_ERROR;
  constructor(public error: string) {}
}



export class UpdateClienteUsuario implements Action {
  readonly type = Types.UPDATE_CLIENTEUSUARIO;
  constructor(public clienteusuario: ClienteUsuarioRequestUpdate){}
}

export class UpdateClienteUsuarioSuccess implements Action {
  readonly type = Types.UPDATE_CLIENTEUSUARIO_SUCCESS;
  constructor(public clienteusuario: ClienteUsuarioResponse, public success: boolean){}
}

export class UpdateClienteUsuarioError implements Action {
  readonly type = Types.UPDATE_CLIENTEUSUARIO_ERROR;
  constructor(public error: string) {}
}

export class DeleteClienteUsuario implements Action {
  readonly type = Types.DELETE_CLIENTEUSUARIO;
  constructor(public id: string){}
}

export class DeleteClienteUsuarioSuccess implements Action {
  readonly type = Types.DELETE_CLIENTEUSUARIO_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteClienteUsuarioError implements Action {
  readonly type = Types.DELETE_CLIENTEUSUARIO_ERROR;
  constructor(public error: string) {}
}


//desactivar
export class ActivateClienteUsuario implements Action {
  readonly type = Types.ACTIVATE_CLIENTEUSUARIO;
  constructor(public clienteusuarios: clienteusuariodesactivateRequest[]){}
}

export class ActivateClienteUsuarioSuccess implements Action {
  readonly type = Types.ACTIVATE_CLIENTEUSUARIO_SUCCESS;
  constructor(public success: boolean){}
}

export class ActivateClienteUsuarioError implements Action {
  readonly type = Types.ACTIVATE_CLIENTEUSUARIO_ERROR;
  constructor(public error: string) {}
}
  

//desactivar
export class DesactivateClienteUsuario implements Action {
  readonly type = Types.DESACTIVATE_CLIENTEUSUARIO;
  constructor(public clienteusuarios: clienteusuariodesactivateRequest[]){}
}

export class DesactivateClienteUsuarioSuccess implements Action {
  readonly type = Types.DESACTIVATE_CLIENTEUSUARIO_SUCCESS;
  constructor(public success: boolean){}
}

export class DesactivateClienteUsuarioError implements Action {
  readonly type = Types.DESACTIVATE_CLIENTEUSUARIO_ERROR;
  constructor(public error: string) {}
}
  
export class GetClienteUsuariomenu implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_MENU;
  constructor(public menuclienteusuario: menuclienteusuarioRequest){}
}

export class GetClienteUsuariomenuSuccess implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_MENU_SUCCESS;
  constructor(public menuestacion: MenuUsuarioResponse[]){}
}

export class GetClienteUsuariomenuError implements Action {
  readonly type = Types.GET_CLIENTEUSUARIO_MENU_ERROR;
  constructor(public error: string){}
}
  
export type All =
ReadClienteUsuarioActiva | ReadClienteUsuarioActivaSuccess | ReadClienteUsuarioActivaError |
ReadClienteUsuarioInactiva | ReadClienteUsuarioInactivaSuccess | ReadClienteUsuarioInactivaError | 
GetClienteUsuariobyid | GetClienteUsuariobyidSuccess | GetClienteUsuariobyidError |
GetClienteUsuariobyrut | GetClienteUsuariobyrutSuccess | GetClienteUsuariobyrutError |
CreateClienteUsuario | CreateClienteUsuarioSuccess | CreateClienteUsuarioError |
UpdateClienteUsuario | UpdateClienteUsuarioSuccess | UpdateClienteUsuarioError |
DeleteClienteUsuario | DeleteClienteUsuarioSuccess | DeleteClienteUsuarioError | 
GetClienteUsuariomenu | GetClienteUsuariomenuSuccess | GetClienteUsuariomenuError |
ActivateClienteUsuario | ActivateClienteUsuarioSuccess | ActivateClienteUsuarioError |
DesactivateClienteUsuario | DesactivateClienteUsuarioSuccess | DesactivateClienteUsuarioError 
