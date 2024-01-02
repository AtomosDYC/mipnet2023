import {Action} from '@ngrx/store';

import { MonitorespecieResponse, MonitorespecieRequest } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_MONITOR_ESPECIE = '[MONITOR_ESPECIE] Read_Monitor_Especie',
  READ_MONITOR_ESPECIE_SUCCESS = '[MONITOR_ESPECIE] Read_Monitor_Especie:Success',
  READ_MONITOR_ESPECIE_ERROR = '[MONITOR_ESPECIE] Read_Monitor_Especie:Error',


  CREATE_MONITOR_ESPECIE = '[CREATE_MONITOR_ESPECIE] create_monitor_especie',
  CREATE_MONITOR_ESPECIE_SUCCESS = '[CREATE_MONITOR_ESPECIE] create_monitor_especie:Success',
  CREATE_MONITOR_ESPECIE_ERROR = '[CREATE_MONITOR_ESPECIE] create_monitor_especie:Error',

  DELETE_MONITOR_ESPECIE = '[DELETE_MONITOR_ESPECIE] Delete_monitor_especie',
  DELETE_MONITOR_ESPECIE_SUCCESS = '[DELETE_MONITOR_ESPECIE] Delete_monitor_especie:Success',
  DELETE_MONITOR_ESPECIE_ERROR = '[DELETE_MONITOR_ESPECIE] Delete_monitor_especie:Error',

  GET_MONITOR_ESPECIE = '[GET_MONITOR_ESPECIE] Get_monitor_Especie',
  GET_MONITOR_ESPECIE_SUCCESS = '[GET_MONITOR_ESPECIE] Get_monitor_Especie:Success',
  GET_MONITOR_ESPECIE_ERROR = '[GET_MONITOR_ESPECIE] Get_monitor_Especie:Error',

/*  
  
  UPDATE_MONITOR = '[UPDATE_MONITOR] Update_monitor',
  UPDATE_MONITOR_SUCCESS = '[UPDATE_MONITOR] Update_monitor:Success',
  UPDATE_MONITOR_ERROR = '[UPDATE_MONITOR] Update_monitor:Error',

*/
}

export class ReadMonitorespecie implements Action {
  readonly type = Types.READ_MONITOR_ESPECIE;
  constructor(public monitorespecie: RequestState){}
}

export class ReadMonitorespecieSuccess implements Action {
  readonly type = Types.READ_MONITOR_ESPECIE_SUCCESS;
  constructor(public monitorespeciesource: GridDataResult){}
}

export class ReadMonitorespecieError implements Action {
  readonly type = Types.READ_MONITOR_ESPECIE_ERROR;
  constructor(public error: string){}
}

/*
export class GetMonitorCommunicacionbyid implements Action {
  readonly type = Types.GET_MONITOR_ESPECIE;
  constructor(public requestbyid: MonitorespeciebyidRequest){}
}

export class GetMonitorCommunicacionbyidSuccess implements Action {
  readonly type = Types.GET_MONITOR_ESPECIE_SUCCESS;
  constructor(public monitorespecie: MonitorespecieResponse){}
}

export class GetMonitorCommunicacionbyidError implements Action {
  readonly type = Types.GET_MONITOR_ESPECIE_ERROR;
  constructor(public error: string){}
}

*/

export class CreateMonitorespecie implements Action {
  readonly type = Types.CREATE_MONITOR_ESPECIE;
  constructor(public monitorespecie: MonitorespecieRequest){}
}

export class CreateMonitorespecieSuccess implements Action {
  readonly type = Types.CREATE_MONITOR_ESPECIE_SUCCESS;
  constructor(public success: boolean){}
}

export class CreateMonitorespecieError implements Action {
  readonly type = Types.CREATE_MONITOR_ESPECIE_ERROR;
  constructor(public error: string) {}
}


//eliminar
export class DeleteMonitorespecie implements Action {
  readonly type = Types.DELETE_MONITOR_ESPECIE;
  constructor(public monitorespecie: MonitorespecieRequest){}
}

export class DeleteMonitorespecieSuccess implements Action {
  readonly type = Types.DELETE_MONITOR_ESPECIE_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteMonitorespecieError implements Action {
  readonly type = Types.DELETE_MONITOR_ESPECIE_ERROR;
  constructor(public error: string) {}
}

export type All =
  ReadMonitorespecie | ReadMonitorespecieSuccess |   ReadMonitorespecieError
  | CreateMonitorespecie | CreateMonitorespecieSuccess | CreateMonitorespecieError
  | DeleteMonitorespecie | DeleteMonitorespecieSuccess | DeleteMonitorespecieError
  /*
  | GetMonitorCommunicacionbyid | GetMonitorCommunicacionbyidSuccess | GetMonitorCommunicacionbyidError
  
  
  */