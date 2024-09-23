import {Action} from '@ngrx/store';

import { EstacionResponse, EstacionRequest, EstacionbyidRequest } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_ESTACION = '[ESTACION] Read_Estacion',
  READ_ESTACION_SUCCESS = '[ESTACION] Read_Estacion:Success',
  READ_ESTACION_ERROR = '[ESTACION] Read_Estacion:Error',

  CREATE_ESTACION = '[CREATE_ESTACION] create_ESTACION',
  CREATE_ESTACION_SUCCESS = '[CREATE_ESTACION] create_ESTACION:Success',
  CREATE_ESTACION_ERROR = '[CREATE_ESTACION] create_ESTACION:Error',

  DELETE_ESTACION = '[DELETE_ESTACION] Delete_ESTACION',
  DELETE_ESTACION_SUCCESS = '[DELETE_ESTACION] Delete_ESTACION:Success',
  DELETE_ESTACION_ERROR = '[DELETE_ESTACION] Delete_ESTACION:Error',

  GET_ESTACION_BYID = '[GET_ESTACION] Get_Estacion_byid',
  GET_ESTACION_BYID_SUCCESS = '[GET_ESTACION] Get_Estacion_byid:Success',
  GET_ESTACION_BYID_ERROR = '[GET_ESTACION] Get_Estacion_byid:Error',

}

export class ReadEstacion implements Action {
  readonly type = Types.READ_ESTACION;
  constructor(public Estacion: RequestState){}
}

export class ReadEstacionSuccess implements Action {
  readonly type = Types.READ_ESTACION_SUCCESS;
  constructor(public Estacionsource: GridDataResult){}
}

export class ReadEstacionError implements Action {
  readonly type = Types.READ_ESTACION_ERROR;
  constructor(public error: string){}
}


export class GetEstacionbyid implements Action {
  readonly type = Types.GET_ESTACION_BYID;
  constructor(public requestbyid: EstacionbyidRequest){}
}

export class GetEstacionbyidSuccess implements Action {
  readonly type = Types.GET_ESTACION_BYID_SUCCESS;
  constructor(public Estacion: EstacionResponse){}
}

export class GetEstacionbyidError implements Action {
  readonly type = Types.GET_ESTACION_BYID_ERROR;
  constructor(public error: string){}
}

export class CreateEstacion implements Action {
  readonly type = Types.CREATE_ESTACION;
  constructor(public Estacion: EstacionRequest){}
}

export class CreateEstacionSuccess implements Action {
  readonly type = Types.CREATE_ESTACION_SUCCESS;
  constructor(public Estacion: EstacionRequest , public success: boolean){}
}

export class CreateEstacionError implements Action {
  readonly type = Types.CREATE_ESTACION_ERROR;
  constructor(public error: string) {}
}


//eliminar
export class DeleteEstacion implements Action {
  readonly type = Types.DELETE_ESTACION;
  constructor(public requestbyid: EstacionbyidRequest){}
}

export class DeleteEstacionSuccess implements Action {
  readonly type = Types.DELETE_ESTACION_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteEstacionError implements Action {
  readonly type = Types.DELETE_ESTACION_ERROR;
  constructor(public error: string) {}
}


export type All =
  ReadEstacion | ReadEstacionSuccess |   ReadEstacionError
  | GetEstacionbyid | GetEstacionbyidSuccess | GetEstacionbyidError
  | CreateEstacion | CreateEstacionSuccess | CreateEstacionError
  | DeleteEstacion | DeleteEstacionSuccess | DeleteEstacionError