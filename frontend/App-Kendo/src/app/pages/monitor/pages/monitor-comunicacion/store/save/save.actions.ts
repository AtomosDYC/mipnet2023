import {Action} from '@ngrx/store';

import { MonitorcomunicacionResponse, MonitorcomunicacionRequest, MonitorcomunicacionbyidRequest } from './save.models';



import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";
import { getMonitorcomunicacionbyid } from './save.selectors';



export enum Types {
  READ_MONITOR_COMUNICACION = '[MONITOR_COMUNICACION] Read_Monitor_Comunicacion',
  READ_MONITOR_COMUNICACION_SUCCESS = '[MONITOR_COMUNICACION] Read_Monitor_Comunicacion:Success',
  READ_MONITOR_COMUNICACION_ERROR = '[MONITOR_COMUNICACION] Read_Monitor_Comunicacion:Error',

  CREATE_MONITOR_COMUNICACION = '[CREATE_MONITOR_COMUNICACION] create_monitor_comunicacion',
  CREATE_MONITOR_COMUNICACION_SUCCESS = '[CREATE_MONITOR_COMUNICACION] create_monitor_comunicacion:Success',
  CREATE_MONITOR_COMUNICACION_ERROR = '[CREATE_MONITOR_COMUNICACION] create_monitor_comunicacion:Error',

  DELETE_MONITOR_COMUNICACION = '[DELETE_MONITOR_COMUNICACION] Delete_monitor_comunicacion',
  DELETE_MONITOR_COMUNICACION_SUCCESS = '[DELETE_MONITOR_COMUNICACION] Delete_monitor_comunicacion:Success',
  DELETE_MONITOR_COMUNICACION_ERROR = '[DELETE_MONITOR_COMUNICACION] Delete_monitor_comunicacion:Error',

  GET_MONITOR_COMUNICACION = '[GET_MONITOR_COMUNICACION] Get_monitor_Comunicacion',
  GET_MONITOR_COMUNICACION_SUCCESS = '[GET_MONITOR_COMUNICACION] Get_monitor_Comunicacion:Success',
  GET_MONITOR_COMUNICACION_ERROR = '[GET_MONITOR_COMUNICACION] Get_monitor_Comunicacion:Error',

/*  
  
  UPDATE_MONITOR = '[UPDATE_MONITOR] Update_monitor',
  UPDATE_MONITOR_SUCCESS = '[UPDATE_MONITOR] Update_monitor:Success',
  UPDATE_MONITOR_ERROR = '[UPDATE_MONITOR] Update_monitor:Error',

*/
}

export class ReadMonitorcomunicacion implements Action {
  readonly type = Types.READ_MONITOR_COMUNICACION;
  constructor(public monitorcomunicacion: RequestState){}
}

export class ReadMonitorcomunicacionSuccess implements Action {
  readonly type = Types.READ_MONITOR_COMUNICACION_SUCCESS;
  constructor(public monitorcomunicacionsource: GridDataResult){}
}

export class ReadMonitorcomunicacionError implements Action {
  readonly type = Types.READ_MONITOR_COMUNICACION_ERROR;
  constructor(public error: string){}
}


export class GetMonitorCommunicacionbyid implements Action {
  readonly type = Types.GET_MONITOR_COMUNICACION;
  constructor(public requestbyid: MonitorcomunicacionbyidRequest){}
}

export class GetMonitorCommunicacionbyidSuccess implements Action {
  readonly type = Types.GET_MONITOR_COMUNICACION_SUCCESS;
  constructor(public monitorcomunicacion: MonitorcomunicacionResponse){}
}

export class GetMonitorCommunicacionbyidError implements Action {
  readonly type = Types.GET_MONITOR_COMUNICACION_ERROR;
  constructor(public error: string){}
}

export class CreateMonitorcomunicacion implements Action {
  readonly type = Types.CREATE_MONITOR_COMUNICACION;
  constructor(public monitorcomunicacion: MonitorcomunicacionRequest){}
}

export class CreateMonitorcomunicacionSuccess implements Action {
  readonly type = Types.CREATE_MONITOR_COMUNICACION_SUCCESS;
  constructor(public monitorcomunicacion: MonitorcomunicacionRequest , public success: boolean){}
}

export class CreateMonitorcomunicacionError implements Action {
  readonly type = Types.CREATE_MONITOR_COMUNICACION_ERROR;
  constructor(public error: string) {}
}


//eliminar
export class DeleteMonitorcomunicacion implements Action {
  readonly type = Types.DELETE_MONITOR_COMUNICACION;
  constructor(public requestbyid: MonitorcomunicacionbyidRequest){}
}

export class DeleteMonitorcomunicacionSuccess implements Action {
  readonly type = Types.DELETE_MONITOR_COMUNICACION_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteMonitorcomunicacionError implements Action {
  readonly type = Types.DELETE_MONITOR_COMUNICACION_ERROR;
  constructor(public error: string) {}
}



export type All =
  ReadMonitorcomunicacion | ReadMonitorcomunicacionSuccess |   ReadMonitorcomunicacionError
  | GetMonitorCommunicacionbyid | GetMonitorCommunicacionbyidSuccess | GetMonitorCommunicacionbyidError
  | CreateMonitorcomunicacion | CreateMonitorcomunicacionSuccess | CreateMonitorcomunicacionError
  | DeleteMonitorcomunicacion | DeleteMonitorcomunicacionSuccess | DeleteMonitorcomunicacionError