import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TemporadaBasesCreaterequest, TemporadaBaseResponse, TemporadaBasesResponse } from './save.models';
import { environment } from '../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../store/index';

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
          this.httpClient.get<TemporadaBaseResponse[]>(`${environment.url}api/temporadabase`)
          .pipe(
            //delay(1000),
            map((temporadabases: TemporadaBaseResponse[]) => new fromActions.ReadSuccess(temporadabases) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );


  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TEMPORADABASE),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TemporadaBaseResponse>(`${environment.url}api/temporadabase/GetTemporadaBaseById/${id}`)
        .pipe(
          map((temporadabase: TemporadaBaseResponse) => new fromActions.GetbyidSuccess(temporadabase)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );


  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TEMPORADABASE),
      map((action: fromActions.Create) => action.temporadabase),
      switchMap((request: TemporadaBasesCreaterequest) =>
        this.httpClient.post<TemporadaBaseResponse>(`${environment.url}api/temporadabase`, request)
          .pipe(
            delay(1000),
            tap((response: TemporadaBaseResponse) => {
              this.router.navigate(['dashboard/temporadas/temporadabase/list']);
            }),
            map((temporadabase: TemporadaBaseResponse) => new fromActions.CreateSuccess(temporadabase)),
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
      ofType(fromActions.Types.UPDATE_TEMPORADABASE),
      map((action: fromActions.Update) => action.temporadabase),
      switchMap((request: TemporadaBaseResponse) =>
        this.httpClient.put<TemporadaBaseResponse>(`${environment.url}api/temporadabase`, request)
          .pipe(
            delay(1000),
            tap((response: TemporadaBaseResponse) => {
              this.router.navigate(['dashboard/temporadas/temporadabase/list']);
            }),
            map((temporadabase: TemporadaBaseResponse) => new fromActions.UpdateSuccess(temporadabase)),
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
      ofType(fromActions.Types.DELETE_TEMPORADABASE),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TemporadaBaseResponse[]>(`${environment.url}api/temporadabase/${id}`)
        .pipe(
          map((temporadabases: TemporadaBaseResponse[]) => new fromActions.DeleteSuccess(temporadabases)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TEMPORADABASE),
      map((action: fromActions.Desactivate) => action.temporadabases),
      switchMap((temporadabases: TemporadaBaseResponse[]) => {
        return this.httpClient.post<TemporadaBaseResponse[]>(`${environment.url}api/temporadabase/disabletemporadabase/`, temporadabases)
        .pipe(
          map((temporadabases: TemporadaBaseResponse[]) => new fromActions.DesactivateSuccess(temporadabases)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TEMPORADABASE),
      map((action: fromActions.Activate) => action.temporadabases),
      switchMap((temporadabases: TemporadaBaseResponse[]) => {
        return this.httpClient.post<TemporadaBaseResponse[]>(`${environment.url}api/temporadabase/activatetemporadabase/`, temporadabases)
        .pipe(
          map((temporadabases: TemporadaBaseResponse[]) => new fromActions.ActivateSuccess(temporadabases)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
