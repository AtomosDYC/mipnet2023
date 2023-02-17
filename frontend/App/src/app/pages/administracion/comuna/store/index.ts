import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface ComunaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<ComunaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getComunaState = createFeatureSelector<ComunaState>('comuna');
