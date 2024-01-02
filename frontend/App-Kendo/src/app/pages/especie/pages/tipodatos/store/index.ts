import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface DanioEspecieState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<DanioEspecieState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getDanioEspecieState = createFeatureSelector<DanioEspecieState>('danioespecie');




