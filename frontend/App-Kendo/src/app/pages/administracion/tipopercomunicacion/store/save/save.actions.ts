import {Action} from '@ngrx/store';
import { TipoPerComunicacionCreateRequest, TipoPerComunicacionResponse, TipoPerComunicacionesResponse } from './save.models';


export enum Types {
  READ = '[TipoPerComunicacion] Read',
  READ_SUCCESS = '[TipoPerComunicacion] Read:Success',
  READ_ERROR = '[TipoPerComunicacion] Read:Error',

  GET_TIPOPERCOMUNICACION = '[GET] Get_tipopercomunicacion',
  GET_TIPOPERCOMUNICACION_SUCCESS = '[GET] Get_tipopercomunicacion:Success',
  GET_TIPOPERCOMUNICACION_ERROR = '[GET] Get_tipopercomunicacion:Error',

  CREATE_TIPOPERCOMUNICACION = '[CREATE] Create_TipoPerComunicacion',
  CREATE_TIPOPERCOMUNICACION_SUCCESS = '[CREATE] Create_TipoPerComunicacion:Success',
  CREATE_TIPOPERCOMUNICACION_ERROR = '[CREATE] Create_TipoPerComunicacion:Error',

  DELETE_TIPOPERCOMUNICACION = '[DELETE] delete_tipopercomunicacion',
  DELETE_TIPOPERCOMUNICACION_SUCCESS = '[DELETE] delete_tipopercomunicacion:Success',
  DELETE_TIPOPERCOMUNICACION_ERROR = '[DELETE] delete_tipopercomunicacion:Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public tipopercomunicaciones: TipoPerComunicacionResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}



export class Getbyid implements Action {
  readonly type = Types.GET_TIPOPERCOMUNICACION;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TIPOPERCOMUNICACION_SUCCESS;
  constructor(public tipopercomunicaciones: TipoPerComunicacionResponse[], ){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TIPOPERCOMUNICACION_ERROR;
  constructor(public error: string){}
}



export class Create implements Action {
  readonly type = Types.CREATE_TIPOPERCOMUNICACION;
  constructor(public tipopercomunicacion: TipoPerComunicacionCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TIPOPERCOMUNICACION_SUCCESS;
  constructor(public tipopercomunicaciones: TipoPerComunicacionResponse[], public success: boolean){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TIPOPERCOMUNICACION_ERROR;
  constructor(public error: string) {}
}



//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TIPOPERCOMUNICACION;
  constructor(public tipopercomunicacion: TipoPerComunicacionCreateRequest){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TIPOPERCOMUNICACION_SUCCESS;
  constructor(public tipopercomunicaciones: TipoPerComunicacionResponse[], public success: boolean){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TIPOPERCOMUNICACION_ERROR;
  constructor(public error: string) {}
}





export type All =
  Read | ReadSuccess | ReadError
| Getbyid | GetbyidSuccess | GetbyidError
| Create | CreateSuccess | CreateError
| Delete | DeleteSuccess | DeleteError


