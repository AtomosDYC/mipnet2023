import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TipoPerComunicacionCreateRequest, TipoPerComunicacionResponse } from './save.models';
import { environment } from '../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../store/index';
import { truncate } from 'fs';



type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  read: Observable<Action> = createEffect( () =>
      this.actions.pipe(
        ofType(fromActions.Types.READ),
        switchMap( () =>
          this.httpClient.get<TipoPerComunicacionResponse[]>(`${environment.url}api/TipoPersonaComunicacion`)
          .pipe(
            //delay(1000),
            map((tipopercomunicaciones: TipoPerComunicacionResponse[]) => new fromActions.ReadSuccess(tipopercomunicaciones) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TIPOPERCOMUNICACION),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TipoPerComunicacionResponse[]>(`${environment.url}api/tipopersonacomunicacion/GetTipoPerComunicacionById/${id}`)
        .pipe(
          map((tipopercomunicaciones: TipoPerComunicacionResponse[]) => new fromActions.GetbyidSuccess(tipopercomunicaciones)),
          
          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TIPOPERCOMUNICACION),
      map((action: fromActions.Create) => action.tipopercomunicacion),
      switchMap((request: TipoPerComunicacionCreateRequest) =>
        this.httpClient.post<TipoPerComunicacionResponse[]>(`${environment.url}api/TipoPersonaComunicacion`, request)
          .pipe(
            delay(1000),
            map((tipopercomunicaciones: TipoPerComunicacionResponse[]) => new fromActions.CreateSuccess(tipopercomunicaciones, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  delete: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_TIPOPERCOMUNICACION),
      map((action: fromActions.Delete) => action.tipopercomunicacion),
      switchMap((request: TipoPerComunicacionCreateRequest) =>
        this.httpClient.post<TipoPerComunicacionResponse[]>(`${environment.url}api/TipoPersonaComunicacion/borrarTipoPerComunicacion`, request)
          .pipe(
            delay(1000),
            map((tipopercomunicaciones: TipoPerComunicacionResponse[]) => new fromActions.DeleteSuccess(tipopercomunicaciones, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.DeleteError(err.message));
            })
          )
      )
    )
  );


}
