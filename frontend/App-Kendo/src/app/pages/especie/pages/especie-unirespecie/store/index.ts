import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface UnirEspecieState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<UnirEspecieState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getUnirEspecieState = createFeatureSelector<UnirEspecieState>('unirespecie');




