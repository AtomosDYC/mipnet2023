
import {createSelector} from '@ngrx/store';
import { getMonitorcomunicacionState , MonitorcomunicacionState} from '../index';

import { ListState } from './save.reducer';
import { Personacomunicacion } from '../../../../../../models/backend/persona/index';

export const getListState = createSelector(
  getMonitorcomunicacionState,
  (state: MonitorcomunicacionState) => state.list
)

export const getLoadingComunicacion = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getMonitorcomunicaciones = createSelector(
  getListState,
  (state: ListState) => state.monitorcomunicacionsource
)

export const getMonitorcomunicacionbyid = createSelector(
  getListState,
  (state: ListState) =>  state.monitorcomunicacion
)


