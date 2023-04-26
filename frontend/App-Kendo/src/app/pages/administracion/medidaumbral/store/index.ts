import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface MedidaUmbralState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<MedidaUmbralState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getMedidaUmbralState = createFeatureSelector<MedidaUmbralState>('medidaumbral');
