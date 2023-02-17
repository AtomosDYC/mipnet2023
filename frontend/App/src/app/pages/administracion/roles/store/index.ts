import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface RolState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<RolState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getRolState = createFeatureSelector<RolState>('rol');
