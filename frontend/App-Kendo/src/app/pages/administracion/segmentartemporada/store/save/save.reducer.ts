import { SegmentarTemporadaResponse } from './save.models';
import * as fromActions from './save.actions';


export interface ListState {
  segmentartemporadas: SegmentarTemporadaResponse[] | null;
  segmentartemporada: SegmentarTemporadaResponse | null;
  loading: boolean | null;
  error: string | null;
}

export const initialState: ListState = {
  segmentartemporadas: null,
  segmentartemporada: null,
  loading: null,
  error: null
}


export function reducer(state: ListState = initialState, action: fromActions.All | any) {
    switch(action.type){

      case fromActions.Types.READ: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.READ_SUCCESS: {
        return {...state, loading: false, segmentartemporadas: action.segmentartemporadas}
      }

      case fromActions.Types.READ_ERROR: { 
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.GET_SEGMENTARTEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.GET_SEGMENTARTEMPORADA_SUCCESS: {
        return {...state, loading: false, segmentartemporada: action.segmentartemporada}
      }

      case fromActions.Types.GET_SEGMENTARTEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


//crear
      case fromActions.Types.CREATE_SEGMENTARTEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.CREATE_SEGMENTARTEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, segmentartemporada: action.segmentartemporada}
      }

      case fromActions.Types.CREATE_SEGMENTARTEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//actualizar
      case fromActions.Types.UPDATE_SEGMENTARTEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.UPDATE_SEGMENTARTEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, segmentartemporada: action.segmentartemporadas}
      }

      case fromActions.Types.UPDATE_SEGMENTARTEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }

//Eliminar
      case fromActions.Types.DELETE_SEGMENTARTEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DELETE_SEGMENTARTEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, segmentartemporadas: action.segmentartemporadas}
      }

      case fromActions.Types.DELETE_SEGMENTARTEMPORADA_ERROR : {
        return  {...state, loading: false, error: action.error}
      }



      case fromActions.Types.DESACTIVATE_SEGMENTARTEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.DESACTIVATE_SEGMENTARTEMPORADA_SUCCESS: {
        return {...state, loading: false, error: null, segmentartemporadas: action.segmentartemporadas}
      }

      case fromActions.Types.DESACTIVATE_SEGMENTARTEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }


      case fromActions.Types.ACTIVATE_SEGMENTARTEMPORADA: {
        return {...state, loading: true, error: null}
      }

      case fromActions.Types.ACTIVATE_SEGMENTARTEMPORADA_SUCCESS: {

        return {...state, loading: false, error: null, segmentartemporadas: action.segmentartemporadas}
      }

      case fromActions.Types.ACTIVATE_SEGMENTARTEMPORADA_ERROR: {
        return  {...state, loading: false, error: action.error}
      }




      default: {
        return state;
      }
    }


}
