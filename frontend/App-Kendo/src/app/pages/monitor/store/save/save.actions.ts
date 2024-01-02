import {Action} from '@ngrx/store';


import { MonitorResponse, MonitorRequest, MonitoresResponse, MonitorRequestUpdate, monitordesactivateRequest } from './save.models';
import { PersonaResponse, PersonaBuscarRutRequest } from './save.models';

import { Monitor } from '../../../../models/backend/monitor';
import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_MONITOR = '[Moniror] Read_Moniror',
  READ_MONITOR_SUCCESS = '[Moniror] Read_Moniror:Success',
  READ_MONITOR_ERROR = '[Moniror] Read_Moniror:Error',

  GET_MONITOR = '[GET_MONITOR] Get_monitor',
  GET_MONITOR_SUCCESS = '[GET_MONITOR] Get_monitor:Success',
  GET_MONITOR_ERROR = '[GET_MONITOR] Get_monitor:Error',

  GET_MONITOR_BYRUT = '[GET_MONITOR_BYRUT] Get_monitor_byrut',
  GET_MONITOR_BYRUT_SUCCESS = '[GET_MONITOR_BYRUT] Get_monitor_byrut:Success',
  GET_MONITOR_BYRUT_ERROR = '[GET_MONITOR_BYRUT] Get_monitor_byrut:Error',

  CREATE_MONITOR = '[CREATE_MONITOR] create_monitor',
  CREATE_MONITOR_SUCCESS = '[CREATE_MONITOR] create_monitor:Success',
  CREATE_MONITOR_ERROR = '[CREATE_MONITOR] Create_monitor:Error',
  
  UPDATE_MONITOR = '[UPDATE_MONITOR] Update_monitor',
  UPDATE_MONITOR_SUCCESS = '[UPDATE_MONITOR] Update_monitor:Success',
  UPDATE_MONITOR_ERROR = '[UPDATE_MONITOR] Update_monitor:Error',

  DELETE_MONITOR = '[DELETE_MONITOR] Delete_monitor',
  DELETE_MONITOR_SUCCESS = '[DELETE_MONITOR] Delete_monitor:Success',
  DELETE_MONITOR_ERROR = '[DELETE_MONITOR] Delete_monitor:Error',

  ACTIVATE_MONITOR = '[MONITOR] activate_monitor',
  ACTIVATE_MONITOR_SUCCESS = '[MONITOR] activate_monitor:Success',
  ACTIVATE_MONITOR_ERROR = '[MONITOR] activate_monitor:Error',

  DESACTIVATE_MONITOR = '[MONITOR] desactivate_monitor',
  DESACTIVATE_MONITOR_SUCCESS = '[MONITOR] desactivate_monitor:Success',
  DESACTIVATE_MONITOR_ERROR = '[MONITOR] desactivate_monitor:Error',

}

export class ReadMonitor implements Action {
  readonly type = Types.READ_MONITOR;
  constructor(public monitor: RequestState){}
}

export class ReadMonitorSuccess implements Action {
  readonly type = Types.READ_MONITOR_SUCCESS;
  constructor(public monitorsource: GridDataResult){}
}

export class ReadMonitorError implements Action {
  readonly type = Types.READ_MONITOR_ERROR;
  constructor(public error: string){}
}

export class GetMonitorbyid implements Action {
  readonly type = Types.GET_MONITOR;
  constructor(public id: string){}
}

export class GetMonitorbyidSuccess implements Action {
  readonly type = Types.GET_MONITOR_SUCCESS;
  constructor(public monitor: MonitorResponse){}
}

export class GetMonitorbyidError implements Action {
  readonly type = Types.GET_MONITOR_ERROR;
  constructor(public error: string){}
}



export class GetMonitorbyrut implements Action {
  readonly type = Types.GET_MONITOR_BYRUT;
  constructor(public persona: PersonaBuscarRutRequest){}
}

export class GetMonitorbyrutSuccess implements Action {
  readonly type = Types.GET_MONITOR_BYRUT_SUCCESS;
  constructor(public persona: PersonaResponse){}
}

export class GetMonitorbyrutError implements Action {
  readonly type = Types.GET_MONITOR_ERROR;
  constructor(public error: string){}
}



export class CreateMonitor implements Action {
  readonly type = Types.CREATE_MONITOR;
  constructor(public monitor: MonitorRequest){}
}

export class CreateMonitorSuccess implements Action {
  readonly type = Types.CREATE_MONITOR_SUCCESS;
  constructor(public monitor: MonitorResponse , public success: boolean){}
}

export class CreateMonitorError implements Action {
  readonly type = Types.CREATE_MONITOR_ERROR;
  constructor(public error: string) {}
}



export class UpdateMonitor implements Action {
  readonly type = Types.UPDATE_MONITOR;
  constructor(public monitor: MonitorRequestUpdate){}
}

export class UpdateMonitorSuccess implements Action {
  readonly type = Types.UPDATE_MONITOR_SUCCESS;
  constructor(public monitor: MonitorResponse, public success: boolean){}
}

export class UpdateMonitorError implements Action {
  readonly type = Types.UPDATE_MONITOR_ERROR;
  constructor(public error: string) {}
}



export class DeleteMonitor implements Action {
  readonly type = Types.DELETE_MONITOR;
  constructor(public id: string){}
}

export class DeleteMonitorSuccess implements Action {
  readonly type = Types.DELETE_MONITOR_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteMonitorError implements Action {
  readonly type = Types.DELETE_MONITOR_ERROR;
  constructor(public error: string) {}
}


//desactivar
export class Activatemonitor implements Action {
  readonly type = Types.ACTIVATE_MONITOR;
  constructor(public monitores: monitordesactivateRequest[]){}
}


export class ActivatemonitorSuccess implements Action {
  readonly type = Types.ACTIVATE_MONITOR_SUCCESS;
  constructor(public success: boolean){}
}

export class ActivatemonitorError implements Action {
  readonly type = Types.ACTIVATE_MONITOR_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class DesactivateMonitor implements Action {
  readonly type = Types.DESACTIVATE_MONITOR;
  constructor(public monitores: monitordesactivateRequest[]){}
}

export class DesactivateMonitorSuccess implements Action {
  readonly type = Types.DESACTIVATE_MONITOR_SUCCESS;
  constructor(public success: boolean){}
}

export class DesactivateMonitorError implements Action {
  readonly type = Types.DESACTIVATE_MONITOR_ERROR;
  constructor(public error: string) {}
}




export type All =
  ReadMonitor | ReadMonitorSuccess | ReadMonitorError
  | GetMonitorbyid | GetMonitorbyidSuccess | GetMonitorbyidError
  | GetMonitorbyrut | GetMonitorbyrutSuccess | GetMonitorbyrutError
  | CreateMonitor | CreateMonitorSuccess | CreateMonitorError
  | UpdateMonitor | UpdateMonitorSuccess | UpdateMonitorError
  | DeleteMonitor | DeleteMonitorSuccess | DeleteMonitorError
  | Activatemonitor | ActivatemonitorSuccess | ActivatemonitorError
  | DesactivateMonitor | DesactivateMonitorSuccess | DesactivateMonitorError