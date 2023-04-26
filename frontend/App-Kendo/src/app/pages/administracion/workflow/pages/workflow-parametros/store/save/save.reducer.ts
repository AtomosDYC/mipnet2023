import { WorkflowParametroResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  workflowparametros: WorkflowParametroResponse[] | null;
  workflowparametro: WorkflowParametroResponse | null;
  loading: boolean | null;
  error: string | null;
  success: boolean | null;
}

export const initialState: ListState = {
  workflowparametros: null,
  workflowparametro: null,
  loading: null,
  error: null,
  success: false,
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, workflowparametros: action.workflowparametros}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }

      case fromActions.Types.GET_WORKFLOWPARAMETRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_WORKFLOWPARAMETRO_SUCCESS: {
        return {...state, loading: false, workflowparametro: action.workflowparametro}
      }

      case fromActions.Types.GET_WORKFLOWPARAMETRO_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_WORKFLOWPARAMETRO: {
        return {...state, loading: true, error: null, success: false}
      }

      case fromActions.Types.CREATE_WORKFLOWPARAMETRO_SUCCESS: {
        return {...state, loading: false, error: null, workflowparametros: action.workflowparametros, success: action.success}
      }

      case fromActions.Types.CREATE_WORKFLOWPARAMETRO_ERROR : {
        return  {...state, loading: false, error: action.error, success: false}
      }


//Eliminar
      case fromActions.Types.DELETE_WORKFLOWPARAMETRO: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_WORKFLOWPARAMETRO_SUCCESS: {
        return {...state, loading: false, error: null, workflowparametros: action.workflowparametros}
      }

      case fromActions.Types.DELETE_WORKFLOWPARAMETRO_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

      default: {
        return state;
      }
      
    }


}
