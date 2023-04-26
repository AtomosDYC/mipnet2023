import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface SaludoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<SaludoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getSaludoState = createFeatureSelector<SaludoState>('saludo');




