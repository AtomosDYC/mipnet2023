import {Action} from '@ngrx/store';
import { WorkflowDatosgeneralesRequest, WorkflowResponse, WorkflowDatosgeneralesUpdateRequest, WorkflowConfiguracionwebRequest, WorkflowNodopadreRequest } from './save.models';


export enum Types {
  READ = '[Workflow] Read',
  READ_SUCCESS = '[Workflow] Read:Success',
  READ_ERROR = '[Workflow] Read:Error',

  GET_WORKFLOW = '[GET] Get_workflow',
  GET_WORKFLOW_SUCCESS = '[GET] Get_workflow:Success',
  GET_WORKFLOW_ERROR = '[GET] Get_workflow:Error',

  CREATE_WORKFLOW = '[CREATE] Create_Workflow',
  CREATE_WORKFLOW_SUCCESS = '[CREATE] Create_Workflow:Success',
  CREATE_WORKFLOW_ERROR = '[CREATE] Create_Workflow:Error',

  DELETE_WORKFLOW = '[DELETE] dELETE',
  DELETE_WORKFLOW_SUCCESS = '[DELETE] workflow Success',
  DELETE_WORKFLOW_ERROR = '[DELETE] workflow Error',

  UPDATE_WORKFLOW = '[UPDATE] Workflow',
  UPDATE_WORKFLOW_SUCCESS = '[UPDATE] Game Success',
  UPDATE_WORKFLOW_ERROR = '[UPDATE] Game Error',

  UPDATE_WORKFLOW_NODOPADRE = '[CREATE] Create_Workflow_nodopadre',
  UPDATE_WORKFLOW_NODOPADRE_SUCCESS = '[CREATE] Create_Workflow_nodopadre:Success',
  UPDATE_WORKFLOW_NODOPADRE_ERROR = '[CREATE] Create_Workflow_nodopadre:Error',
  
  UPDATE_WORKFLOW_CONFIGURACIONWEB = '[CREATE] Create_Workflow_nodopadre',
  UPDATE_WORKFLOW_CONFIGURACIONWEB_SUCCESS = '[CREATE] Create_Workflow_nodopadre:Success',
  UPDATE_WORKFLOW_CONFIGURACIONWEB_ERROR = '[CREATE] Create_Workflow_nodopadre:Error',

  GET_WORKFLOW_NODOPADRE = '[GET] Get_workflow',
  GET_WORKFLOW_NODOPADRE_SUCCESS = '[GET] Get_workflow:Success',
  GET_WORKFLOW_NODOPADRE_ERROR = '[GET] Get_workflow:Error',


  ACTIVATE_WORKFLOW = '[ACTIVATE] Workflow',
  ACTIVATE_WORKFLOW_SUCCESS = '[ACTIVATE] Activate Success',
  ACTIVATE_WORKFLOW_ERROR = '[ACTIVATE] Activate Error',

  DESACTIVATE_WORKFLOW = '[DESACTIVATE] Workflow',
  DESACTIVATE_WORKFLOW_SUCCESS = '[DESACTIVATE] Workflow Success',
  DESACTIVATE_WORKFLOW_ERROR = '[DESACTIVATE] Workflow Error',

}

export class Read implements Action {
  readonly type = Types.READ;
  constructor(){}
}

export class ReadSuccess implements Action {
  readonly type = Types.READ_SUCCESS;
  constructor(public workflows: WorkflowResponse[]){}
}

export class ReadError implements Action {
  readonly type = Types.READ_ERROR;
  constructor(public error: string){}
}

export class Getbyid implements Action {
  readonly type = Types.GET_WORKFLOW;
  constructor(public id: string){}
}

export class GetbyidSuccess implements Action {
  readonly type = Types.GET_WORKFLOW_SUCCESS;
  constructor(public workflow: WorkflowResponse){}
}

export class GetbyidError implements Action {
  readonly type = Types.GET_WORKFLOW_ERROR;
  constructor(public error: string){}
}

export class Create implements Action {
  readonly type = Types.CREATE_WORKFLOW;
  constructor(public workflow: WorkflowDatosgeneralesRequest){}
}

export class CreateSuccess implements Action {
  readonly type = Types.CREATE_WORKFLOW_SUCCESS;
  constructor(public workflow: WorkflowResponse){}
}

export class CreateError implements Action {
  readonly type = Types.CREATE_WORKFLOW_ERROR;
  constructor(public error: string) {}
}

