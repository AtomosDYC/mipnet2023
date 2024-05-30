
import {createSelector} from '@ngrx/store';
import { getClienteestacioncontactoState , ClienteestacioncontactoState} from '../index';

import { ListState } from './save.reducer';

export const getListState = createSelector(
  getClienteestacioncontactoState,
  (state: ClienteestacioncontactoState) => state.list
)

export const getLoadingContacto = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getClienteestacioncontactoes = createSelector(
  getListState,
  (state: ListState) => state.clienteestacioncontactosource
)

export const getClienteestacioncontactobyidselector = createSelector(
  getListState,
  (state: ListState) =>  state.clienteestacioncontacto
)

export const getPersonabyrutselector = createSelector(
  getListState,
  (state: ListState) =>  state.persona
)



