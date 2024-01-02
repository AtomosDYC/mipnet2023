import {Action} from '@ngrx/store';
import {  MonitorAccesoResponse, MonitorAccesoRequest } from './save.models';



export enum Types {

  GET_MONITOR_ACCESO = '[GET_MONITOR_ACCESO] Get_monitor_acceso',
  GET_MONITOR_ACCESO_SUCCESS = '[GET_MONITOR_ACCESO] Get_monitor_acceso:Success',
  GET_MONITOR_ACCESO_ERROR = '[GET_MONITOR_ACCESO] Get_monitor_acceso:Error',

  CREATE_MONITOR_ACCESO = '[CREATE_MONITOR_ACCESO] create_monitor_acceso',
  CREATE_MONITOR_ACCESO_SUCCESS = '[CREATE_MONITOR_ACCESO] create_monitor_acceso:Success',
  CREATE_MONITOR_ACCESO_ERROR = '[CREATE_MONITOR_ACCESO] Create_monitor_acceso:Error',
  
  UPDATE_MONITOR_ACCESO = '[UPDATE_MONITOR_ACCESO] Update_monitor_acceso',
  UPDATE_MONITOR_ACCESO_SUCCESS = '[UPDATE_MONITOR_ACCESO] Update_monitor_acceso:Success',
  UPDATE_MONITOR_ACCESO_ERROR = '[UPDATE_MONITOR_ACCESO] Update_monitor_acceso:Error',

}


export class GetMonitorAcceso implements Action {
  readonly type = Types.GET_MONITOR_ACCESO;
  constructor(public id: string){}
}

export class GetMonitorAccesoSuccess implements Action {
  readonly type = Types.GET_MONITOR_ACCESO_SUCCESS;
  constructor(public monitoracceso: MonitorAccesoResponse){}
}

export class GetMonitorAccesoError implements Action {
  readonly type = Types.GET_MONITOR_ACCESO_ERROR;
  constructor(public error: string){}
}



export class CreateMonitorAcceso implements Action {
  readonly type = Types.CREATE_MONITOR_ACCESO;
  constructor(public monitoracceso: MonitorAccesoRequest){}
}

export class CreateMonitorAccesoSuccess implements Action {
  readonly type = Types.CREATE_MONITOR_ACCESO_SUCCESS;
  constructor(public monitoracceso: MonitorAccesoResponse , public success: boolean){}
}

export class CreateMonitorAccesoError implements Action {
  readonly type = Types.CREATE_MONITOR_ACCESO_ERROR;
  constructor(public error: string) {}
}

export class UpdateMonitorAcceso implements Action {
  readonly type = Types.UPDATE_MONITOR_ACCESO;
  constructor(public monitoracceso: MonitorAccesoRequest){}
}

export class UpdateMonitorAccesoSuccess implements Action {
  readonly type = Types.UPDATE_MONITOR_ACCESO_SUCCESS;
  constructor(public monitoracceso: MonitorAccesoResponse, public success: boolean){}
}

export class UpdateMonitorAccesoError implements Action {
  readonly type = Types.UPDATE_MONITOR_ACCESO_ERROR;
  constructor(public error: string) {}
}


export type All =
  | GetMonitorAcceso | GetMonitorAccesoSuccess | GetMonitorAccesoError
  | CreateMonitorAcceso | CreateMonitorAccesoSuccess | CreateMonitorAccesoError
  | UpdateMonitorAcceso | UpdateMonitorAccesoSuccess | UpdateMonitorAccesoError
