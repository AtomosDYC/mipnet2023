import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface PlantillaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<PlantillaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getPlantillaState = createFeatureSelector<PlantillaState>('plantilla');




