import {Action} from '@ngrx/store';
import { ComunaCreateRequest, ComunaResponse, ComunasResponse, ComunaUpdateRequest } from './save.models';


export enum Types {
  READ = '[COMUNA] Read',
  READ_SUCCESS = '[COMUNA] Read:Success',
  READ_ERROR = '[COMUNA] Read:Error',

  GET_COMUNA = '[GET] Get_COMUNA',
  GET_COMUNA_SUCCESS = '[GET] Get_COMUNA:Success',
  GET_COMUNA_ERROR = '[GET] Get_COMUNA:Error',

  CREATE_COMUNA = '[CREATE] Create_COMUNA',
  CREATE_COMUNA_SUCCESS = '[CREATE] Create_COMUNA:Success',
  CREATE_COMUNA_ERROR = '[CREATE] Create_COMUNA:Error',

  DELETE_COMUNA = '[DELETE] dELETE',
  DELETE_COMUNA_SUCCESS = '[DELETE] COMUNA Success',
  DELETE_COMUNA_ERROR = '[DELETE] COMUNA Error',

  UPDATE_COMUNA = '[UPDATE] COMUNA',
  UPDATE_COMUNA_SUCCESS = '[UPDATE] Game Success',
  UPDATE_COMUNA_ERROR = '[UPDATE] Game Error',

  ACTIVATE_COMUNA = '[ACTIVATE] COMUNA',
  ACTIVATE_COMUNA_SUCCESS = '[ACTIVATE] COMUNA Success',
  ACTIVATE_COMUNA_ERROR = '[ACTIVATE] COMUNA Error',

  DESACTIVATE_COMUNA = '[DESACTIVATE] COMUNA',
  DESACTIVATE_COMUNA_SUCCESS = '[DESACTIVATE] COMUNA Success',
  DESACTIVATE_COMUNA_ERROR = '[DESACTIVATE] COMUNA Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public comunas: ComunaResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_COMUNA;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_COMUNA_SUCCESS;
  constructor(public comuna: ComunaResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_COMUNA_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_COMUNA;
  constructor(public comuna: ComunaCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_COMUNA_SUCCESS;
  constructor(public comuna: ComunaResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_COMUNA_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_COMUNA;
  constructor(public comuna: ComunaResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_COMUNA_SUCCESS;
  constructor(public comuna: ComunaResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_COMUNA_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_COMUNA;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_COMUNA_SUCCESS;
  constructor(public comunas: ComunaResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_COMUNA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_COMUNA;
  constructor(public comunas: ComunaResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_COMUNA_SUCCESS;
  constructor(public comunas: ComunaResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_COMUNA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_COMUNA;
  constructor(public comunas: ComunaResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_COMUNA_SUCCESS;
  constructor(public comunas: ComunaResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_COMUNA_ERROR;
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


