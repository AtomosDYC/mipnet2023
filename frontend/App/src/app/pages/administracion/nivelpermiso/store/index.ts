import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface NivelPermisoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<NivelPermisoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getNivelPermisoState = createFeatureSelector<NivelPermisoState>('nivelpermiso');




