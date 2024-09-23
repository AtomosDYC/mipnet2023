import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TemporadaBasesCreaterequest, TemporadaBaseResponse, TemporadaBasesResponse, TemporadabasedesactivateResponse } from './save.models';
import { environment } from '../../../../../../environments/environment';

import { State as RequestState } from "@progress/kendo-data-query";

import * as fromvisibleToast from '../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../store/index';
import { GridDataResult } from '@progress/kendo-angular-grid';

type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  readtemporadabase: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_TEMPORADABASE),
      map((action: fromActions.Readtemporadabase) => action.temporadabase),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/temporadabase/gettemporadabases`, request)
        .pipe(
          //delay(1000),
          map((temporadabasesource: GridDataResult) => new fromActions.ReadtemporadabaseSuccess(temporadabasesource)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
            return of(new fromActions.ReadtemporadabaseError(err.message));
          })
        )
      )
    )
  );


  getbyidtemporadabase: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TEMPORADABASE),
      map((action: fromActions.Getbyidtemporadabase) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TemporadaBaseResponse>(`${environment.url}api/temporadabase/GetTemporadaBaseById/${id}`)
        .pipe(
          map((temporadabase: TemporadaBaseResponse) => new fromActions.GetbyidtemporadabaseSuccess(temporadabase)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'No hay Temporadas Bases Registrados al ID ingresado', type:'error'}}));
            return of(new fromActions.GetbyidtemporadabaseError(err.message));
          })
        )
      }
      )
    )
  );


  createtemporadabase: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TEMPORADABASE),
      map((action: fromActions.Createtemporadabase) => action.temporadabase),
      switchMap((request: TemporadaBasesCreaterequest) =>
        this.httpClient.post<TemporadaBaseResponse>(`${environment.url}api/temporadabase/CreateTemporadaBase`, request)
          .pipe(
            delay(1000),
            tap((response: TemporadaBaseResponse) => {
              this.router.navigate(['dashboard/temporadas/temporadabase/list']);
            }),
            map((temporadabase: TemporadaBaseResponse) => new fromActions.CreatetemporadabaseSuccess(temporadabase)),
            catchError(err => {
              if(err){
                this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              }
              return of(new fromActions.CreatetemporadabaseError(err.message));
            })
          )
      )
    )
  );

  updatetemporadabase: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_TEMPORADABASE),
      map((action: fromActions.Updatetemporadabase) => action.temporadabase),
      switchMap((request: TemporadaBaseResponse) =>
        this.httpClient.put<TemporadaBaseResponse>(`${environment.url}api/temporadabase`, request)
          .pipe(
            delay(1000),
            tap((response: TemporadaBaseResponse) => {
              this.router.navigate(['dashboard/temporadas/temporadabase/list']);
            }),
            map((temporadabase: TemporadaBaseResponse) => new fromActions.UpdatetemporadabaseSuccess(temporadabase)),
            catchError(err => {
              if(err){
                this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              }
              return of(new fromActions.UpdatetemporadabaseError(err.message));
            })
          )
      )
    )
  );

  Deletetemporadabase: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_TEMPORADABASE),
      map((action: fromActions.Deletetemporadabase) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TemporadaBaseResponse[]>(`${environment.url}api/temporadabase/${id}`)
        .pipe(
          map((temporadabases: TemporadaBaseResponse[]) => new fromActions.DeletetemporadabaseSuccess(temporadabases)),

          catchError(err => {
            if(err){
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            }
            return of(new fromActions.DeletetemporadabaseError(err.message));
          })

        )
      }
      )
    )
  );

  Desactivatetemporadabase: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TEMPORADABASE),
      map((action: fromActions.Desactivatetemporadabase) => action.temporadabases),
      switchMap((temporadabases: TemporadabasedesactivateResponse) => {
        return this.httpClient.post<GridDataResult>(`${environment.url}api/temporadabase/disabletemporadabase/`, temporadabases)
        .pipe(
          map((temporadabasesource: GridDataResult) => new fromActions.DesactivatetemporadabaseSuccess(temporadabasesource)),

          catchError(err => {
            if(err){
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            }
            return of(new fromActions.DesactivatetemporadabaseError(err.message));
          })

        )
      }

      )
    )
  );

  Activatetemporadabase: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TEMPORADABASE),
      map((action: fromActions.Activatetemporadabase) => action.temporadabases),
      switchMap((temporadabases: TemporadabasedesactivateResponse) => {
        return this.httpClient.post<GridDataResult>(`${environment.url}api/temporadabase/activatetemporadabase/`, temporadabases)
        .pipe(
          map((temporadabasesource: GridDataResult) => new fromActions.ActivatetemporadabaseSuccess(temporadabasesource)),

          catchError(err => {
            if(err){
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            }
            return of(new fromActions.ActivatetemporadabaseError(err.message));
          })
        )
      }
      )
    )
  );

}
