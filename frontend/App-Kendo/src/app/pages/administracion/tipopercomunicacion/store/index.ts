import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TipoPerComunicacionState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TipoPerComunicacionState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTipoPerComunicacionState = createFeatureSelector<TipoPerComunicacionState>('tipopercomunicacion');




