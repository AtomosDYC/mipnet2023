import {Action} from '@ngrx/store';
import { ZonaCreateRequest, ZonaResponse, ZonasResponse, ZonaUpdateRequest } from './save.models';


export enum Types {
  READ = '[zona] Read',
  READ_SUCCESS = '[zona] Read:Success',
  READ_ERROR = '[zona] Read:Error',

  GET_ZONA = '[GET] Get_ZONA',
  GET_ZONA_SUCCESS = '[GET] Get_ZONA:Success',
  GET_ZONA_ERROR = '[GET] Get_ZONA:Error',

  CREATE_ZONA = '[CREATE] Create_ZONA',
  CREATE_ZONA_SUCCESS = '[CREATE] Create_ZONA:Success',
  CREATE_ZONA_ERROR = '[CREATE] Create_ZONA:Error',

  DELETE_ZONA = '[DELETE] dELETE',
  DELETE_ZONA_SUCCESS = '[DELETE] zona Success',
  DELETE_ZONA_ERROR = '[DELETE] zona Error',

  UPDATE_ZONA = '[UPDATE] zona',
  UPDATE_ZONA_SUCCESS = '[UPDATE] Game Success',
  UPDATE_ZONA_ERROR = '[UPDATE] Game Error',

  ACTIVATE_ZONA = '[ACTIVATE] zona',
  ACTIVATE_ZONA_SUCCESS = '[ACTIVATE] zona Success',
  ACTIVATE_ZONA_ERROR = '[ACTIVATE] zona Error',

  DESACTIVATE_ZONA = '[DESACTIVATE] zona',
  DESACTIVATE_ZONA_SUCCESS = '[DESACTIVATE] zona Success',
  DESACTIVATE_ZONA_ERROR = '[DESACTIVATE] zona Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public zonas: ZonaResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_ZONA;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_ZONA_SUCCESS;
  constructor(public zona: ZonaResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_ZONA_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_ZONA;
  constructor(public zona: ZonaCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_ZONA_SUCCESS;
  constructor(public zona: ZonaResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_ZONA_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_ZONA;
  constructor(public zona: ZonaResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_ZONA_SUCCESS;
  constructor(public zona: ZonaResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_ZONA_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_ZONA;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_ZONA_SUCCESS;
  constructor(public zonas: ZonaResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_ZONA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_ZONA;
  constructor(public zonas: ZonaResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_ZONA_SUCCESS;
  constructor(public zonas: ZonaResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_ZONA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_ZONA;
  constructor(public zonas: ZonaResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_ZONA_SUCCESS;
  constructor(public zonas: ZonaResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_ZONA_ERROR;
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


