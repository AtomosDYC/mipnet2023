import {Action} from '@ngrx/store';


import { EspecieTemporadaResponse, EspecieTemporadaRequest, EspecieTemporadaRequestUpdate, EspecieTemporadaRequestActivate } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_ESPECIETEMPORADA = '[EspecieTemporada] Read_EspecieTemporada',
  READ_ESPECIETEMPORADA_SUCCESS = '[EspecieTemporada] Read_EspecieTemporada:Success',
  READ_ESPECIETEMPORADA_ERROR = '[EspecieTemporada] Read_EspecieTemporada:Error',

  GET_ESPECIETEMPORADA = '[GET_ESPECIETEMPORADA] Get_especietemporada',
  GET_ESPECIETEMPORADA_SUCCESS = '[GET_ESPECIETEMPORADA] Get_especietemporada:Success',
  GET_ESPECIETEMPORADA_ERROR = '[GET_ESPECIETEMPORADA] Get_especietemporada:Error',

  CREATE_ESPECIETEMPORADA = '[CREATE_ESPECIETEMPORADA] create_especietemporada',
  CREATE_ESPECIETEMPORADA_SUCCESS = '[CREATE_ESPECIETEMPORADA] create_especietemporada:Success',
  CREATE_ESPECIETEMPORADA_ERROR = '[CREATE_ESPECIETEMPORADA] Create_especietemporada:Error',
  
  UPDATE_ESPECIETEMPORADA = '[UPDATE_ESPECIETEMPORADA] Update_especietemporada',
  UPDATE_ESPECIETEMPORADA_SUCCESS = '[UPDATE_ESPECIETEMPORADA] Update_especietemporada:Success',
  UPDATE_ESPECIETEMPORADA_ERROR = '[UPDATE_ESPECIETEMPORADA] Update_especietemporada:Error',

  DELETE_ESPECIETEMPORADA = '[DELETE_ESPECIETEMPORADA] Delete_especietemporada',
  DELETE_ESPECIETEMPORADA_SUCCESS = '[DELETE_ESPECIETEMPORADA] Delete_especietemporada:Success',
  DELETE_ESPECIETEMPORADA_ERROR = '[DELETE_ESPECIETEMPORADA] Delete_especietemporada:Error',

  ACTIVATE_ESPECIETEMPORADA = '[ACTIVATE] Activate_especietemporada',
  ACTIVATE_ESPECIETEMPORADA_SUCCESS = '[ACTIVATE] Activate_especietemporada:Success',
  ACTIVATE_ESPECIETEMPORADA_ERROR = '[ACTIVATE] Activate_especietemporada:Error',

  DESACTIVATE_ESPECIETEMPORADA = '[DESACTIVATE] Desactivate_especietemporada',
  DESACTIVATE_ESPECIETEMPORADA_SUCCESS = '[DESACTIVATE] Desactivate_especietemporada:Success',
  DESACTIVATE_ESPECIETEMPORADA_ERROR = '[DESACTIVATE] Desactivate_especietemporada:Error',

}

export class ReadEspecieTemporada implements Action {
  readonly type = Types.READ_ESPECIETEMPORADA;
  constructor(public especietemporada: RequestState){}
}

export class ReadEspecieTemporadaSuccess implements Action {
  readonly type = Types.READ_ESPECIETEMPORADA_SUCCESS;
  constructor(public especietemporadasource: GridDataResult){}
}

export class ReadEspecieTemporadaError implements Action {
  readonly type = Types.READ_ESPECIETEMPORADA_ERROR;
  constructor(public error: string){}
}


export class GetEspecieTemporadabyid implements Action {
  readonly type = Types.GET_ESPECIETEMPORADA;
  constructor(public id: string){}
}

export class GetEspecieTemporadabyidSuccess implements Action {
  readonly type = Types.GET_ESPECIETEMPORADA_SUCCESS;
  constructor(public especietemporada: EspecieTemporadaResponse){}
}

export class GetEspecieTemporadabyidError implements Action {
  readonly type = Types.GET_ESPECIETEMPORADA_ERROR;
  constructor(public error: string){}
}


export class CreateEspecieTemporada implements Action {
  readonly type = Types.CREATE_ESPECIETEMPORADA;
  constructor(public especietemporada: EspecieTemporadaRequest){}
}

export class CreateEspecieTemporadaSuccess implements Action {
  readonly type = Types.CREATE_ESPECIETEMPORADA_SUCCESS;
  constructor(public especietemporada: EspecieTemporadaResponse , public success: boolean){}
}

export class CreateEspecieTemporadaError implements Action {
  readonly type = Types.CREATE_ESPECIETEMPORADA_ERROR;
  constructor(public error: string) {}
}



export class UpdateEspecieTemporada implements Action {
  readonly type = Types.UPDATE_ESPECIETEMPORADA;
  constructor(public especietemporada: EspecieTemporadaRequestUpdate){}
}

export class UpdateEspecieTemporadaSuccess implements Action {
  readonly type = Types.UPDATE_ESPECIETEMPORADA_SUCCESS;
  constructor( public success: boolean){}
}

export class UpdateEspecieTemporadaError implements Action {
  readonly type = Types.UPDATE_ESPECIETEMPORADA_ERROR;
  constructor(public error: string) {}
}



export class DeleteEspecieTemporada implements Action {
  readonly type = Types.DELETE_ESPECIETEMPORADA;
  constructor(public id: string){}
}

export class DeleteEspecieTemporadaSuccess implements Action {
  readonly type = Types.DELETE_ESPECIETEMPORADA_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteEspecieTemporadaError implements Action {
  readonly type = Types.DELETE_ESPECIETEMPORADA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class ActivateEspecieTemporada implements Action {
  readonly type = Types.ACTIVATE_ESPECIETEMPORADA;
  constructor(public especietemporadas: EspecieTemporadaRequestActivate[]){}
}


export class ActivateEspecieTemporadaSuccess implements Action {
  readonly type = Types.ACTIVATE_ESPECIETEMPORADA_SUCCESS;
  constructor(public success: boolean){}
}

export class ActivateEspecieTemporadaError implements Action {
  readonly type = Types.ACTIVATE_ESPECIETEMPORADA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class DesactivateEspecieTemporada implements Action {
  readonly type = Types.DESACTIVATE_ESPECIETEMPORADA;
  constructor(public especietemporadas: EspecieTemporadaRequestActivate[]){}
}

export class DesactivateEspecieTemporadaSuccess implements Action {
  readonly type = Types.DESACTIVATE_ESPECIETEMPORADA_SUCCESS;
  constructor(public success: boolean){}
}

export class DesactivateEspecieTemporadaError implements Action {
  readonly type = Types.DESACTIVATE_ESPECIETEMPORADA_ERROR;
  constructor(public error: string) {}
}

export type All =
  ReadEspecieTemporada | ReadEspecieTemporadaSuccess | ReadEspecieTemporadaError
  | GetEspecieTemporadabyid | GetEspecieTemporadabyidSuccess | GetEspecieTemporadabyidError
  | CreateEspecieTemporada | CreateEspecieTemporadaSuccess | CreateEspecieTemporadaError
  | UpdateEspecieTemporada | UpdateEspecieTemporadaSuccess | UpdateEspecieTemporadaError
  | DeleteEspecieTemporada | DeleteEspecieTemporadaSuccess | DeleteEspecieTemporadaError
  | DesactivateEspecieTemporada | DesactivateEspecieTemporadaSuccess | DesactivateEspecieTemporadaError
| ActivateEspecieTemporada | ActivateEspecieTemporadaSuccess | ActivateEspecieTemporadaError
  