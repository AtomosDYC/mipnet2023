import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TipoPermisoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TipoPermisoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTipoPermisoState = createFeatureSelector<TipoPermisoState>('tipopermiso');




