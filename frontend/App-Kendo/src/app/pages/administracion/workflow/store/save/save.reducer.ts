import { WorkflowResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  workflows: WorkflowResponse[] | null;
  workflow: WorkflowResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  workflows: null,
  workflow: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, workflows: action.workflows}
      }

      case fromActions.Types.READ_ERROR: {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_WORKFLOW: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_WORKFLOW_SUCCESS: {
        return {...state, loading: false, workflow: action.workflow}
      }

      case fromActions.Types.GET_WORKFLOW_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_WORKFLOW: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_WORKFLOW_SUCCESS: {
        return {...state, loading: false, error: null, workflow: action.workflow}
      }

      case fromActions.Types.CREATE_WORKFLOW_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
    case fromActions.Types.UPDATE_WORKFLOW_NODOPADRE: {
      return {...state, loading: true, error: null}
    }

    case fromActions.Types.UPDATE_WORKFLOW_NODOPADRE_SUCCESS: {
      return {...state, loading: false, error: null, workflow: action.workflows}
    }

    case fromActions.Types.UPDATE_WORKFLOW_NODOPADRE_ERROR : {
      return  {...state, loading: false, error: action.error}
    }

//actualizar
    case fromActions.Types.UPDATE_WORKFLOW_CONFIGURACIONWEB: {
      return {...state, loading: true, error: null}
    }

    case fromActions.Types.UPDATE_WORKFLOW_CONFIGURACIONWEB_SUCCESS: {
      return {...state, loading: false, error: null, workflow: action.workflows}
    }

    case fromActions.Types.UPDATE_WORKFLOW_CONFIGURACIONWEB_ERROR : {
      return  {...state, loading: false, error: action.error}
    }

//actualizar nodo padre
    case fromActions.Types.UPDATE_WORKFLOW: {
      return {...state, loading: true, error: null}
    }

    case fromActions.Types.UPDATE_WORKFLOW_SUCCESS: {
      return {...state, loading: false, error: null, workflow: action.workflows}
    }

    case fromActions.Types.UPDATE_WORKFLOW_ERROR : {
      return  {...state, loading: false, error: action.error}
    }


/*
    case fromActions.Types.GET_WORKFLOW_NODOPADRE: {
      return {...state, loading: true, error: null}
    }

    case fromActions.Types.GET_WORKFLOW_NODOPADRE_SUCCESS: {
      return {...state, loading: false, workflow: action.workflow}
    }

    case fromActions.Types.GET_WORKFLOW_NODOPADRE_ERROR: {
      return  {...state, loading: false, error: action.error}
    }

*/

//Eliminar
      case fromActions.Types.DELETE_WORKFLOW: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_WORKFLOW_SUCCESS: {
        return {...state, loading: false, error: null, workflows: action.workflows}
      }

      case fromActions.Types.DELETE_WORKFLOW_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_WORKFLOW: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_WORKFLOW_SUCCESS: {
        return {...state, loading: false, error: null, workflows: action.workflows}
      }

      case fromActions.Types.DESACTIVATE_WORKFLOW_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_WORKFLOW: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_WORKFLOW_SUCCESS: {

        return {...state, loading: false, error: null, workflows: action.workflows}
      }

      case fromActions.Types.ACTIVATE_WORKFLOW_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
