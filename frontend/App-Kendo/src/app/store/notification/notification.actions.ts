import { createAction, props } from '@ngrx/store';
import { visibleToast } from './notification.models';

export const visualizar = createAction(
  '[Notification] Visualizar',
  props<{ toast: visibleToast }>()
  );

export const onSuccess = createAction(
  '[Notification] onsuccess'
);

export const onError = createAction(
  '[Notification] onsuccess'
);


export const CambiarEstado = createAction(
  '[Notification] Cambiarestado'
  );
