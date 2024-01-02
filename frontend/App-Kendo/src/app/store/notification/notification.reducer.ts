import { createReducer, on } from '@ngrx/store';
import { visualizar, onSuccess, onError, CambiarEstado } from './notification.actions';
import { visibleToast } from './notification.models';

const success: visibleToast = {
  visible:true,
  mensaje: 'El procedimiento fue exitoso',
  type: 'info',
}


const error: visibleToast = {
  visible:true,
  mensaje: 'Se encontraron errores en el proceso',
  type: 'error',
}



export const initialState:visibleToast = { visible:false, mensaje:'',type:'info' };

const _notificationReducer = createReducer(
   initialState,
   on(visualizar, (state, { toast })  => toast),
   on(onSuccess, (state, { success }) => success ),
   on(onError, (state,  { error })  => error),
   on(CambiarEstado, state => initialState ),
);

export function notificationReducer(state, action) {
  return _notificationReducer(state, action);
}

