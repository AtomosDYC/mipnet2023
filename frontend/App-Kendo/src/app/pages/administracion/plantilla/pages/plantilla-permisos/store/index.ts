import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface PlantillaflujoState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<PlantillaflujoState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getPlantillaflujoState = createFeatureSelector<PlantillaflujoState>('plantillaflujo');




