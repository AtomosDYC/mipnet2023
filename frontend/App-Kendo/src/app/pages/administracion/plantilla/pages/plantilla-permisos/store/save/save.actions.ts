import {Action} from '@ngrx/store';
import { PlantillasflujosResponse, PlantillaflujoResponse, PlantillaflujoCreateRequest, PlantillaflujoUpdateRequest } from './save.models';
import { PlantillaCreateRequest } from '../../../../store/save';


export enum Types {
  READ = '[Plantillaflujo] Read',
  READ_SUCCESS = '[Plantillaflujo] Read:Success',
  READ_ERROR = '[Plantillaflujo] Read:Error',

  GET_PLANTILLAFLUJO = '[GET] Get_plantilla',
  GET_PLANTILLAFLUJO_SUCCESS = '[GET] Get_plantilla:Success',
  GET_PLANTILLAFLUJO_ERROR = '[GET] Get_plantilla:Error',

  CREATE_PLANTILLAFLUJO = '[CREATE] Create_Plantillaflujo',
  CREATE_PLANTILLAFLUJO_SUCCESS = '[CREATE] Create_Plantillaflujo:Success',
  CREATE_PLANTILLAFLUJO_ERROR = '[CREATE] Create_Plantillaflujo:Error',

  DELETE_PLANTILLAFLUJO = '[DELETE] dELETE',
  DELETE_PLANTILLAFLUJO_SUCCESS = '[DELETE] plantilla Success',
  DELETE_PLANTILLAFLUJO_ERROR = '[DELETE] plantilla Error',

  UPDATE_PLANTILLAFLUJO = '[UPDATE] Plantillaflujo',
  UPDATE_PLANTILLAFLUJO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_PLANTILLAFLUJO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_PLANTILLAFLUJO = '[ACTIVATE] Plantillaflujo',
  ACTIVATE_PLANTILLAFLUJO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_PLANTILLAFLUJO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_PLANTILLAFLUJO = '[DESACTIVATE] Plantillaflujo',
  DESACTIVATE_PLANTILLAFLUJO_SUCCESS = '[DESACTIVATE] Plantillaflujo Success',
  DESACTIVATE_PLANTILLAFLUJO_ERROR = '[DESACTIVATE] Plantillaflujo Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public plantillaflujos: PlantillaflujoResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_PLANTILLAFLUJO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_PLANTILLAFLUJO_SUCCESS;
  constructor(public plantillaflujo: PlantillaflujoResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_PLANTILLAFLUJO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_PLANTILLAFLUJO;
  constructor(public plantillaflujo: PlantillaflujoCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_PLANTILLAFLUJO_SUCCESS;
  constructor(public plantillaflujo: PlantillaflujoResponse, public success: boolean){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_PLANTILLAFLUJO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_PLANTILLAFLUJO;
  constructor(public plantillaflujo: PlantillaflujoResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_PLANTILLAFLUJO_SUCCESS;
  constructor(public plantillaflujo: PlantillaflujoResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_PLANTILLAFLUJO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_PLANTILLAFLUJO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_PLANTILLAFLUJO_SUCCESS;
  constructor(public plantillaflujos: PlantillaflujoResponse[], public success: boolean){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_PLANTILLAFLUJO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_PLANTILLAFLUJO;
  constructor(public plantillaflujos: PlantillaflujoResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_PLANTILLAFLUJO_SUCCESS;
  constructor(public plantillaflujos: PlantillaflujoResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_PLANTILLAFLUJO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_PLANTILLAFLUJO;
  constructor(public plantillaflujos: PlantillaflujoResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_PLANTILLAFLUJO_SUCCESS;
  constructor(public plantillaflujos: PlantillaflujoResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_PLANTILLAFLUJO_ERROR;
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


