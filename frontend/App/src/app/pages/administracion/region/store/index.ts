import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface RegionState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<RegionState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getRegionState = createFeatureSelector<RegionState>('region');




