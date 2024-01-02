import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface MonitortrampaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<MonitortrampaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getMonitortrampaState = createFeatureSelector<MonitortrampaState>('monitortrampa');
