import {Action} from '@ngrx/store';
import { NivelFlujoCreateRequest, NivelFlujoResponse, NivelFlujosResponse, NivelFlujoUpdateRequest } from './save.models';


export enum Types {
  READ = '[NivelFlujo] Read',
  READ_SUCCESS = '[NivelFlujo] Read:Success',
  READ_ERROR = '[NivelFlujo] Read:Error',

  GET_NIVELFLUJO = '[GET] Get_nivelflujo',
  GET_NIVELFLUJO_SUCCESS = '[GET] Get_nivelflujo:Success',
  GET_NIVELFLUJO_ERROR = '[GET] Get_nivelflujo:Error',

  CREATE_NIVELFLUJO = '[CREATE] Create_NivelFlujo',
  CREATE_NIVELFLUJO_SUCCESS = '[CREATE] Create_NivelFlujo:Success',
  CREATE_NIVELFLUJO_ERROR = '[CREATE] Create_NivelFlujo:Error',

  DELETE_NIVELFLUJO = '[DELETE] dELETE',
  DELETE_NIVELFLUJO_SUCCESS = '[DELETE] nivelflujo Success',
  DELETE_NIVELFLUJO_ERROR = '[DELETE] nivelflujo Error',

  UPDATE_NIVELFLUJO = '[UPDATE] NivelFlujo',
  UPDATE_NIVELFLUJO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_NIVELFLUJO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_NIVELFLUJO = '[ACTIVATE] NivelFlujo',
  ACTIVATE_NIVELFLUJO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_NIVELFLUJO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_NIVELFLUJO = '[DESACTIVATE] NivelFlujo',
  DESACTIVATE_NIVELFLUJO_SUCCESS = '[DESACTIVATE] NivelFlujo Success',
  DESACTIVATE_NIVELFLUJO_ERROR = '[DESACTIVATE] NivelFlujo Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public nivelflujos: NivelFlujoResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_NIVELFLUJO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_NIVELFLUJO_SUCCESS;
  constructor(public nivelflujo: NivelFlujoResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_NIVELFLUJO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_NIVELFLUJO;
  constructor(public nivelflujo: NivelFlujoCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_NIVELFLUJO_SUCCESS;
  constructor(public nivelflujo: NivelFlujoResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_NIVELFLUJO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_NIVELFLUJO;
  constructor(public nivelflujo: NivelFlujoResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_NIVELFLUJO_SUCCESS;
  constructor(public nivelflujo: NivelFlujoResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_NIVELFLUJO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_NIVELFLUJO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_NIVELFLUJO_SUCCESS;
  constructor(public nivelflujos: NivelFlujoResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_NIVELFLUJO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_NIVELFLUJO;
  constructor(public nivelflujos: NivelFlujoResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_NIVELFLUJO_SUCCESS;
  constructor(public nivelflujos: NivelFlujoResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_NIVELFLUJO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_NIVELFLUJO;
  constructor(public nivelflujos: NivelFlujoResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_NIVELFLUJO_SUCCESS;
  constructor(public nivelflujos: NivelFlujoResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_NIVELFLUJO_ERROR;
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


