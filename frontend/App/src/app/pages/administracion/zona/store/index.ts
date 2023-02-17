import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface ZonaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<ZonaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getZonaState = createFeatureSelector<ZonaState>('zona');
