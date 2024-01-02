import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface MonitorState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<MonitorState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getMonitorState = createFeatureSelector<MonitorState>('monitor');




