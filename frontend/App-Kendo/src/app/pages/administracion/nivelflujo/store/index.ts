import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface NivelFlujoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<NivelFlujoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getNivelFlujoState = createFeatureSelector<NivelFlujoState>('nivelflujo');




