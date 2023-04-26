import {Action} from '@ngrx/store';
import { TipoPermisoCreateRequest, TipoPermisoResponse, TipoPermisosResponse, TipoPermisoUpdateRequest } from './save.models';


export enum Types {
  READ = '[TipoPermiso] Read',
  READ_SUCCESS = '[TipoPermiso] Read:Success',
  READ_ERROR = '[TipoPermiso] Read:Error',

  GET_TIPOPERMISO = '[GET] Get_tipopermiso',
  GET_TIPOPERMISO_SUCCESS = '[GET] Get_tipopermiso:Success',
  GET_TIPOPERMISO_ERROR = '[GET] Get_tipopermiso:Error',

  CREATE_TIPOPERMISO = '[CREATE] Create_TipoPermiso',
  CREATE_TIPOPERMISO_SUCCESS = '[CREATE] Create_TipoPermiso:Success',
  CREATE_TIPOPERMISO_ERROR = '[CREATE] Create_TipoPermiso:Error',

  DELETE_TIPOPERMISO = '[DELETE] dELETE',
  DELETE_TIPOPERMISO_SUCCESS = '[DELETE] tipopermiso Success',
  DELETE_TIPOPERMISO_ERROR = '[DELETE] tipopermiso Error',

  UPDATE_TIPOPERMISO = '[UPDATE] TipoPermiso',
  UPDATE_TIPOPERMISO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_TIPOPERMISO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_TIPOPERMISO = '[ACTIVATE] TipoPermiso',
  ACTIVATE_TIPOPERMISO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_TIPOPERMISO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_TIPOPERMISO = '[DESACTIVATE] TipoPermiso',
  DESACTIVATE_TIPOPERMISO_SUCCESS = '[DESACTIVATE] TipoPermiso Success',
  DESACTIVATE_TIPOPERMISO_ERROR = '[DESACTIVATE] TipoPermiso Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public tipopermisos: TipoPermisoResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TIPOPERMISO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TIPOPERMISO_SUCCESS;
  constructor(public tipopermiso: TipoPermisoResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TIPOPERMISO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TIPOPERMISO;
  constructor(public tipopermiso: TipoPermisoCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TIPOPERMISO_SUCCESS;
  constructor(public tipopermiso: TipoPermisoResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TIPOPERMISO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TIPOPERMISO;
  constructor(public tipopermiso: TipoPermisoResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TIPOPERMISO_SUCCESS;
  constructor(public tipopermiso: TipoPermisoResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TIPOPERMISO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TIPOPERMISO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TIPOPERMISO_SUCCESS;
  constructor(public tipopermisos: TipoPermisoResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TIPOPERMISO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TIPOPERMISO;
  constructor(public tipopermisos: TipoPermisoResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TIPOPERMISO_SUCCESS;
  constructor(public tipopermisos: TipoPermisoResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TIPOPERMISO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TIPOPERMISO;
  constructor(public tipopermisos: TipoPermisoResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TIPOPERMISO_SUCCESS;
  constructor(public tipopermisos: TipoPermisoResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TIPOPERMISO_ERROR;
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


