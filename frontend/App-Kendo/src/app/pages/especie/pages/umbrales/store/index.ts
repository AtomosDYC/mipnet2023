import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface EspecieUmbralState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<EspecieUmbralState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getEspecieUmbralState = createFeatureSelector<EspecieUmbralState>('especieumbral');




