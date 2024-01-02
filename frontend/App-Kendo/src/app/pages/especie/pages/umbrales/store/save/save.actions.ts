import {Action} from '@ngrx/store';
import { EspecieUmbralResponse, EspecieUmbralRequest, EspecieUmbralsResponse } from './save.models';
import { EspecieUmbrals, EspecieUmbral } from '../../../../../../models/backend/especie/index';


export enum Types {

  GET_ESPECIEUMBRAL = '[GET] Get_especieumbral',
  GET_ESPECIEUMBRAL_SUCCESS = '[GET] Get_especieumbral:Success',
  GET_ESPECIEUMBRAL_ERROR = '[GET] Get_especieumbral:Error',

  CREATE_ESPECIEUMBRAL = '[CREATE] Create_especieumbral',
  CREATE_ESPECIEUMBRAL_SUCCESS = '[CREATE] Create_especieumbral:Success',
  CREATE_ESPECIEUMBRAL_ERROR = '[CREATE] Create_especieumbral:Error',

  DELETE_ESPECIEUMBRAL = '[DELETE] Delete_especieumbral',
  DELETE_ESPECIEUMBRAL_SUCCESS = '[DELETE] Deleteespecieumbral:Success',
  DELETE_ESPECIEUMBRAL_ERROR = '[DELETE] Delete_especieumbral:Error',

}

export class Getbyid implements Action {
  readonly type = Types.GET_ESPECIEUMBRAL;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_ESPECIEUMBRAL_SUCCESS;
  constructor(public especieumbrals: EspecieUmbralResponse[]){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_ESPECIEUMBRAL_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_ESPECIEUMBRAL;
  constructor(public especieumbral: EspecieUmbralRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_ESPECIEUMBRAL_SUCCESS;
  constructor(public especieumbrals: EspecieUmbralResponse[], public success: boolean){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_ESPECIEUMBRAL_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class DeleteEspecieUmbral implements Action {
  readonly type = Types.DELETE_ESPECIEUMBRAL;
  constructor(public id: string){}
}

export class DeleteEspecieUmbralSuccess implements Action {
  readonly type = Types.DELETE_ESPECIEUMBRAL_SUCCESS;
  constructor(public especieumbrals: EspecieUmbralResponse[], public success: boolean){}
}

export class DeleteEspecieUmbralError implements Action {
  readonly type = Types.DELETE_ESPECIEUMBRAL_ERROR;
  constructor(public error: string) {}
}

export type All =
  Getbyid | GetbyidSuccess | GetbyidError
| Create | CreateSuccess | CreateError
| DeleteEspecieUmbral | DeleteEspecieUmbralSuccess | DeleteEspecieUmbralError


