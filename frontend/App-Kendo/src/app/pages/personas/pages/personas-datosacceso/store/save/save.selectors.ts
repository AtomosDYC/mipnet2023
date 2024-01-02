
import {createSelector} from '@ngrx/store';
import { getPersonaAccesoState , PersonaAccesoState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getPersonaAccesoState,
  (state: PersonaAccesoState) => state.list
)

export const getLoadingAcceso = createSelector(
  getListState,
  (state: ListState) => state.loading
)


export const GetPersonaAccesobyid = createSelector(
  getListState,
  (state: ListState) =>  state.personaacceso
)


