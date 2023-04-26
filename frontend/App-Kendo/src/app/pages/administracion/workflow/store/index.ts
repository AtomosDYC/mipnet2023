import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface WorkflowState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<WorkflowState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getWorkflowState = createFeatureSelector<WorkflowState>('workflow');




