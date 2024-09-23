import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface EstacionActivaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<EstacionActivaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getEstacionActivaState = createFeatureSelector<EstacionActivaState>('estacion');
