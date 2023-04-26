import {Action} from '@ngrx/store';
import { WorkflowParametroResponse, WorkflowParametrosResponse, WorkflowParametroRequest } from './save.models';


export enum Types {
  READ = '[WorkflowParametro] Read',
  READ_SUCCESS = '[WorkflowParametro] Read:Success',
  READ_ERROR = '[WorkflowParametro] Read:Error',

  GET_WORKFLOWPARAMETRO = '[GET] Get_workflowparametro',
  GET_WORKFLOWPARAMETRO_SUCCESS = '[GET] Get_workflowparametro:Success',
  GET_WORKFLOWPARAMETRO_ERROR = '[GET] Get_workflowparametro:Error',

  CREATE_WORKFLOWPARAMETRO = '[CREATE] Create_WorkflowParametro',
  CREATE_WORKFLOWPARAMETRO_SUCCESS = '[CREATE] Create_WorkflowParametro:Success',
  CREATE_WORKFLOWPARAMETRO_ERROR = '[CREATE] Create_WorkflowParametro:Error',

  DELETE_WORKFLOWPARAMETRO = '[DELETE] dELETE',
  DELETE_WORKFLOWPARAMETRO_SUCCESS = '[DELETE] workflowparametro Success',
  DELETE_WORKFLOWPARAMETRO_ERROR = '[DELETE] workflowparametro Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(public id: string){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public workflowparametros: WorkflowParametroResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_WORKFLOWPARAMETRO;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_WORKFLOWPARAMETRO_SUCCESS;
  constructor(public workflowparametro: WorkflowParametroResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_WORKFLOWPARAMETRO_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_WORKFLOWPARAMETRO;
  constructor(public workflowparametro: WorkflowParametroRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_WORKFLOWPARAMETRO_SUCCESS;
  constructor(public workflowparametros: WorkflowParametroResponse[], public success: boolean){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_WORKFLOWPARAMETRO_ERROR;
  constructor(public error: string) {}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_WORKFLOWPARAMETRO;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_WORKFLOWPARAMETRO_SUCCESS;
  constructor(public workflowparametros: WorkflowParametroResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_WORKFLOWPARAMETRO_ERROR;
  constructor(public error: string) {}
}


export type All =
  Read | ReadSuccess | ReadError
| Getbyid | GetbyidSuccess | GetbyidError
| Create | CreateSuccess | CreateError
| Delete | DeleteSuccess | DeleteError


