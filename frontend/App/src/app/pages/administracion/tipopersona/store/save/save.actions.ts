import {Action} from '@ngrx/store';
import { TipoPersonaCreateRequest, TipoPersonaResponse, TipoPersonasResponse, TipoPersonaUpdateRequest } from './save.models';


export enum Types {
  READ = '[TipoPersona] Read',
  READ_SUCCESS = '[TipoPersona] Read:Success',
  READ_ERROR = '[TipoPersona] Read:Error',

  GET_TIPOPERSONA = '[GET] Get_tipopersona',
  GET_TIPOPERSONA_SUCCESS = '[GET] Get_tipopersona:Success',
  GET_TIPOPERSONA_ERROR = '[GET] Get_tipopersona:Error',

  CREATE_TIPOPERSONA = '[CREATE] Create_TipoPersona',
  CREATE_TIPOPERSONA_SUCCESS = '[CREATE] Create_TipoPersona:Success',
  CREATE_TIPOPERSONA_ERROR = '[CREATE] Create_TipoPersona:Error',

  DELETE_TIPOPERSONA = '[DELETE] dELETE',
  DELETE_TIPOPERSONA_SUCCESS = '[DELETE] tipopersona Success',
  DELETE_TIPOPERSONA_ERROR = '[DELETE] tipopersona Error',

  UPDATE_TIPOPERSONA = '[UPDATE] TipoPersona',
  UPDATE_TIPOPERSONA_SUCCESS = '[UPDATE] Game Success',
  UPDATE_TIPOPERSONA_ERROR = '[UPDATE] Game Error',

  ACTIVATE_TIPOPERSONA = '[ACTIVATE] TipoPersona',
  ACTIVATE_TIPOPERSONA_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_TIPOPERSONA_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_TIPOPERSONA = '[DESACTIVATE] TipoPersona',
  DESACTIVATE_TIPOPERSONA_SUCCESS = '[DESACTIVATE] TipoPersona Success',
  DESACTIVATE_TIPOPERSONA_ERROR = '[DESACTIVATE] TipoPersona Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public tipopersonas: TipoPersonaResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TIPOPERSONA;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TIPOPERSONA_SUCCESS;
  constructor(public tipopersona: TipoPersonaResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TIPOPERSONA_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TIPOPERSONA;
  constructor(public tipopersona: TipoPersonaCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TIPOPERSONA_SUCCESS;
  constructor(public tipopersona: TipoPersonaResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TIPOPERSONA_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TIPOPERSONA;
  constructor(public tipopersona: TipoPersonaResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TIPOPERSONA_SUCCESS;
  constructor(public tipopersona: TipoPersonaResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TIPOPERSONA_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TIPOPERSONA;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TIPOPERSONA_SUCCESS;
  constructor(public tipopersonas: TipoPersonaResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TIPOPERSONA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TIPOPERSONA;
  constructor(public tipopersonas: TipoPersonaResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TIPOPERSONA_SUCCESS;
  constructor(public tipopersonas: TipoPersonaResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TIPOPERSONA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TIPOPERSONA;
  constructor(public tipopersonas: TipoPersonaResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TIPOPERSONA_SUCCESS;
  constructor(public tipopersonas: TipoPersonaResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TIPOPERSONA_ERROR;
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


