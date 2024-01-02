import {Action} from '@ngrx/store';
import { UsuarioRegistroCreateRequest, UsuarioResponse, UsuarioRegistroUpdateRequest } from './save.models';
import { usuarioregistros } from '../../../../../models/backend/usuario/index';


export enum Types {
  READ = '[Usuario] Read',
  READ_SUCCESS = '[Usuario] Read:Success',
  READ_ERROR = '[Usuario] Read:Error',

  GET_USUARIOREGISTRO = '[GET] Get_UsuarioRegistro',
  GET_USUARIOREGISTRO_SUCCESS = '[GET] Get_UsuarioRegistro:Success',
  GET_USUARIOREGISTRO_ERROR = '[GET] Get_UsuarioRegistro:Error',

  CREATE_USUARIOREGISTRO = '[CREATE] Create_UsuarioRegistro',
  CREATE_USUARIOREGISTRO_SUCCESS = '[CREATE] Create_UsuarioRegistro:Success',
  CREATE_USUARIOREGISTRO_ERROR = '[CREATE] Create_UsuarioRegistro:Error',

  UPDATE_USUARIOREGISTRO = '[UPDATE] Update_UsuarioRegistro',
  UPDATE_USUARIOREGISTRO_SUCCESS = '[UPDATE] Update_UsuarioRegistro:Success',
  UPDATE_USUARIOREGISTRO_ERROR = '[UPDATE] Update_UsuarioRegistro:Error',

  SEND_MAILCONFIRMATION = '[SEND] send_mailconfirmation',
  SEND_MAILCONFIRMATION_SUCCESS = '[SEND] send_mailconfirmation:Success',
  SEND_MAILCONFIRMATION_ERROR = '[SEND] send_mailconfirmation:Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public usuarioregistros: UsuarioResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_USUARIOREGISTRO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_USUARIOREGISTRO_SUCCESS;
  constructor(public usuarioregistro: UsuarioResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_USUARIOREGISTRO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_USUARIOREGISTRO;
  constructor(public usuarioregistro: UsuarioRegistroCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_USUARIOREGISTRO_SUCCESS;
  constructor(public usuarioregistros: UsuarioResponse[]){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_USUARIOREGISTRO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_USUARIOREGISTRO;
  constructor(public usuarioregistro: UsuarioRegistroUpdateRequest){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_USUARIOREGISTRO_SUCCESS;
  constructor(public usuarioregistros: UsuarioResponse[]){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_USUARIOREGISTRO_ERROR;
  constructor(public error: string) {}
}

export class Send implements Action {
  readonly type = Types.SEND_MAILCONFIRMATION;
  constructor(public id: string){}
}

export class SendSuccess implements Action {
  readonly type = Types.SEND_MAILCONFIRMATION_SUCCESS;
  constructor(public success:boolean){}
}

export class SendError implements Action {
  readonly type = Types.SEND_MAILCONFIRMATION_ERROR;
  constructor(public error: string){}
}


export type All =
  Read | ReadSuccess | ReadError
  | Getbyid | GetbyidSuccess | GetbyidError
  | Create | CreateSuccess | CreateError
  | Update | UpdateSuccess | UpdateError
  | Send | SendSuccess | SendError



