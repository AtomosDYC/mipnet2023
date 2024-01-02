import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface EspecieTemporadaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<EspecieTemporadaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getEspecieTemporadaState = createFeatureSelector<EspecieTemporadaState>('especietemporada');




