import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TipoParametroState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TipoParametroState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTipoParametroState = createFeatureSelector<TipoParametroState>('tipoparametro');




