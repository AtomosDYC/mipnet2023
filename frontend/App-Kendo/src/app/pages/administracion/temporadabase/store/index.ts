import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TemporadaBaseState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TemporadaBaseState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTemporadaBaseState = createFeatureSelector<TemporadaBaseState>('temporadabase');




