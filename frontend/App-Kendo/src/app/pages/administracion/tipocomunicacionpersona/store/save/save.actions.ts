import {Action} from '@ngrx/store';
import { TipoComPersonaCreateRequest, TipoComPersonaResponse, TipoComPersonasResponse, TipoComPersonaUpdateRequest } from './save.models';


export enum Types {
  READ = '[TipoComPersona] Read',
  READ_SUCCESS = '[TipoComPersona] Read:Success',
  READ_ERROR = '[TipoComPersona] Read:Error',

  GET_TIPOCOMPERSONA = '[GET] Get_tipocompersona',
  GET_TIPOCOMPERSONA_SUCCESS = '[GET] Get_tipocompersona:Success',
  GET_TIPOCOMPERSONA_ERROR = '[GET] Get_tipocompersona:Error',

  CREATE_TIPOCOMPERSONA = '[CREATE] Create_TipoComPersona',
  CREATE_TIPOCOMPERSONA_SUCCESS = '[CREATE] Create_TipoComPersona:Success',
  CREATE_TIPOCOMPERSONA_ERROR = '[CREATE] Create_TipoComPersona:Error',

  DELETE_TIPOCOMPERSONA = '[DELETE] dELETE',
  DELETE_TIPOCOMPERSONA_SUCCESS = '[DELETE] tipocompersona Success',
  DELETE_TIPOCOMPERSONA_ERROR = '[DELETE] tipocompersona Error',

  UPDATE_TIPOCOMPERSONA = '[UPDATE] TipoComPersona',
  UPDATE_TIPOCOMPERSONA_SUCCESS = '[UPDATE] Game Success',
  UPDATE_TIPOCOMPERSONA_ERROR = '[UPDATE] Game Error',

  ACTIVATE_TIPOCOMPERSONA = '[ACTIVATE] TipoComPersona',
  ACTIVATE_TIPOCOMPERSONA_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_TIPOCOMPERSONA_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_TIPOCOMPERSONA = '[DESACTIVATE] TipoComPersona',
  DESACTIVATE_TIPOCOMPERSONA_SUCCESS = '[DESACTIVATE] TipoComPersona Success',
  DESACTIVATE_TIPOCOMPERSONA_ERROR = '[DESACTIVATE] TipoComPersona Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public tipocompersonas: TipoComPersonaResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TIPOCOMPERSONA;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TIPOCOMPERSONA_SUCCESS;
  constructor(public tipocompersona: TipoComPersonaResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TIPOCOMPERSONA_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TIPOCOMPERSONA;
  constructor(public tipocompersona: TipoComPersonaCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TIPOCOMPERSONA_SUCCESS;
  constructor(public tipocompersona: TipoComPersonaResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TIPOCOMPERSONA_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TIPOCOMPERSONA;
  constructor(public tipocompersona: TipoComPersonaResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TIPOCOMPERSONA_SUCCESS;
  constructor(public tipocompersona: TipoComPersonaResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TIPOCOMPERSONA_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TIPOCOMPERSONA;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TIPOCOMPERSONA_SUCCESS;
  constructor(public tipocompersonas: TipoComPersonaResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TIPOCOMPERSONA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TIPOCOMPERSONA;
  constructor(public tipocompersonas: TipoComPersonaResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TIPOCOMPERSONA_SUCCESS;
  constructor(public tipocompersonas: TipoComPersonaResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TIPOCOMPERSONA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TIPOCOMPERSONA;
  constructor(public tipocompersonas: TipoComPersonaResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TIPOCOMPERSONA_SUCCESS;
  constructor(public tipocompersonas: TipoComPersonaResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TIPOCOMPERSONA_ERROR;
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


