import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface PersonaAccesoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<PersonaAccesoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getPersonaAccesoState = createFeatureSelector<PersonaAccesoState>('personaacceso');





