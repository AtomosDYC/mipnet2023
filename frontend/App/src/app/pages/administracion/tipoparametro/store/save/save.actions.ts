import {Action} from '@ngrx/store';
import { TipoParametroCreateRequest, TipoParametroResponse, TipoParametrosResponse, TipoParametroUpdateRequest } from './save.models';


export enum Types {
  READ = '[TipoParametro] Read',
  READ_SUCCESS = '[TipoParametro] Read:Success',
  READ_ERROR = '[TipoParametro] Read:Error',

  GET_TIPOPARAMETRO = '[GET] Get_tipoparametro',
  GET_TIPOPARAMETRO_SUCCESS = '[GET] Get_tipoparametro:Success',
  GET_TIPOPARAMETRO_ERROR = '[GET] Get_tipoparametro:Error',

  CREATE_TIPOPARAMETRO = '[CREATE] Create_TipoParametro',
  CREATE_TIPOPARAMETRO_SUCCESS = '[CREATE] Create_TipoParametro:Success',
  CREATE_TIPOPARAMETRO_ERROR = '[CREATE] Create_TipoParametro:Error',

  DELETE_TIPOPARAMETRO = '[DELETE] dELETE',
  DELETE_TIPOPARAMETRO_SUCCESS = '[DELETE] tipoparametro Success',
  DELETE_TIPOPARAMETRO_ERROR = '[DELETE] tipoparametro Error',

  UPDATE_TIPOPARAMETRO = '[UPDATE] TipoParametro',
  UPDATE_TIPOPARAMETRO_SUCCESS = '[UPDATE] Game Success',
  UPDATE_TIPOPARAMETRO_ERROR = '[UPDATE] Game Error',

  ACTIVATE_TIPOPARAMETRO = '[ACTIVATE] TipoParametro',
  ACTIVATE_TIPOPARAMETRO_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_TIPOPARAMETRO_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_TIPOPARAMETRO = '[DESACTIVATE] TipoParametro',
  DESACTIVATE_TIPOPARAMETRO_SUCCESS = '[DESACTIVATE] TipoParametro Success',
  DESACTIVATE_TIPOPARAMETRO_ERROR = '[DESACTIVATE] TipoParametro Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public tipoparametros: TipoParametroResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_TIPOPARAMETRO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_TIPOPARAMETRO_SUCCESS;
  constructor(public tipoparametro: TipoParametroResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_TIPOPARAMETRO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_TIPOPARAMETRO;
  constructor(public tipoparametro: TipoParametroCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_TIPOPARAMETRO_SUCCESS;
  constructor(public tipoparametro: TipoParametroResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_TIPOPARAMETRO_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_TIPOPARAMETRO;
  constructor(public tipoparametro: TipoParametroResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_TIPOPARAMETRO_SUCCESS;
  constructor(public tipoparametro: TipoParametroResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_TIPOPARAMETRO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_TIPOPARAMETRO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_TIPOPARAMETRO_SUCCESS;
  constructor(public tipoparametros: TipoParametroResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_TIPOPARAMETRO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_TIPOPARAMETRO;
  constructor(public tipoparametros: TipoParametroResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_TIPOPARAMETRO_SUCCESS;
  constructor(public tipoparametros: TipoParametroResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_TIPOPARAMETRO_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_TIPOPARAMETRO;
  constructor(public tipoparametros: TipoParametroResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_TIPOPARAMETRO_SUCCESS;
  constructor(public tipoparametros: TipoParametroResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_TIPOPARAMETRO_ERROR;
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


