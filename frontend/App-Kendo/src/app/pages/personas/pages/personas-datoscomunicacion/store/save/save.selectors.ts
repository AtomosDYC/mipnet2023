
import {createSelector} from '@ngrx/store';
import { getPersonacomunicacionState , PersonacomunicacionState} from '../index';

import { ListState } from './save.reducer';
import { Personacomunicacion } from '../../../../../../models/backend/persona/index';

export const getListState = createSelector(
  getPersonacomunicacionState,
  (state: PersonacomunicacionState) => state.list
)

export const getLoadingComunicacion = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getPersonacomunicaciones = createSelector(
  getListState,
  (state: ListState) => state.personacomunicacionsource
)

export const getPersonacomunicacionbyid = createSelector(
  getListState,
  (state: ListState) =>  state.personacomunicacion
)


