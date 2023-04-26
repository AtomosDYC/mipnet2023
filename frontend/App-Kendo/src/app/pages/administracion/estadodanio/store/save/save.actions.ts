import {Action} from '@ngrx/store';
import { EstadoDanioCreateRequest, EstadoDanioResponse, EstadosDaniosResponse, EstadoDanioUpdateRequest } from './save.models';


export enum Types {
  READ = '[EstadoDanio] Read',
  READ_SUCCESS = '[EstadoDanio] Read:Success',
  READ_ERROR = '[EstadoDanio] Read:Error',

  GET_ESTADODANIO = '[GET] Get_estadodanio',
  GET_ESTADODANIO_SUCCESS = '[GET] Get_estadodanio:Success',
  GET_ESTADODANIO_ERROR = '[GET] Get_estadodanio:Error',

  CREATE_ESTADODANIO = '[CREATE] Create_EstadoDanio',
  CREATE_ESTADODANIO_SUCCESS = '[CREATE] Create_EstadoDanio:Success',
  CREATE_ESTADODANIO_ERROR = '[CREATE] Create_EstadoDanio:Error',

  DELETE_ESTADODANIO = '[DELETE] dELETE',
  DELETE_ESTADODANIO_SUCCESS = '[DELETE] estadodanio Success',
  DELETE_ESTADODANIO_ERROR = '[DELETE] estadodanio Error',

  UPDATE_ESTADODANIO = '[UPDATE] EstadoDanio',
  UPDATE_ESTADODANIO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_ESTADODANIO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_ESTADODANIO = '[ACTIVATE] EstadoDanio',
  ACTIVATE_ESTADODANIO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_ESTADODANIO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_ESTADODANIO = '[DESACTIVATE] EstadoDanio',
  DESACTIVATE_ESTADODANIO_SUCCESS = '[DESACTIVATE] EstadoDanio Success',
  DESACTIVATE_ESTADODANIO_ERROR = '[DESACTIVATE] EstadoDanio Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public estadosdanios: EstadoDanioResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_ESTADODANIO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_ESTADODANIO_SUCCESS;
  constructor(public estadodanio: EstadoDanioResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_ESTADODANIO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_ESTADODANIO;
  constructor(public estadodanio: EstadoDanioCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_ESTADODANIO_SUCCESS;
  constructor(public estadodanio: EstadoDanioResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_ESTADODANIO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_ESTADODANIO;
  constructor(public estadodanio: EstadoDanioResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_ESTADODANIO_SUCCESS;
  constructor(public estadodanio: EstadoDanioResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_ESTADODANIO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_ESTADODANIO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_ESTADODANIO_SUCCESS;
  constructor(public estadosdanios: EstadoDanioResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_ESTADODANIO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_ESTADODANIO;
  constructor(public estadosdanios: EstadoDanioResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_ESTADODANIO_SUCCESS;
  constructor(public estadosdanios: EstadoDanioResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_ESTADODANIO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_ESTADODANIO;
  constructor(public estadosdanios: EstadoDanioResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_ESTADODANIO_SUCCESS;
  constructor(public estadosdanios: EstadoDanioResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_ESTADODANIO_ERROR;
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


