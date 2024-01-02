import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TemporadaCreaterequest, TemporadaResponse, TemporadasResponse } from './save.models';
import { environment } from '../../../../../environments/environment';

import * as fromvisibleToast from '../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../store/index';

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
          this.httpClient.get<TemporadaResponse[]>(`${environment.url}api/temporada`)
          .pipe(
            //delay(1000),
            map((temporadas: TemporadaResponse[]) => new fromActions.ReadSuccess(temporadas) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );


  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TEMPORADA),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TemporadaResponse>(`${environment.url}api/temporada/GetTemporadaById/${id}`)
        .pipe(
          map((temporada: TemporadaResponse) => new fromActions.GetbyidSuccess(temporada)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );


  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TEMPORADA),
      map((action: fromActions.Create) => action.temporada),
      switchMap((request: TemporadaCreaterequest) =>
        this.httpClient.post<TemporadaResponse>(`${environment.url}api/temporada`, request)
          .pipe(
            delay(1000),
            tap((response: TemporadaResponse) => {
              this.router.navigate(['dashboard/temporada/temporada/list']);
            }),
            map((temporada: TemporadaResponse) => new fromActions.CreateSuccess(temporada)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  update: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_TEMPORADA),
      map((action: fromActions.Update) => action.temporada),
      switchMap((request: TemporadaResponse) =>
        this.httpClient.put<TemporadaResponse>(`${environment.url}api/temporada`, request)
          .pipe(
            delay(1000),
            tap((response: TemporadaResponse) => {
              this.router.navigate(['dashboard/temporada/temporada/list']);
            }),
            map((temporada: TemporadaResponse) => new fromActions.UpdateSuccess(temporada)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  Delete: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_TEMPORADA),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TemporadaResponse[]>(`${environment.url}api/temporada/${id}`)
        .pipe(
          map((temporadas: TemporadaResponse[]) => new fromActions.DeleteSuccess(temporadas)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TEMPORADA),
      map((action: fromActions.Desactivate) => action.temporadas),
      switchMap((temporadas: TemporadaResponse[]) => {
        return this.httpClient.post<TemporadaResponse[]>(`${environment.url}api/temporada/disabletemporada/`, temporadas)
        .pipe(
          map((temporadas: TemporadaResponse[]) => new fromActions.DesactivateSuccess(temporadas)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TEMPORADA),
      map((action: fromActions.Activate) => action.temporadas),
      switchMap((temporadas: TemporadaResponse[]) => {
        return this.httpClient.post<TemporadaResponse[]>(`${environment.url}api/temporada/activatetemporada/`, temporadas)
        .pipe(
          map((temporadas: TemporadaResponse[]) => new fromActions.ActivateSuccess(temporadas)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
