import {Action} from '@ngrx/store';
import { TipoDocumentoCreateRequest, TipoDocumentoResponse, TipoDocumentosResponse, TipoDocumentoUpdateRequest } from './save.models';


export enum Types {
  READ = '[TipoDocumento] Read',
  READ_SUCCESS = '[TipoDocumento] Read:Success',
  READ_ERROR = '[TipoDocumento] Read:Error',

  GET_TIPODOCUMENTO = '[GET] Get_tipodocumento',
  GET_TIPODOCUMENTO_SUCCESS = '[GET] Get_tipodocumento:Success',
  GET_TIPODOCUMENTO_ERROR = '[GET] Get_tipodocumento:Error',

  CREATE_TIPODOCUMENTO = '[CREATE] Create_TipoDocumento',
  CREATE_TIPODOCUMENTO_SUCCESS = '[CREATE] Create_TipoDocumento:Success',
  CREATE_TIPODOCUMENTO_ERROR = '[CREATE] Create_TipoDocumento:Error',

  DELETE_TIPODOCUMENTO = '[DELETE] dELETE',
  DELETE_TIPODOCUMENTO_SUCCESS = '[DELETE] tipodocumento Success',
  DELETE_TIPODOCUMENTO_ERROR = '[DELETE] tipodocumento Error',

  UPDATE_TIPODOCUMENTO = '[UPDATE] TipoDocumento',
  UPDATE_TIPODOCUMENTO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_TIPODOCUMENTO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_TIPODOCUMENTO = '[ACTIVATE] TipoDocumento',
  ACTIVATE_TIPODOCUMENTO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_TIPODOCUMENTO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_TIPODOCUMENTO = '[DESACTIVATE] TipoDocumento',
  DESACTIVATE_TIPODOCUMENTO_SUCCESS = '[DESACTIVATE] TipoDocumento Success',
  DESACTIVATE_TIPODOCUMENTO_ERROR = '[DESACTIVATE] TipoDocumento Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public tipodocumentos: TipoDocumentoResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TIPODOCUMENTO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TIPODOCUMENTO_SUCCESS;
  constructor(public tipodocumento: TipoDocumentoResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TIPODOCUMENTO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TIPODOCUMENTO;
  constructor(public tipodocumento: TipoDocumentoCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TIPODOCUMENTO_SUCCESS;
  constructor(public tipodocumento: TipoDocumentoResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TIPODOCUMENTO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TIPODOCUMENTO;
  constructor(public tipodocumento: TipoDocumentoResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TIPODOCUMENTO_SUCCESS;
  constructor(public tipodocumento: TipoDocumentoResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TIPODOCUMENTO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TIPODOCUMENTO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TIPODOCUMENTO_SUCCESS;
  constructor(public tipodocumentos: TipoDocumentoResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TIPODOCUMENTO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TIPODOCUMENTO;
  constructor(public tipodocumentos: TipoDocumentoResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TIPODOCUMENTO_SUCCESS;
  constructor(public tipodocumentos: TipoDocumentoResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TIPODOCUMENTO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TIPODOCUMENTO;
  constructor(public tipodocumentos: TipoDocumentoResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TIPODOCUMENTO_SUCCESS;
  constructor(public tipodocumentos: TipoDocumentoResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TIPODOCUMENTO_ERROR;
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


