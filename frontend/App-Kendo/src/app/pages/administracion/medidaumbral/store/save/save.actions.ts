import {Action} from '@ngrx/store';
import { MedidaUmbralCreateRequest, MedidaUmbralResponse, MedidaUmbralesResponse, MedidaUmbralUpdateRequest } from './save.models';


export enum Types {
  READ = '[MedidaUmbral] Read',
  READ_SUCCESS = '[MedidaUmbral] Read:Success',
  READ_ERROR = '[MedidaUmbral] Read:Error',

  GET_MEDIDAUMBRAL = '[GET] Get_medidaumbral',
  GET_MEDIDAUMBRAL_SUCCESS = '[GET] Get_medidaumbral:Success',
  GET_MEDIDAUMBRAL_ERROR = '[GET] Get_medidaumbral:Error',

  CREATE_MEDIDAUMBRAL = '[CREATE] Create_MedidaUmbral',
  CREATE_MEDIDAUMBRAL_SUCCESS = '[CREATE] Create_MedidaUmbral:Success',
  CREATE_MEDIDAUMBRAL_ERROR = '[CREATE] Create_MedidaUmbral:Error',

  DELETE_MEDIDAUMBRAL = '[DELETE] dELETE',
  DELETE_MEDIDAUMBRAL_SUCCESS = '[DELETE] medidaumbral Success',
  DELETE_MEDIDAUMBRAL_ERROR = '[DELETE] medidaumbral Error',

  UPDATE_MEDIDAUMBRAL = '[UPDATE] MedidaUmbral',
  UPDATE_MEDIDAUMBRAL_SUCCESS = '[UPDATE] Game Success',
  UPDATE_MEDIDAUMBRAL_ERROR = '[UPDATE] Game Error',

  ACTIVATE_MEDIDAUMBRAL = '[ACTIVATE] MedidaUmbral',
  ACTIVATE_MEDIDAUMBRAL_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_MEDIDAUMBRAL_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_MEDIDAUMBRAL = '[DESACTIVATE] MedidaUmbral',
  DESACTIVATE_MEDIDAUMBRAL_SUCCESS = '[DESACTIVATE] MedidaUmbral Success',
  DESACTIVATE_MEDIDAUMBRAL_ERROR = '[DESACTIVATE] MedidaUmbral Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public medidaumbrales: MedidaUmbralResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_MEDIDAUMBRAL;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_MEDIDAUMBRAL_SUCCESS;
  constructor(public medidaumbral: MedidaUmbralResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_MEDIDAUMBRAL_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_MEDIDAUMBRAL;
  constructor(public medidaumbral: MedidaUmbralCreateRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_MEDIDAUMBRAL_SUCCESS;
  constructor(public medidaumbral: MedidaUmbralResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_MEDIDAUMBRAL_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_MEDIDAUMBRAL;
  constructor(public medidaumbral: MedidaUmbralResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_MEDIDAUMBRAL_SUCCESS;
  constructor(public medidaumbral: MedidaUmbralResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_MEDIDAUMBRAL_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_MEDIDAUMBRAL;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_MEDIDAUMBRAL_SUCCESS;
  constructor(public medidaumbrales: MedidaUmbralResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_MEDIDAUMBRAL_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_MEDIDAUMBRAL;
  constructor(public medidaumbrales: MedidaUmbralResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_MEDIDAUMBRAL_SUCCESS;
  constructor(public medidaumbrales: MedidaUmbralResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_MEDIDAUMBRAL_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_MEDIDAUMBRAL;
  constructor(public medidaumbrales: MedidaUmbralResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_MEDIDAUMBRAL_SUCCESS;
  constructor(public medidaumbrales: MedidaUmbralResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_MEDIDAUMBRAL_ERROR;
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


