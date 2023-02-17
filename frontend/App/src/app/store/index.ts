import { ActionReducerMap } from '@ngrx/store';
import * as fromUser from './user';
import * as fromvisibleToast  from './notification';

export interface State {
  user: fromUser.UserState,
  visibleToast: fromvisibleToast.visibleToast;
}

export const reducers: ActionReducerMap<State> = {
  user: fromUser.reducer,
  visibleToast: fromvisibleToast.notificationReducer
}

export const effects = [
  fromUser.UserEffects
]
