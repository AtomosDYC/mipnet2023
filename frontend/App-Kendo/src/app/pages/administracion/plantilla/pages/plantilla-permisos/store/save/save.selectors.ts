
import {createSelector} from '@ngrx/store';
import { getPlantillaflujoState , PlantillaflujoState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getPlantillaflujoState,
  (state: PlantillaflujoState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getPlantillaflujos = createSelector(
  getListState,
  (state: ListState) => state.plantillaflujos
)

export const getPlantillaflujobyid = createSelector(
    getListState,
    (state: ListState) =>  state.plantillaflujo
  )



