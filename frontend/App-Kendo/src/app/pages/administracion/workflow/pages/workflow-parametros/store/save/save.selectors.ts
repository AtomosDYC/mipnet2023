
import {createSelector} from '@ngrx/store';
import { getWorkflowParametroState , WorkflowParametroState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getWorkflowParametroState,
  (state: WorkflowParametroState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getSuccess = createSelector(
  getListState,
  (state: ListState) => state.success
)

export const getWorkflowParametros = createSelector(
  getListState,
  (state: ListState) => state.workflowparametros
)

export const getWorkflowParametrobyid = createSelector(
    getListState,
    (state: ListState) =>  state.workflowparametro
  )



