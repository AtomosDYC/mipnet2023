import {Action} from '@ngrx/store';
import {  PersonaResponse, PersonaRequest, PersonaRequestUpdate } from './save.models';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from "@progress/kendo-angular-grid";

export enum Types {
  READ_MONITOREO = '[Monitoreo] Read_Monitoreo',
  READ_MONITOREO_SUCCESS = '[Monitoreo] Read_Monitoreo:Success',
  READ_MONITOREO_ERROR = '[Monitoreo] Read_Monitoreo:Error',

}

export class ReadMonitoreo implements Action {
  readonly type = Types.READ_MONITOREO;
  constructor(public persona: RequestState){}
}

export class ReadMonitoreoSuccess implements Action {
  readonly type = Types.READ_MONITOREO_SUCCESS;
  constructor(public personasource: GridDataResult){}
}

export class ReadMonitoreoError implements Action {
  readonly type = Types.READ_MONITOREO_ERROR;
  constructor(public error: string){}
}


export type All =
ReadMonitoreo | ReadMonitoreoSuccess | ReadMonitoreoError
