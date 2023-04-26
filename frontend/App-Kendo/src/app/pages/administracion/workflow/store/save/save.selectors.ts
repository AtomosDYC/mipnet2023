
import {createSelector} from '@ngrx/store';
import { getWorkflowState , WorkflowState} from '../index';

import { ListState } from './save.reducer';


export const getListState = createSelector(
  getWorkflowState,
  (state: WorkflowState) => state.list
)

export const getLoading = createSelector(
  getListState,
  (state: ListState) => state.loading
)

export const getWorkflows = createSelector(
  getListState,
  (state: ListState) => state.workflows
)

export const getWorkflowbyid = createSelector(
    getListState,
    (state: ListState) =>  state.workflow
  )

  /*
  export const getWorkflowNodopadrebyid = createSelector(
    getListState,
    (state: ListState) =>  state.workflow
  )
*/


