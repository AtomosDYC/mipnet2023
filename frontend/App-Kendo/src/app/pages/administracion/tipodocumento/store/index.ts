import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface TipoDocumentoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<TipoDocumentoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getTipoDocumentoState = createFeatureSelector<TipoDocumentoState>('tipodocumento');




