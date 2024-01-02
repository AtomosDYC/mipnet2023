import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface EspecieState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<EspecieState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getEspecieState = createFeatureSelector<EspecieState>('especie');




