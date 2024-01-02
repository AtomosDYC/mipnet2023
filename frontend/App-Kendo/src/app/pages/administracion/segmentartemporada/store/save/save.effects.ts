import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { SegmentarTemporadasCreaterequest, SegmentarTemporadaResponse, SegmentarTemporadasResponse } from './save.models';
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
          this.httpClient.get<SegmentarTemporadaResponse[]>(`${environment.url}api/segmentartemporada`)
          .pipe(
            //delay(1000),
            map((segmentartemporadas: SegmentarTemporadaResponse[]) => new fromActions.ReadSuccess(segmentartemporadas) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );


  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_SEGMENTARTEMPORADA),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<SegmentarTemporadaResponse>(`${environment.url}api/segmentartemporada/GetSegmentarTemporadaById/${id}`)
        .pipe(
          map((segmentartemporada: SegmentarTemporadaResponse) => new fromActions.GetbyidSuccess(segmentartemporada)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );


  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_SEGMENTARTEMPORADA),
      map((action: fromActions.Create) => action.segmentartemporada),
      switchMap((request: SegmentarTemporadasCreaterequest) =>
        this.httpClient.post<SegmentarTemporadaResponse>(`${environment.url}api/segmentartemporada`, request)
          .pipe(
            delay(1000),
            tap((response: SegmentarTemporadaResponse) => {
              this.router.navigate(['dashboard/temporadas/segmentartemporada/list']);
            }),
            map((segmentartemporada: SegmentarTemporadaResponse) => new fromActions.CreateSuccess(segmentartemporada)),
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
      ofType(fromActions.Types.UPDATE_SEGMENTARTEMPORADA),
      map((action: fromActions.Update) => action.segmentartemporada),
      switchMap((request: SegmentarTemporadaResponse) =>
        this.httpClient.put<SegmentarTemporadaResponse>(`${environment.url}api/segmentartemporada`, request)
          .pipe(
            delay(1000),
            tap((response: SegmentarTemporadaResponse) => {
              this.router.navigate(['dashboard/temporadas/segmentartemporada/list']);
            }),
            map((segmentartemporada: SegmentarTemporadaResponse) => new fromActions.UpdateSuccess(segmentartemporada)),
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
      ofType(fromActions.Types.DELETE_SEGMENTARTEMPORADA),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<SegmentarTemporadaResponse[]>(`${environment.url}api/segmentartemporada/${id}`)
        .pipe(
          map((segmentartemporadas: SegmentarTemporadaResponse[]) => new fromActions.DeleteSuccess(segmentartemporadas)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_SEGMENTARTEMPORADA),
      map((action: fromActions.Desactivate) => action.segmentartemporadas),
      switchMap((segmentartemporadas: SegmentarTemporadaResponse[]) => {
        return this.httpClient.post<SegmentarTemporadaResponse[]>(`${environment.url}api/segmentartemporada/disablesegmentartemporada/`, segmentartemporadas)
        .pipe(
          map((segmentartemporadas: SegmentarTemporadaResponse[]) => new fromActions.DesactivateSuccess(segmentartemporadas)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_SEGMENTARTEMPORADA),
      map((action: fromActions.Activate) => action.segmentartemporadas),
      switchMap((segmentartemporadas: SegmentarTemporadaResponse[]) => {
        return this.httpClient.post<SegmentarTemporadaResponse[]>(`${environment.url}api/segmentartemporada/activatesegmentartemporada/`, segmentartemporadas)
        .pipe(
          map((segmentartemporadas: SegmentarTemporadaResponse[]) => new fromActions.ActivateSuccess(segmentartemporadas)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
