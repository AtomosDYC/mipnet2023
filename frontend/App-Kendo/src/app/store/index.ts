import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';
import * as fromUser from './user';
import * as fromvisibleToast  from './notification';
import * as FromMenu from './menu';
import * as FromLoader from './loader';

export interface State {
  user: fromUser.UserState,
  visibleToast: fromvisibleToast.visibleToast,
  Menu: FromMenu.MenuState;
  loader : FromLoader.ILoader
}

export const reducers: ActionReducerMap<State> = {
  user: fromUser.reducer,
  visibleToast: fromvisibleToast.notificationReducer,
  Menu: FromMenu.reducer,
  loader: FromLoader.reducer
}

export const effects = [
  fromUser.UserEffects,
  FromMenu.MenuEffects
]
