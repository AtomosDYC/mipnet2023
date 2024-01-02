import {Action} from '@ngrx/store';
import { TemporadaBaseResponse, TemporadaBasesCreaterequest, TemporadaBasesResponse } from './save.models';


export enum Types {
  READ = '[TemporadaBase] Read',
  READ_SUCCESS = '[TemporadaBase] Read:Success',
  READ_ERROR = '[TemporadaBase] Read:Error',

  GET_TEMPORADABASE = '[GET] Get_temporadabase',
  GET_TEMPORADABASE_SUCCESS = '[GET] Get_temporadabase:Success',
  GET_TEMPORADABASE_ERROR = '[GET] Get_temporadabase:Error',

  CREATE_TEMPORADABASE = '[CREATE] Create_temporadabase',
  CREATE_TEMPORADABASE_SUCCESS = '[CREATE] Create_temporadabase:Success',
  CREATE_TEMPORADABASE_ERROR = '[CREATE] Create_temporadabase:Error',

  DELETE_TEMPORADABASE = '[DELETE] Delete_temporadabase',
  DELETE_TEMPORADABASE_SUCCESS = '[DELETE] Delete_temporadabase:Success',
  DELETE_TEMPORADABASE_ERROR = '[DELETE] Delete_temporadabase:Error',

  UPDATE_TEMPORADABASE = '[UPDATE] Update_temporadabase',
  UPDATE_TEMPORADABASE_SUCCESS = '[UPDATE] Update_temporadabase:Success',
  UPDATE_TEMPORADABASE_ERROR = '[UPDATE] Update_temporadabase:Error',

  ACTIVATE_TEMPORADABASE = '[ACTIVATE] Activate_temporadabase',
  ACTIVATE_TEMPORADABASE_SUCCESS = '[ACTIVATE] Activate_temporadabase:Success',
  ACTIVATE_TEMPORADABASE_ERROR = '[ACTIVATE] Activate_temporadabase:Error',

  DESACTIVATE_TEMPORADABASE = '[DESACTIVATE] Desactivate_temporadabase',
  DESACTIVATE_TEMPORADABASE_SUCCESS = '[DESACTIVATE] Desactivate_temporadabase:Success',
  DESACTIVATE_TEMPORADABASE_ERROR = '[DESACTIVATE] Desactivate_temporadabase:Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public temporadabases: TemporadaBaseResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TEMPORADABASE;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TEMPORADABASE_SUCCESS;
  constructor(public temporadabase: TemporadaBaseResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TEMPORADABASE_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TEMPORADABASE;
  constructor(public temporadabase: TemporadaBasesCreaterequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabase: TemporadaBaseResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TEMPORADABASE;
  constructor(public temporadabase: TemporadaBaseResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabase: TemporadaBaseResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TEMPORADABASE;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabases: TemporadaBaseResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TEMPORADABASE;
  constructor(public temporadabases: TemporadaBaseResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabases: TemporadaBaseResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADABASE;
  constructor(public temporadabases: TemporadaBaseResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabases: TemporadaBaseResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADABASE_ERROR;
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


