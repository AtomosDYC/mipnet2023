import {Action} from '@ngrx/store';
import { TipoFlujoCreateRequest, TipoFlujoResponse, TipoFlujosResponse, TipoFlujoUpdateRequest } from './save.models';


export enum Types {
  READ = '[TipoFlujo] Read',
  READ_SUCCESS = '[TipoFlujo] Read:Success',
  READ_ERROR = '[TipoFlujo] Read:Error',

  GET_TIPOFLUJO = '[GET] Get_tipoflujo',
  GET_TIPOFLUJO_SUCCESS = '[GET] Get_tipoflujo:Success',
  GET_TIPOFLUJO_ERROR = '[GET] Get_tipoflujo:Error',

  CREATE_TIPOFLUJO = '[CREATE] Create_TipoFlujo',
  CREATE_TIPOFLUJO_SUCCESS = '[CREATE] Create_TipoFlujo:Success',
  CREATE_TIPOFLUJO_ERROR = '[CREATE] Create_TipoFlujo:Error',

  DELETE_TIPOFLUJO = '[DELETE] dELETE',
  DELETE_TIPOFLUJO_SUCCESS = '[DELETE] tipoflujo Success',
  DELETE_TIPOFLUJO_ERROR = '[DELETE] tipoflujo Error',

  UPDATE_TIPOFLUJO = '[UPDATE] TipoFlujo',
  UPDATE_TIPOFLUJO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_TIPOFLUJO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_TIPOFLUJO = '[ACTIVATE] TipoFlujo',
  ACTIVATE_TIPOFLUJO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_TIPOFLUJO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_TIPOFLUJO = '[DESACTIVATE] TipoFlujo',
  DESACTIVATE_TIPOFLUJO_SUCCESS = '[DESACTIVATE] TipoFlujo Success',
  DESACTIVATE_TIPOFLUJO_ERROR = '[DESACTIVATE] TipoFlujo Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public tipoflujos: TipoFlujoResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TIPOFLUJO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TIPOFLUJO_SUCCESS;
  constructor(public tipoflujo: TipoFlujoResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TIPOFLUJO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TIPOFLUJO;
  constructor(public tipoflujo: TipoFlujoCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TIPOFLUJO_SUCCESS;
  constructor(public tipoflujo: TipoFlujoResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TIPOFLUJO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TIPOFLUJO;
  constructor(public tipoflujo: TipoFlujoResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TIPOFLUJO_SUCCESS;
  constructor(public tipoflujo: TipoFlujoResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TIPOFLUJO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TIPOFLUJO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TIPOFLUJO_SUCCESS;
  constructor(public tipoflujos: TipoFlujoResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TIPOFLUJO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TIPOFLUJO;
  constructor(public tipoflujos: TipoFlujoResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TIPOFLUJO_SUCCESS;
  constructor(public tipoflujos: TipoFlujoResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TIPOFLUJO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TIPOFLUJO;
  constructor(public tipoflujos: TipoFlujoResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TIPOFLUJO_SUCCESS;
  constructor(public tipoflujos: TipoFlujoResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TIPOFLUJO_ERROR;
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


