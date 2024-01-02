import {Action} from '@ngrx/store';
import { DanioEspecieResponse, DanioEspecieRequest, DanioEspeciesResponse } from './save.models';
import { DanioEspecies, DanioEspecie } from '../../../../../../models/backend/especie/index';


export enum Types {

  GET_DANIOESPECIE = '[GET_danioespecie] Get_danioespecie',
  GET_DANIOESPECIE_SUCCESS = '[GET_danioespecie] Get_danioespecie:Success',
  GET_DANIOESPECIE_ERROR = '[GET_danioespecie] Get_danioespecie:Error',

  CREATE_DANIOESPECIE = '[CREATE_danioespecie]] Create_danioespecie',
  CREATE_DANIOESPECIE_SUCCESS = '[CREATE_danioespecie]] Create_danioespecie:Success',
  CREATE_DANIOESPECIE_ERROR = '[CREATE_danioespecie]] Create_danioespecie:Error',

  DELETE_DANIOESPECIE = '[DELETE_danioespecie] DELETE_danioespecie',
  DELETE_DANIOESPECIE_SUCCESS = '[DELETE_danioespecie] DELETE_danioespecie:Success',
  DELETE_DANIOESPECIE_ERROR = '[DELETE_danioespecie] DELETE_danioespecie:Error',

}

export class GetDanioespeciebyid implements Action {
  readonly type = Types.GET_DANIOESPECIE;
  constructor(public id: string){}
}

export class GetDanioespeciebyidSuccess implements Action {
  readonly type = Types.GET_DANIOESPECIE_SUCCESS;
  constructor(public danioespecies: DanioEspecieResponse[]){}
}

export class GetDanioespeciebyidError implements Action {
  readonly type = Types.GET_DANIOESPECIE_ERROR;
  constructor(public error: string){}
}

export class CreateDanioespecie implements Action {
  readonly type = Types.CREATE_DANIOESPECIE;
  constructor(public danioespecie: DanioEspecieRequest){}
}

export class CreateDanioespecieSuccess implements Action {
  readonly type = Types.CREATE_DANIOESPECIE_SUCCESS;
  constructor(public danioespecies: DanioEspecieResponse[], public success: boolean){}
}

export class CreateDanioespecieError implements Action {
  readonly type = Types.CREATE_DANIOESPECIE_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class DeleteDanioEspecie implements Action {
  readonly type = Types.DELETE_DANIOESPECIE;
  constructor(public id: string){}
}

export class DeleteDanioEspecieSuccess implements Action {
  readonly type = Types.DELETE_DANIOESPECIE_SUCCESS;
  constructor(public danioespecies: DanioEspecieResponse[], public success: boolean){}
}

export class DeleteDanioEspecieError implements Action {
  readonly type = Types.DELETE_DANIOESPECIE_ERROR;
  constructor(public error: string) {}
}

export type All =
  GetDanioespeciebyid | GetDanioespeciebyidSuccess | GetDanioespeciebyidError
| CreateDanioespecie | CreateDanioespecieSuccess | CreateDanioespecieError
| DeleteDanioEspecie | DeleteDanioEspecieSuccess | DeleteDanioEspecieError


