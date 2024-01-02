import { createSelector, createFeatureSelector  } from '@ngrx/store';
import { ILoader } from './loader.models';

export const getLoaderState = createFeatureSelector<ILoader>('loader');


export const getLoader = createSelector(
    getLoaderState,
    (state) => state.success
)

