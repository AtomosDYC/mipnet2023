import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface MonitorsincronizacionState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<MonitorsincronizacionState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getMonitorsincronizacionState = createFeatureSelector<MonitorsincronizacionState>('monitorsincronizacion');
