import { createAction, props } from '@ngrx/store';
import { visibleToast } from './notification.models';

export const visualizar = createAction(
  '[Notification] Visualizar',
  props<{ toast: visibleToast }>()
  );

export const onSuccess = createAction(
  '[Notification] onsuccess',
  props<{ success: visibleToast }>()
);

export const onError = createAction(
  '[Notification] onerror',
  props<{ error: visibleToast }>()
);


export const CambiarEstado = createAction(
  '[Notification] Cambiarestado'
  );
