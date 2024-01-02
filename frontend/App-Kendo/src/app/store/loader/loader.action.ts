
import { Action } from '@ngrx/store';
import { ILoader } from './loader.models';


export enum Types {
  LOAD = '[load] Load',
  LOAD_SUCCESS = '[Load] Load: Success',
  LOAD_ERROR = '[Load] Load : Error',
  CAMBIAR_ESTADO = '[Load] Load : CambiarEstado',
  ON_SUCCESS = '[Load] Load : Onsuccess',
}

//INIT -> EL USUARIO ESTA EN SESION?
export class Load implements Action{
  readonly type = Types.LOAD;
  constructor(){}
}

export class LoadSuccess implements Action{
  readonly type = Types.LOAD_SUCCESS;
  constructor(public success: boolean | null){}
}

export class LoadError implements Action{
  readonly type = Types.LOAD_ERROR;
  constructor(public error: string){}
}

export class cambiarestado implements Action{
  readonly type = Types.CAMBIAR_ESTADO;
  constructor(){}
}

export class onsuccess implements Action{
  readonly type = Types.ON_SUCCESS;
  constructor(){}
}

export type All = Load | LoadSuccess | LoadError | cambiarestado | onsuccess
        