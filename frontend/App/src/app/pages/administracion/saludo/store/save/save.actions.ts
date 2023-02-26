import {Action} from '@ngrx/store';
import { SaludoCreateRequest, SaludoResponse, SaludosResponse, SaludoUpdateRequest } from './save.models';


export enum Types {
  READ = '[Saludo] Read',
  READ_SUCCESS = '[Saludo] Read:Success',
  READ_ERROR = '[Saludo] Read:Error',

  GET_SALUDO = '[GET] Get_saludo',
  GET_SALUDO_SUCCESS = '[GET] Get_saludo:Success',
  GET_SALUDO_ERROR = '[GET] Get_saludo:Error',

  CREATE_SALUDO = '[CREATE] Create_Saludo',
  CREATE_SALUDO_SUCCESS = '[CREATE] Create_Saludo:Success',
  CREATE_SALUDO_ERROR = '[CREATE] Create_Saludo:Error',

  DELETE_SALUDO = '[DELETE] dELETE',
  DELETE_SALUDO_SUCCESS = '[DELETE] saludo Success',
  DELETE_SALUDO_ERROR = '[DELETE] saludo Error',

  UPDATE_SALUDO = '[UPDATE] Saludo',
  UPDATE_SALUDO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_SALUDO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_SALUDO = '[ACTIVATE] Saludo',
  ACTIVATE_SALUDO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_SALUDO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_SALUDO = '[DESACTIVATE] Saludo',
  DESACTIVATE_SALUDO_SUCCESS = '[DESACTIVATE] Saludo Success',
  DESACTIVATE_SALUDO_ERROR = '[DESACTIVATE] Saludo Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public saludos: SaludoResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_SALUDO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_SALUDO_SUCCESS;
  constructor(public saludo: SaludoResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_SALUDO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_SALUDO;
  constructor(public saludo: SaludoCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_SALUDO_SUCCESS;
  constructor(public saludo: SaludoResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_SALUDO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_SALUDO;
  constructor(public saludo: SaludoResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_SALUDO_SUCCESS;
  constructor(public saludo: SaludoResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_SALUDO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_SALUDO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_SALUDO_SUCCESS;
  constructor(public saludos: SaludoResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_SALUDO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_SALUDO;
  constructor(public saludos: SaludoResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_SALUDO_SUCCESS;
  constructor(public saludos: SaludoResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_SALUDO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_SALUDO;
  constructor(public saludos: SaludoResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_SALUDO_SUCCESS;
  constructor(public saludos: SaludoResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_SALUDO_ERROR;
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


