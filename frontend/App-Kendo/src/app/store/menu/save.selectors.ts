import { createSelector, createFeatureSelector  } from '@ngrx/store';
import { MenuState } from './save.reducer'

export  const getMenuState = createFeatureSelector<MenuState>('Menu');

export const getMenu = createSelector(
  getMenuState,
  (state: MenuState) => state.menu
)

export const getLoading = createSelector(
  getMenuState,
  (state: MenuState) => state.loading
)

export const getExpanded = createSelector(
  getMenuState,
  (state: MenuState) => state.expand
)
