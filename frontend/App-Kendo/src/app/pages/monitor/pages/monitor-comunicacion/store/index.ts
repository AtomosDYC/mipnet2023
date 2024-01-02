import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface MonitorcomunicacionState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<MonitorcomunicacionState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getMonitorcomunicacionState = createFeatureSelector<MonitorcomunicacionState>('monitorcomunicacion');
