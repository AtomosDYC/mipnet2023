import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TipoFlujoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TipoFlujoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTipoFlujoState = createFeatureSelector<TipoFlujoState>('tipoflujo');




