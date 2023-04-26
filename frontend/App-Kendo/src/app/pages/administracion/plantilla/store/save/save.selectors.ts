
import {createSelector} from '@ngrx/store';
import { getPlantillaState , PlantillaState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getPlantillaState,
  (state: PlantillaState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getPlantillas = createSelector(
  getListState,
  (state: ListState) => state.plantillas
)

export const getPlantillabyid = createSelector(
    getListState,
    (state: ListState) =>  state.plantilla
  )



