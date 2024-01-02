import {Action} from '@ngrx/store';
import { SegmentarTemporadaResponse, SegmentarTemporadasCreaterequest, SegmentarTemporadasResponse } from './save.models';


export enum Types {
  READ = '[SegmentarTemporada] Read',
  READ_SUCCESS = '[SegmentarTemporada] Read:Success',
  READ_ERROR = '[SegmentarTemporada] Read:Error',

  GET_SEGMENTARTEMPORADA = '[GET] Get_segmentartemporada',
  GET_SEGMENTARTEMPORADA_SUCCESS = '[GET] Get_segmentartemporada:Success',
  GET_SEGMENTARTEMPORADA_ERROR = '[GET] Get_segmentartemporada:Error',

  CREATE_SEGMENTARTEMPORADA = '[CREATE] Create_segmentartemporada',
  CREATE_SEGMENTARTEMPORADA_SUCCESS = '[CREATE] Create_segmentartemporada:Success',
  CREATE_SEGMENTARTEMPORADA_ERROR = '[CREATE] Create_segmentartemporada:Error',

  DELETE_SEGMENTARTEMPORADA = '[DELETE] Delete_segmentartemporada',
  DELETE_SEGMENTARTEMPORADA_SUCCESS = '[DELETE] Delete_segmentartemporada:Success',
  DELETE_SEGMENTARTEMPORADA_ERROR = '[DELETE] Delete_segmentartemporada:Error',

  UPDATE_SEGMENTARTEMPORADA = '[UPDATE] Update_segmentartemporada',
  UPDATE_SEGMENTARTEMPORADA_SUCCESS = '[UPDATE] Update_segmentartemporada:Success',
  UPDATE_SEGMENTARTEMPORADA_ERROR = '[UPDATE] Update_segmentartemporada:Error',

  ACTIVATE_SEGMENTARTEMPORADA = '[ACTIVATE] Activate_segmentartemporada',
  ACTIVATE_SEGMENTARTEMPORADA_SUCCESS = '[ACTIVATE] Activate_segmentartemporada:Success',
  ACTIVATE_SEGMENTARTEMPORADA_ERROR = '[ACTIVATE] Activate_segmentartemporada:Error',

  DESACTIVATE_SEGMENTARTEMPORADA = '[DESACTIVATE] Desactivate_segmentartemporada',
  DESACTIVATE_SEGMENTARTEMPORADA_SUCCESS = '[DESACTIVATE] Desactivate_segmentartemporada:Success',
  DESACTIVATE_SEGMENTARTEMPORADA_ERROR = '[DESACTIVATE] Desactivate_segmentartemporada:Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public segmentartemporadas: SegmentarTemporadaResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_SEGMENTARTEMPORADA;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_SEGMENTARTEMPORADA_SUCCESS;
  constructor(public segmentartemporada: SegmentarTemporadaResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_SEGMENTARTEMPORADA_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_SEGMENTARTEMPORADA;
  constructor(public segmentartemporada: SegmentarTemporadasCreaterequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_SEGMENTARTEMPORADA_SUCCESS;
  constructor(public segmentartemporada: SegmentarTemporadaResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_SEGMENTARTEMPORADA_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_SEGMENTARTEMPORADA;
  constructor(public segmentartemporada: SegmentarTemporadaResponse){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_SEGMENTARTEMPORADA_SUCCESS;
  constructor(public segmentartemporada: SegmentarTemporadaResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_SEGMENTARTEMPORADA_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_SEGMENTARTEMPORADA;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_SEGMENTARTEMPORADA_SUCCESS;
  constructor(public segmentartemporadas: SegmentarTemporadaResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_SEGMENTARTEMPORADA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_SEGMENTARTEMPORADA;
  constructor(public segmentartemporadas: SegmentarTemporadaResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_SEGMENTARTEMPORADA_SUCCESS;
  constructor(public segmentartemporadas: SegmentarTemporadaResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_SEGMENTARTEMPORADA_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_SEGMENTARTEMPORADA;
  constructor(public segmentartemporadas: SegmentarTemporadaResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_SEGMENTARTEMPORADA_SUCCESS;
  constructor(public segmentartemporadas: SegmentarTemporadaResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_SEGMENTARTEMPORADA_ERROR;
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


