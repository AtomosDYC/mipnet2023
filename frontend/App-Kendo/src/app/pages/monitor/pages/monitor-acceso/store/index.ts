import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface MonitorAccesoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<MonitorAccesoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getMonitorAccesoState = createFeatureSelector<MonitorAccesoState>('monitoracceso');





