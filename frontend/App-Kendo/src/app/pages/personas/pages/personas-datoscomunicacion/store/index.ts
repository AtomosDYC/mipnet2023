import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

export interface PersonacomunicacionState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<PersonacomunicacionState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getPersonacomunicacionState = createFeatureSelector<PersonacomunicacionState>('personacomunicacion');





