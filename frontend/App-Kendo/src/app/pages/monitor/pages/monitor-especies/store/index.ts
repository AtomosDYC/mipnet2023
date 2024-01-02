import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface MonitorespecieState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<MonitorespecieState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getMonitorespecieState = createFeatureSelector<MonitorespecieState>('monitorespecie');
