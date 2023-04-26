import {Action} from '@ngrx/store';
import { RegionCreateRequest, RegionResponse, RegionesResponse, RegionUpdateRequest } from './save.models';


export enum Types {
  READ = '[Region] Read',
  READ_SUCCESS = '[Region] Read:Success',
  READ_ERROR = '[Region] Read:Error',

  GET_REGION = '[GET] Get_region',
  GET_REGION_SUCCESS = '[GET] Get_region:Success',
  GET_REGION_ERROR = '[GET] Get_region:Error',

  CREATE_REGION = '[CREATE] Create_Region',
  CREATE_REGION_SUCCESS = '[CREATE] Create_Region:Success',
  CREATE_REGION_ERROR = '[CREATE] Create_Region:Error',

  DELETE_REGION = '[DELETE] dELETE',
  DELETE_REGION_SUCCESS = '[DELETE] region Success',
  DELETE_REGION_ERROR = '[DELETE] region Error',

  UPDATE_REGION = '[UPDATE] Region',
  UPDATE_REGION_SUCCESS = '[UPDATE] Game Success',
  UPDATE_REGION_ERROR = '[UPDATE] Game Error',

  ACTIVATE_REGION = '[ACTIVATE] Region',
  ACTIVATE_REGION_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_REGION_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_REGION = '[DESACTIVATE] Region',
  DESACTIVATE_REGION_SUCCESS = '[DESACTIVATE] Region Success',
  DESACTIVATE_REGION_ERROR = '[DESACTIVATE] Region Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public regiones: RegionResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_REGION;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_REGION_SUCCESS;
  constructor(public region: RegionResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_REGION_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_REGION;
  constructor(public region: RegionCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_REGION_SUCCESS;
  constructor(public region: RegionResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_REGION_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_REGION;
  constructor(public region: RegionResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_REGION_SUCCESS;
  constructor(public region: RegionResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_REGION_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_REGION;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_REGION_SUCCESS;
  constructor(public regiones: RegionResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_REGION_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_REGION;
  constructor(public regiones: RegionResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_REGION_SUCCESS;
  constructor(public regiones: RegionResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_REGION_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_REGION;
  constructor(public regiones: RegionResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_REGION_SUCCESS;
  constructor(public regiones: RegionResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_REGION_ERROR;
  constructor(public error: string) {}
}

export type All =
  Read | ReadSuccess | ReadError
| Getbyid | GetbyidSuccess | GetbyidError
| Create | CreateSuccess | CreateError
| Update | UpdateSuccess | UpdateError
| Delete | DeleteSuccess | DeleteError
| Desactivate | DesactivateSuccess | DesactivateError
| Activate | ActivateSuccess | ActivateError


