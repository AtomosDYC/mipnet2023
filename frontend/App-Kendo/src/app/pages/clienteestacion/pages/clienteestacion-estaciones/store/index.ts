import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface EstacionState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<EstacionState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getEstacionState = createFeatureSelector<EstacionState>('estacion');
