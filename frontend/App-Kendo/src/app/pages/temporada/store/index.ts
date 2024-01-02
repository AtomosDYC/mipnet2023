import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TemporadaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TemporadaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTemporadaState = createFeatureSelector<TemporadaState>('temporada');




