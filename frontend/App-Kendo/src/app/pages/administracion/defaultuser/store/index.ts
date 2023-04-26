import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface DefaultUserState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<DefaultUserState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getDefaultUserState = createFeatureSelector<DefaultUserState>('defaultuser');




