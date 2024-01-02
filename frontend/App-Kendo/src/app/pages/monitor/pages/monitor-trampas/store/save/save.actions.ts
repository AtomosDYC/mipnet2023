import {Action} from '@ngrx/store';

import { MonitortrampaResponse, MonitortrampaRequest } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_MONITOR_TRAMPA = '[MONITOR_TRAMPA] Read_Monitor_Trampa',
  READ_MONITOR_TRAMPA_SUCCESS = '[MONITOR_TRAMPA] Read_Monitor_Trampa:Success',
  READ_MONITOR_TRAMPA_ERROR = '[MONITOR_TRAMPA] Read_Monitor_Trampa:Error',


  ASIGNAR_MONITOR_TRAMPA = '[CREATE_MONITOR_TRAMPA] asignar_monitor_trampa',
  ASIGNAR_MONITOR_TRAMPA_SUCCESS = '[CREATE_MONITOR_TRAMPA] asignar_monitor_trampa:Success',
  ASIGNAR_MONITOR_TRAMPA_ERROR = '[CREATE_MONITOR_TRAMPA] asignar_monitor_trampa:Error',

  DELETE_MONITOR_TRAMPA = '[DELETE_MONITOR_TRAMPA] Delete_monitor_trampa',
  DELETE_MONITOR_TRAMPA_SUCCESS = '[DELETE_MONITOR_TRAMPA] Delete_monitor_trampa:Success',
  DELETE_MONITOR_TRAMPA_ERROR = '[DELETE_MONITOR_TRAMPA] Delete_monitor_trampa:Error',

  GET_MONITOR_TRAMPA = '[GET_MONITOR_TRAMPA] Get_monitor_Trampa',
  GET_MONITOR_TRAMPA_SUCCESS = '[GET_MONITOR_TRAMPA] Get_monitor_Trampa:Success',
  GET_MONITOR_TRAMPA_ERROR = '[GET_MONITOR_TRAMPA] Get_monitor_Trampa:Error',

  GET_MONITOR_BUSCAR_TRAMPA = '[GET_MONITOR_BUSCAR_TRAMPA] Get_monitor_buscar_Trampa',
  GET_MONITOR_BUSCAR_TRAMPA_SUCCESS = '[GET_MONITOR_BUSCAR_TRAMPA] Get_monitor_buscar_Trampa:Success',
  GET_MONITOR_BUSCAR_TRAMPA_ERROR = '[GET_MONITOR_BUSCAR_TRAMPA] Get_monitor_buscar_Trampa:Error',

  REPLICAR_TEMPORADA_MONITOR = '[MONITOR] replicar_temporada_monitor',
  REPLICAR_TEMPORADA_MONITOR_SUCCESS = '[MONITOR] replicar_temporada_monitor:Success', 
  REPLICAR_TEMPORADA_MONITOR_ERROR = '[MONITOR] replicar_temporada_monitor:Error',

}

export class ReadMonitortrampa implements Action {
  readonly type = Types.READ_MONITOR_TRAMPA;
  constructor(public monitortrampa: RequestState){}
}

export class ReadMonitortrampaSuccess implements Action {
  readonly type = Types.READ_MONITOR_TRAMPA_SUCCESS;
  constructor(public monitortrampasource: GridDataResult){}
}

export class ReadMonitortrampaError implements Action {
  readonly type = Types.READ_MONITOR_TRAMPA_ERROR;
  constructor(public error: string){}
}


export class GetMonitorbuscartrampa implements Action {
  readonly type = Types.GET_MONITOR_BUSCAR_TRAMPA;
  constructor(public monitortrampa: RequestState){}
}

export class GetMonitorbuscartrampaSuccess implements Action {
  readonly type = Types.GET_MONITOR_BUSCAR_TRAMPA_SUCCESS;
  constructor(public monitortrampabuscarsource: GridDataResult){}
}

export class GetMonitorbuscartrampaError implements Action {
  readonly type = Types.GET_MONITOR_BUSCAR_TRAMPA_ERROR;
  constructor(public error: string){}
}

/*
export class GetMonitorCommunicacionbyid implements Action {
  readonly type = Types.GET_MONITOR_TRAMPA;
  constructor(public requestbyid: MonitortrampabyidRequest){}
}

export class GetMonitorCommunicacionbyidSuccess implements Action {
  readonly type = Types.GET_MONITOR_TRAMPA_SUCCESS;
  constructor(public monitortrampa: MonitortrampaResponse){}
}

export class GetMonitorCommunicacionbyidError implements Action {
  readonly type = Types.GET_MONITOR_TRAMPA_ERROR;
  constructor(public error: string){}
}

*/

export class AsignarMonitortrampa implements Action {
  readonly type = Types.ASIGNAR_MONITOR_TRAMPA;
  constructor(public asignartrampas: MonitortrampaRequest[]){}
}

export class AsignarMonitortrampaSuccess implements Action {
  readonly type = Types.ASIGNAR_MONITOR_TRAMPA_SUCCESS;
  constructor(public success: boolean){}
}

export class AsignarMonitortrampaError implements Action {
  readonly type = Types.ASIGNAR_MONITOR_TRAMPA_ERROR;
  constructor(public error: string) {}
}


//eliminar
export class DeleteMonitortrampa implements Action {
  readonly type = Types.DELETE_MONITOR_TRAMPA;
  constructor(public monitortrampa: MonitortrampaRequest){}
}

export class DeleteMonitortrampaSuccess implements Action {
  readonly type = Types.DELETE_MONITOR_TRAMPA_SUCCESS;
  constructor(public success: boolean){}
}

export class DeleteMonitortrampaError implements Action {
  readonly type = Types.DELETE_MONITOR_TRAMPA_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class ReplicarTemporadaMonitor implements Action {
  readonly type = Types.REPLICAR_TEMPORADA_MONITOR;
  constructor(public id: string){}
}

export class ReplicarTemporadaMonitorSuccess implements Action {
  readonly type = Types.REPLICAR_TEMPORADA_MONITOR_SUCCESS;
  constructor(public success: boolean){}
}

export class ReplicarTemporadaMonitorError implements Action {
  readonly type = Types.REPLICAR_TEMPORADA_MONITOR_ERROR;
  constructor(public error: string) {}
}


export type All =
  ReadMonitortrampa | ReadMonitortrampaSuccess |   ReadMonitortrampaError
  | AsignarMonitortrampa | AsignarMonitortrampaSuccess | AsignarMonitortrampaError
  | DeleteMonitortrampa | DeleteMonitortrampaSuccess | DeleteMonitortrampaError
  | GetMonitorbuscartrampa | GetMonitorbuscartrampaSuccess | GetMonitorbuscartrampaError
  | ReplicarTemporadaMonitor | ReplicarTemporadaMonitorSuccess | ReplicarTemporadaMonitorError
  
  