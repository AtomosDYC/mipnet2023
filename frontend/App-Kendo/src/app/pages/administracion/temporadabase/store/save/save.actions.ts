import {Action} from '@ngrx/store';
import { TemporadaBaseResponse, TemporadaBasesCreaterequest, TemporadaBasesResponse, TemporadabasedesactivateResponse } from './save.models';
import { GridDataResult } from '@progress/kendo-angular-grid';

import { State as RequestState } from "@progress/kendo-data-query";

export enum Types {
  READ_TEMPORADABASE = '[TemporadaBase] Read',
  READ_TEMPORADABASE_SUCCESS = '[TemporadaBase] Read:Success',
  READ_TEMPORADABASE_ERROR = '[TemporadaBase] Read:Error',

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

export class Readtemporadabase implements Action {
  readonly type = Types.READ_TEMPORADABASE;
  constructor(public temporadabase: RequestState){}
}

export class ReadtemporadabaseSuccess implements Action {
  readonly type = Types.READ_TEMPORADABASE_SUCCESS;
  constructor(public temporadabasesource: GridDataResult){}
}

export class ReadtemporadabaseError implements Action {
  readonly type = Types.READ_TEMPORADABASE_ERROR;
  constructor(public error: string){}
}

export class Getbyidtemporadabase implements Action {
  readonly type = Types.GET_TEMPORADABASE;
  constructor(public id: string){}
}

export class GetbyidtemporadabaseSuccess implements Action {
  readonly type = Types.GET_TEMPORADABASE_SUCCESS;
  constructor(public temporadabase: TemporadaBaseResponse){}
}

export class GetbyidtemporadabaseError implements Action {
  readonly type = Types.GET_TEMPORADABASE_ERROR;
  constructor(public error: string){}
}

export class Createtemporadabase implements Action {
  readonly type = Types.CREATE_TEMPORADABASE;
  constructor(public temporadabase: TemporadaBasesCreaterequest){}
}

export class CreatetemporadabaseSuccess implements Action {
  readonly type = Types.CREATE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabase: TemporadaBaseResponse){}
}

export class CreatetemporadabaseError implements Action {
  readonly type = Types.CREATE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

export class Updatetemporadabase implements Action {
  readonly type = Types.UPDATE_TEMPORADABASE;
  constructor(public temporadabase: TemporadaBaseResponse){}
}

export class UpdatetemporadabaseSuccess implements Action {
  readonly type = Types.UPDATE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabase: TemporadaBaseResponse){}
}

export class UpdatetemporadabaseError implements Action {
  readonly type = Types.UPDATE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Deletetemporadabase implements Action {
  readonly type = Types.DELETE_TEMPORADABASE;
  constructor(public id: string){}
}

export class DeletetemporadabaseSuccess implements Action {
  readonly type = Types.DELETE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabases: TemporadaBaseResponse[]){}
}

export class DeletetemporadabaseError implements Action {
  readonly type = Types.DELETE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activatetemporadabase implements Action {
  readonly type = Types.ACTIVATE_TEMPORADABASE;
  constructor(public temporadabases: TemporadabasedesactivateResponse){}
}


export class ActivatetemporadabaseSuccess implements Action {
  readonly type = Types.ACTIVATE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabasesource: GridDataResult){}
}

export class ActivatetemporadabaseError implements Action {
  readonly type = Types.ACTIVATE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivatetemporadabase implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADABASE;
  constructor(public temporadabases: TemporadabasedesactivateResponse){}
}

export class DesactivatetemporadabaseSuccess implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADABASE_SUCCESS;
  constructor(public temporadabasesource: GridDataResult){}
}

export class DesactivatetemporadabaseError implements Action {
  readonly type = Types.DESACTIVATE_TEMPORADABASE_ERROR;
  constructor(public error: string) {}
}

export type All =
  Readtemporadabase | ReadtemporadabaseSuccess | ReadtemporadabaseError
| Getbyidtemporadabase | GetbyidtemporadabaseSuccess | GetbyidtemporadabaseError
| Createtemporadabase | CreatetemporadabaseSuccess | CreatetemporadabaseError
| Updatetemporadabase | UpdatetemporadabaseSuccess | UpdatetemporadabaseError
| Deletetemporadabase | DeletetemporadabaseSuccess | DeletetemporadabaseError
| Desactivatetemporadabase | DesactivatetemporadabaseSuccess | DesactivatetemporadabaseError
| Activatetemporadabase | ActivatetemporadabaseSuccess | ActivatetemporadabaseError


