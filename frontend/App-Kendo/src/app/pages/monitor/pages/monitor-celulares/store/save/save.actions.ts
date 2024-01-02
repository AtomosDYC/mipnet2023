import {Action} from '@ngrx/store';

import { MonitorSincronizacionResponse, MonitorSincronizacionRequest } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_MONITOR_SINCRONIZACION = '[MONITOR_SINCRONIZACION] Read_Monitor_Sincronizacion',
  READ_MONITOR_SINCRONIZACION_SUCCESS = '[MONITOR_SINCRONIZACION] Read_Monitor_Sincronizacion:Success',
  READ_MONITOR_SINCRONIZACION_ERROR = '[MONITOR_SINCRONIZACION] Read_Monitor_Sincronizacion:Error',

  SINCRONIZAR_MONITOR_TRAMPA = '[MONITOR_SINCRONIZACION] sincronizar_monitor_trampa',
  SINCRONIZAR_MONITOR_TRAMPA_SUCCESS = '[MONITOR_SINCRONIZACION] sincronizar_monitor_trampa:Success',
  SINCRONIZAR_MONITOR_TRAMPA_ERROR = '[MONITOR_SINCRONIZACION] sincronizar_monitor_trampa:Error',

}

export class ReadMonitorsincronizacion implements Action {
  readonly type = Types.READ_MONITOR_SINCRONIZACION;
  constructor(public monitorsincronizacion: RequestState){}
}

export class ReadMonitorsincronizacionSuccess implements Action {
  readonly type = Types.READ_MONITOR_SINCRONIZACION_SUCCESS;
  constructor(public monitorsincronizacionsource: GridDataResult){}
}

export class ReadMonitorsincronizacionError implements Action {
  readonly type = Types.READ_MONITOR_SINCRONIZACION_ERROR;
  constructor(public error: string){}
}

export class SincronizarMonitortrampa implements Action {
  readonly type = Types.SINCRONIZAR_MONITOR_TRAMPA;
  constructor(public monitorId: string){}
}

export class SincronizarMonitortrampaSuccess implements Action {
  readonly type = Types.SINCRONIZAR_MONITOR_TRAMPA_SUCCESS;
  constructor(public success: boolean){}
}

export class SincronizarMonitortrampaError implements Action {
  readonly type = Types.SINCRONIZAR_MONITOR_TRAMPA_ERROR;
  constructor(public error: string) {}
}



export type All =
  ReadMonitorsincronizacion | ReadMonitorsincronizacionSuccess | ReadMonitorsincronizacionError
  | SincronizarMonitortrampa | SincronizarMonitortrampaSuccess | SincronizarMonitortrampaError
 