import {Action} from '@ngrx/store';
import { PlantillaCreateRequest, PlantillaResponse, PlantillasResponse, PlantillaUpdateRequest } from './save.models';


export enum Types {
  READ = '[Plantilla] Read',
  READ_SUCCESS = '[Plantilla] Read:Success',
  READ_ERROR = '[Plantilla] Read:Error',

  GET_PLANTILLA = '[GET] Get_plantilla',
  GET_PLANTILLA_SUCCESS = '[GET] Get_plantilla:Success',
  GET_PLANTILLA_ERROR = '[GET] Get_plantilla:Error',

  CREATE_PLANTILLA = '[CREATE] Create_Plantilla',
  CREATE_PLANTILLA_SUCCESS = '[CREATE] Create_Plantilla:Success',
  CREATE_PLANTILLA_ERROR = '[CREATE] Create_Plantilla:Error',

  DELETE_PLANTILLA = '[DELETE] dELETE',
  DELETE_PLANTILLA_SUCCESS = '[DELETE] plantilla Success',
  DELETE_PLANTILLA_ERROR = '[DELETE] plantilla Error',

  UPDATE_PLANTILLA = '[UPDATE] Plantilla',
  UPDATE_PLANTILLA_SUCCESS = '[UPDATE] Game Success',
  UPDATE_PLANTILLA_ERROR = '[UPDATE] Game Error',

  ACTIVATE_PLANTILLA = '[ACTIVATE] Plantilla',
  ACTIVATE_PLANTILLA_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_PLANTILLA_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_PLANTILLA = '[DESACTIVATE] Plantilla',
  DESACTIVATE_PLANTILLA_SUCCESS = '[DESACTIVATE] Plantilla Success',
  DESACTIVATE_PLANTILLA_ERROR = '[DESACTIVATE] Plantilla Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public plantillas: PlantillaResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_PLANTILLA;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_PLANTILLA_SUCCESS;
  constructor(public plantilla: PlantillaResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_PLANTILLA_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_PLANTILLA;
  constructor(public plantilla: PlantillaCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_PLANTILLA_SUCCESS;
  constructor(public plantilla: PlantillaResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_PLANTILLA_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_PLANTILLA;
  constructor(public plantilla: PlantillaResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_PLANTILLA_SUCCESS;
  constructor(public plantilla: PlantillaResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_PLANTILLA_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_PLANTILLA;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_PLANTILLA_SUCCESS;
  constructor(public plantillas: PlantillaResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_PLANTILLA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_PLANTILLA;
  constructor(public plantillas: PlantillaResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_PLANTILLA_SUCCESS;
  constructor(public plantillas: PlantillaResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_PLANTILLA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_PLANTILLA;
  constructor(public plantillas: PlantillaResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_PLANTILLA_SUCCESS;
  constructor(public plantillas: PlantillaResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_PLANTILLA_ERROR;
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


