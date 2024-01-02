import * as fromList from './save/save.reducer';
import { SaveEffects } from './save/save.effects';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';


export interface SegmentarTemporadaState {
  list: fromList.ListState;
}

export const reducers : ActionReducerMap<SegmentarTemporadaState> = {
  list: fromList.reducer
}

export const effects : any = [
  SaveEffects
]

export const getSegmentarTemporadaState = createFeatureSelector<SegmentarTemporadaState>('segmentartemporada');




