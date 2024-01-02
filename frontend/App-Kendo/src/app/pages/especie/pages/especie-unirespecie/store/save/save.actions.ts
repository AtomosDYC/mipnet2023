import {Action} from '@ngrx/store';
import { UnirEspecieResponse, UnirEspecieRequest, UnirEspeciesResponse } from './save.models';
import { UnirEspecies, UnirEspecie } from '../../../../../../models/backend/especie/index';


export enum Types {

  GET_UNIRESPECIE = '[GET] Get_unirespecie',
  GET_UNIRESPECIE_SUCCESS = '[GET] Get_unirespecie:Success',
  GET_UNIRESPECIE_ERROR = '[GET] Get_unirespecie:Error',

  CREATE_UNIRESPECIE = '[CREATE] Create_WorkflowParametro',
  CREATE_UNIRESPECIE_SUCCESS = '[CREATE] Create_WorkflowParametro:Success',
  CREATE_UNIRESPECIE_ERROR = '[CREATE] Create_WorkflowParametro:Error',

  DELETE_UNIRESPECIE = '[DELETE] dELETE',
  DELETE_UNIRESPECIE_SUCCESS = '[DELETE] workflowparametro Success',
  DELETE_UNIRESPECIE_ERROR = '[DELETE] workflowparametro Error',

}

export class GetUnirespeciebyid implements Action {
  readonly type = Types.GET_UNIRESPECIE;
  constructor(public id: string){}
}

export class GetUnirespeciebyidSuccess implements Action {
  readonly type = Types.GET_UNIRESPECIE_SUCCESS;
  constructor(public unirespecies: UnirEspecieResponse[]){}
}

export class GetUnirespeciebyidError implements Action {
  readonly type = Types.GET_UNIRESPECIE_ERROR;
  constructor(public error: string){}
}

export class CreateUnirespecie implements Action {
  readonly type = Types.CREATE_UNIRESPECIE;
  constructor(public unirespecie: UnirEspecieRequest){}
}

export class CreateUnirespecieSuccess implements Action {
  readonly type = Types.CREATE_UNIRESPECIE_SUCCESS;
  constructor(public unirespecies: UnirEspecieResponse[], public success: boolean){}
}

export class CreateUnirespecieError implements Action {
  readonly type = Types.CREATE_UNIRESPECIE_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class DeleteUnirEspecie implements Action {
  readonly type = Types.DELETE_UNIRESPECIE;
  constructor(public id: string){}
}

export class DeleteUnirEspecieSuccess implements Action {
  readonly type = Types.DELETE_UNIRESPECIE_SUCCESS;
  constructor(public unirespecies: UnirEspecieResponse[], public success: boolean){}
}

export class DeleteUnirEspecieError implements Action {
  readonly type = Types.DELETE_UNIRESPECIE_ERROR;
  constructor(public error: string) {}
}

export type All =
GetUnirespeciebyid | GetUnirespeciebyidSuccess | GetUnirespeciebyidError
| CreateUnirespecie | CreateUnirespecieSuccess | CreateUnirespecieError
| DeleteUnirEspecie | DeleteUnirEspecieSuccess | DeleteUnirEspecieError


