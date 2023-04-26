import {Action} from '@ngrx/store';
import { UsuarioRegistroCreateRequest, UsuarioResponse } from './save.models';
import { usuarioregistros } from '../../../../../models/backend/usuario/index';


export enum Types {
  READ = '[Usuario] Read',
  READ_SUCCESS = '[Usuario] Read:Success',
  READ_ERROR = '[Usuario] Read:Error',

  CREATE_USUARIOREGISTRO = '[CREATE] Create_UsuarioRegistro',
  CREATE_USUARIOREGISTRO_SUCCESS = '[CREATE] Create_UsuarioRegistro:Success',
  CREATE_USUARIOREGISTRO_ERROR = '[CREATE] Create_UsuarioRegistro:Error',

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



export type All =
  Read | ReadSuccess | ReadError
  | Create | CreateSuccess | CreateError


