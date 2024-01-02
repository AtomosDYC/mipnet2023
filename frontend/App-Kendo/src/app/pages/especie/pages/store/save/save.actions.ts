import {Action} from '@ngrx/store';
import {  EspecieResponse, EspecieDatosgeneralesRequest, EspecieDatosgeneralesUpdateRequest } from './save.models';
import { Especie } from '../../../../../models/backend/especie/index';


export enum Types {
  READ_ESPECIE = '[Especie] Read_Especie',
  READ_ESPECIE_SUCCESS = '[Especie] Read_Especie:Success',
  READ_ESPECIE_ERROR = '[Especie] Read_Especie:Error',

  GET_ESPECIE = '[GET_ESPECIE] Get_especie',
  GET_ESPECIE_SUCCESS = '[GET_ESPECIE] Get_especie:Success',
  GET_ESPECIE_ERROR = '[GET_ESPECIE] Get_especie:Error',

  CREATE_ESPECIE_DATOSGENERALES = '[CREATE_ESPECIE] create_especie_datosgenerales',
  CREATE_ESPECIE_DATOSGENERALES_SUCCESS = '[CREATE_ESPECIE] create_especie_datosgenerales:Success',
  CREATE_ESPECIE_DATOSGENERALES_ERROR = '[CREATE_ESPECIE] Create__especie_datosgenerales:Error',
  
  UPDATE_ESPECIE_DATOSGENERALES = '[UPDATE_ESPECIE] Update_especie_datosgenerales',
  UPDATE_ESPECIE_DATOSGENERALES_SUCCESS = '[UPDATE_ESPECIE] Update_especie_datosgenerales:Success',
  UPDATE_ESPECIE_DATOSGENERALES_ERROR = '[UPDATE_ESPECIE] Update_especie_datosgenerales:Error',

}

export class ReadEspecieDatosgenerales implements Action {
  readonly type = Types.READ_ESPECIE;
  constructor(){}
}

export class ReadEspecieDatosgeneralesSuccess implements Action {
  readonly type = Types.READ_ESPECIE_SUCCESS;
  constructor(public especies: EspecieResponse[]){}
}

export class ReadEspecieDatosgeneralesError implements Action {
  readonly type = Types.READ_ESPECIE_ERROR;
  constructor(public error: string){}
}

export class GetEspecieDatosGeneralesbyid implements Action {
  readonly type = Types.GET_ESPECIE;
  constructor(public id: string){}
}

export class GetEspecieDatosGeneralesbyidSuccess implements Action {
  readonly type = Types.GET_ESPECIE_SUCCESS;
  constructor(public especie: EspecieResponse){}
}

export class GetEspecieDatosGeneralesbyidError implements Action {
  readonly type = Types.GET_ESPECIE_ERROR;
  constructor(public error: string){}
}

export class CreateEspecie implements Action {
  readonly type = Types.CREATE_ESPECIE_DATOSGENERALES;
  constructor(public especie: EspecieDatosgeneralesRequest){}
}

export class CreateEspecieSuccess implements Action {
  readonly type = Types.CREATE_ESPECIE_DATOSGENERALES_SUCCESS;
  constructor(public especie: EspecieResponse){}
}

export class CreateEspecieError implements Action {
  readonly type = Types.CREATE_ESPECIE_DATOSGENERALES_ERROR;
  constructor(public error: string) {}
}

export class UpdateEspecie implements Action {
  readonly type = Types.UPDATE_ESPECIE_DATOSGENERALES;
  constructor(public especie: EspecieDatosgeneralesUpdateRequest){}
}

export class UpdateEspecieSuccess implements Action {
  readonly type = Types.UPDATE_ESPECIE_DATOSGENERALES_SUCCESS;
  constructor(public especie: EspecieResponse){}
}

export class UpdateEspecieError implements Action {
  readonly type = Types.UPDATE_ESPECIE_DATOSGENERALES_ERROR;
  constructor(public error: string) {}
}


export type All =
  ReadEspecieDatosgenerales | ReadEspecieDatosgeneralesSuccess | ReadEspecieDatosgeneralesError
  | GetEspecieDatosGeneralesbyid | GetEspecieDatosGeneralesbyidSuccess | GetEspecieDatosGeneralesbyidError
  | CreateEspecie | CreateEspecieSuccess | CreateEspecieError
  | UpdateEspecie | UpdateEspecieSuccess | UpdateEspecieError
