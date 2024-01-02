import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface PersonaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<PersonaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getPersonaState = createFeatureSelector<PersonaState>('persona');





