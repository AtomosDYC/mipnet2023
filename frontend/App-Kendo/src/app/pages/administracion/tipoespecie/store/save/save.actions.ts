import {Action} from '@ngrx/store';
import { TipoEspecieCreateRequest, TipoEspecieResponse, TipoEspeciesResponse, TipoEspecieUpdateRequest } from './save.models';


export enum Types {
  READ = '[TipoEspecie] Read',
  READ_SUCCESS = '[TipoEspecie] Read:Success',
  READ_ERROR = '[TipoEspecie] Read:Error',

  GET_TIPOESPECIE = '[GET] Get_tipoespecie',
  GET_TIPOESPECIE_SUCCESS = '[GET] Get_tipoespecie:Success',
  GET_TIPOESPECIE_ERROR = '[GET] Get_tipoespecie:Error',

  CREATE_TIPOESPECIE = '[CREATE] Create_TipoEspecie',
  CREATE_TIPOESPECIE_SUCCESS = '[CREATE] Create_TipoEspecie:Success',
  CREATE_TIPOESPECIE_ERROR = '[CREATE] Create_TipoEspecie:Error',

  DELETE_TIPOESPECIE = '[DELETE] dELETE',
  DELETE_TIPOESPECIE_SUCCESS = '[DELETE] tipoespecie Success',
  DELETE_TIPOESPECIE_ERROR = '[DELETE] tipoespecie Error',

  UPDATE_TIPOESPECIE = '[UPDATE] TipoEspecie',
  UPDATE_TIPOESPECIE_SUCCESS = '[UPDATE] Game Success',
  UPDATE_TIPOESPECIE_ERROR = '[UPDATE] Game Error',

  ACTIVATE_TIPOESPECIE = '[ACTIVATE] TipoEspecie',
  ACTIVATE_TIPOESPECIE_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_TIPOESPECIE_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_TIPOESPECIE = '[DESACTIVATE] TipoEspecie',
  DESACTIVATE_TIPOESPECIE_SUCCESS = '[DESACTIVATE] TipoEspecie Success',
  DESACTIVATE_TIPOESPECIE_ERROR = '[DESACTIVATE] TipoEspecie Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public tipoespecies: TipoEspecieResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TIPOESPECIE;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TIPOESPECIE_SUCCESS;
  constructor(public tipoespecie: TipoEspecieResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TIPOESPECIE_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TIPOESPECIE;
  constructor(public tipoespecie: TipoEspecieCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TIPOESPECIE_SUCCESS;
  constructor(public tipoespecie: TipoEspecieResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TIPOESPECIE_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TIPOESPECIE;
  constructor(public tipoespecie: TipoEspecieResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TIPOESPECIE_SUCCESS;
  constructor(public tipoespecie: TipoEspecieResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TIPOESPECIE_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TIPOESPECIE;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TIPOESPECIE_SUCCESS;
  constructor(public tipoespecies: TipoEspecieResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TIPOESPECIE_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TIPOESPECIE;
  constructor(public tipoespecies: TipoEspecieResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TIPOESPECIE_SUCCESS;
  constructor(public tipoespecies: TipoEspecieResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TIPOESPECIE_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TIPOESPECIE;
  constructor(public tipoespecies: TipoEspecieResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TIPOESPECIE_SUCCESS;
  constructor(public tipoespecies: TipoEspecieResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TIPOESPECIE_ERROR;
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


