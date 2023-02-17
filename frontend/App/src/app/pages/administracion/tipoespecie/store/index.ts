import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TipoEspecieState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TipoEspecieState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTipoEspecieState = createFeatureSelector<TipoEspecieState>('tipoespecie');




