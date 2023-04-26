import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface EstadoDanioState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<EstadoDanioState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getEstadoDanioState = createFeatureSelector<EstadoDanioState>('estadodanio');
