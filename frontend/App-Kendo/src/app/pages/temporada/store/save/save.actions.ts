import {Action} from '@ngrx/store';
import { TemporadaResponse, TemporadaCreaterequest, TemporadasResponse } from './save.models';


export enum Types {
  READ = '[Temporada] Read',
  READ_SUCCESS = '[Temporada] Read:Success',
  READ_ERROR = '[Temporada] Read:Error',

  GET_TEMPORADA = '[GET] Get_temporada',
  GET_TEMPORADA_SUCCESS = '[GET] Get_temporada:Success',
  GET_TEMPORADA_ERROR = '[GET] Get_temporada:Error',

  CREATE_TEMPORADA = '[CREATE] Create_temporada',
  CREATE_TEMPORADA_SUCCESS = '[CREATE] Create_temporada:Success',
  CREATE_TEMPORADA_ERROR = '[CREATE] Create_temporada:Error',

  DELETE_TEMPORADA = '[DELETE] Delete_temporada',
  DELETE_TEMPORADA_SUCCESS = '[DELETE] Delete_temporada:Success',
  DELETE_TEMPORADA_ERROR = '[DELETE] Delete_temporada:Error',

  UPDATE_TEMPORADA = '[UPDATE] Update_temporada',
  UPDATE_TEMPORADA_SUCCESS = '[UPDATE] Update_temporada:Success',
  UPDATE_TEMPORADA_ERROR = '[UPDATE] Update_temporada:Error',

  ACTIVATE_TEMPORADA = '[ACTIVATE] Activate_temporada',
  ACTIVATE_TEMPORADA_SUCCESS = '[ACTIVATE] Activate_temporada:Success',
  ACTIVATE_TEMPORADA_ERROR = '[ACTIVATE] Activate_temporada:Error',

  DESACTIVATE_TEMPORADA = '[DESACTIVATE] Desactivate_temporada',
  DESACTIVATE_TEMPORADA_SUCCESS = '[DESACTIVATE] Desactivate_temporada:Success',
  DESACTIVATE_TEMPORADA_ERROR = '[DESACTIVATE] Desactivate_temporada:Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public temporadas: TemporadaResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TEMPORADA;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TEMPORADA_SUCCESS;
  constructor(public temporada: TemporadaResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TEMPORADA_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TEMPORADA;
  constructor(public temporada: TemporadaCreaterequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TEMPORADA_SUCCESS;
  constructor(public temporada: TemporadaResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TEMPORADA_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TEMPORADA;
  constructor(public temporada: TemporadaResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TEMPORADA_SUCCESS;
  constructor(public temporada: TemporadaResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TEMPORADA_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TEMPORADA;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TEMPORADA_SUCCESS;
  constructor(public temporadas: TemporadaResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TEMPORADA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TEMPORADA;
  constructor(public temporadas: TemporadaResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TEMPORADA_SUCCESS;
  constructor(public temporadas: TemporadaResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TEMPORADA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADA;
  constructor(public temporadas: TemporadaResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADA_SUCCESS;
  constructor(public temporadas: TemporadaResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADA_ERROR;
  constructor(public error: string) {}
}

export type All =
  Read | ReadSuccess | ReadError
| Getbyid | GetbyidSuccess | GetbyidError
| Create | CreateSuccess | CreateError
| Update | UpdateSuccess | UpdateError
| Delete | DeleteSuccess | DeleteError
| Desactivate | DesactivateSuccess | DesactivateError
| Activate | ActivateSuccess | ActivateError


