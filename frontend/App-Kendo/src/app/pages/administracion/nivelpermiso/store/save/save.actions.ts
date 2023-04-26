import {Action} from '@ngrx/store';
import { NivelPermisoCreateRequest, NivelPermisoResponse, NivelPermisosResponse, NivelPermisoUpdateRequest } from './save.models';


export enum Types {
  READ = '[NivelPermiso] Read',
  READ_SUCCESS = '[NivelPermiso] Read:Success',
  READ_ERROR = '[NivelPermiso] Read:Error',

  GET_NIVELPERMISO = '[GET] Get_nivelpermiso',
  GET_NIVELPERMISO_SUCCESS = '[GET] Get_nivelpermiso:Success',
  GET_NIVELPERMISO_ERROR = '[GET] Get_nivelpermiso:Error',

  CREATE_NIVELPERMISO = '[CREATE] Create_NivelPermiso',
  CREATE_NIVELPERMISO_SUCCESS = '[CREATE] Create_NivelPermiso:Success',
  CREATE_NIVELPERMISO_ERROR = '[CREATE] Create_NivelPermiso:Error',

  DELETE_NIVELPERMISO = '[DELETE] dELETE',
  DELETE_NIVELPERMISO_SUCCESS = '[DELETE] nivelpermiso Success',
  DELETE_NIVELPERMISO_ERROR = '[DELETE] nivelpermiso Error',

  UPDATE_NIVELPERMISO = '[UPDATE] NivelPermiso',
  UPDATE_NIVELPERMISO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_NIVELPERMISO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_NIVELPERMISO = '[ACTIVATE] NivelPermiso',
  ACTIVATE_NIVELPERMISO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_NIVELPERMISO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_NIVELPERMISO = '[DESACTIVATE] NivelPermiso',
  DESACTIVATE_NIVELPERMISO_SUCCESS = '[DESACTIVATE] NivelPermiso Success',
  DESACTIVATE_NIVELPERMISO_ERROR = '[DESACTIVATE] NivelPermiso Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public nivelpermisos: NivelPermisoResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_NIVELPERMISO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_NIVELPERMISO_SUCCESS;
  constructor(public nivelpermiso: NivelPermisoResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_NIVELPERMISO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_NIVELPERMISO;
  constructor(public nivelpermiso: NivelPermisoCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_NIVELPERMISO_SUCCESS;
  constructor(public nivelpermiso: NivelPermisoResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_NIVELPERMISO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_NIVELPERMISO;
  constructor(public nivelpermiso: NivelPermisoResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_NIVELPERMISO_SUCCESS;
  constructor(public nivelpermiso: NivelPermisoResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_NIVELPERMISO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_NIVELPERMISO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_NIVELPERMISO_SUCCESS;
  constructor(public nivelpermisos: NivelPermisoResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_NIVELPERMISO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_NIVELPERMISO;
  constructor(public nivelpermisos: NivelPermisoResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_NIVELPERMISO_SUCCESS;
  constructor(public nivelpermisos: NivelPermisoResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_NIVELPERMISO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_NIVELPERMISO;
  constructor(public nivelpermisos: NivelPermisoResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_NIVELPERMISO_SUCCESS;
  constructor(public nivelpermisos: NivelPermisoResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_NIVELPERMISO_ERROR;
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