export class Update implements Action {
  readonly type = Types.UPDATE_WORKFLOW;
  constructor(public workflow: WorkflowDatosgeneralesUpdateRequest){}
}

export class UpdateSuccess implements Action {
  readonly type = Types.UPDATE_WORKFLOW_SUCCESS;
  constructor(public workflow: WorkflowResponse){}
}

export class UpdateError implements Action {
  readonly type = Types.UPDATE_WORKFLOW_ERROR;
  constructor(public error: string) {}
}

//update nodo padre
export class UpdateNodopadre implements Action {
  readonly type = Types.UPDATE_WORKFLOW_NODOPADRE;
  constructor(public workflow: WorkflowNodopadreRequest){}
}

export class UpdateNodopadreSuccess implements Action {
  readonly type = Types.UPDATE_WORKFLOW_NODOPADRE_SUCCESS;
  constructor(public workflow: WorkflowResponse){}
}

export class UpdateNodopadreError implements Action {
  readonly type = Types.UPDATE_WORKFLOW_NODOPADRE_ERROR;
  constructor(public error: string) {}
}

//update nodo padre
export class UpdateConfiguracionweb implements Action {
  readonly type = Types.UPDATE_WORKFLOW_CONFIGURACIONWEB;
  constructor(public workflow: WorkflowConfiguracionwebRequest){}
}

export class UpdateConfiguracionwebSuccess implements Action {
  readonly type = Types.UPDATE_WORKFLOW_CONFIGURACIONWEB_SUCCESS;
  constructor(public workflow: WorkflowResponse){}
}

export class UpdateConfiguracionwebError implements Action {
  readonly type = Types.UPDATE_WORKFLOW_CONFIGURACIONWEB_ERROR;
  constructor(public error: string) {}
}

export class GetNodopadrebyid implements Action {
  readonly type = Types.GET_WORKFLOW_NODOPADRE;
  constructor(public id: string){}
}

export class GetNodopadrebyidSuccess implements Action {
  readonly type = Types.GET_WORKFLOW_NODOPADRE_SUCCESS;
  constructor(public workflow: WorkflowResponse){}
}

export class GetNodopadrebyidError implements Action {
  readonly type = Types.GET_WORKFLOW_NODOPADRE_ERROR;
  constructor(public error: string){}
}

//eliminar
export class Delete implements Action {
  readonly type = Types.DELETE_WORKFLOW;
  constructor(public id: string){}
}

export class DeleteSuccess implements Action {
  readonly type = Types.DELETE_WORKFLOW_SUCCESS;
  constructor(public workflows: WorkflowResponse[]){}
}

export class DeleteError implements Action {
  readonly type = Types.DELETE_WORKFLOW_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Activate implements Action {
  readonly type = Types.ACTIVATE_WORKFLOW;
  constructor(public workflows: WorkflowResponse[]){}
}


export class ActivateSuccess implements Action {
  readonly type = Types.ACTIVATE_WORKFLOW_SUCCESS;
  constructor(public workflows: WorkflowResponse[]){}
}

export class ActivateError implements Action {
  readonly type = Types.ACTIVATE_WORKFLOW_ERROR;
  constructor(public error: string) {}
}

//desactivar
export class Desactivate implements Action {
  readonly type = Types.DESACTIVATE_WORKFLOW;
  constructor(public workflows: WorkflowResponse[]){}
}

export class DesactivateSuccess implements Action {
  readonly type = Types.DESACTIVATE_WORKFLOW_SUCCESS;
  constructor(public workflows: WorkflowResponse[]){}
}

export class DesactivateError implements Action {
  readonly type = Types.DESACTIVATE_WORKFLOW_ERROR;
  constructor(public error: string) {}
}

export type All =
  Read | ReadSuccess | ReadError
| Getbyid | GetbyidSuccess | GetbyidError
| Create | CreateSuccess | CreateError
| Update | UpdateSuccess | UpdateError
| UpdateNodopadre | UpdateNodopadreSuccess | UpdateNodopadreError 
| UpdateConfiguracionweb | UpdateConfiguracionwebSuccess | UpdateConfiguracionwebError 
| GetNodopadrebyid | GetNodopadrebyidSuccess | GetNodopadrebyidError
| Delete | DeleteSuccess | DeleteError
| Desactivate | DesactivateSuccess | DesactivateError
| Activate | ActivateSuccess | ActivateError


