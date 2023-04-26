import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface WorkflowParametroState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<WorkflowParametroState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getWorkflowParametroState = createFeatureSelector<WorkflowParametroState>('workflowparametro');




