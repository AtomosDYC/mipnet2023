import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import * as fromvisibleToast from '../../../../store/notification/notification.actions';

import { EspecieTemporadaResponse, EspecieTemporadaRequest, EspecieTemporadaRequestUpdate, EspecieTemporadaRequestActivate } from './save.models';

import { environment } from '../../../../../environments/environment';

import { Store } from '@ngrx/store';
import { State } from '../../../../store/index';
import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { datasourcerequest } from '../../../../models/frontend/datasource/request';

import { visibleToast } from './../../../../store/notification/notification.models';
import { getEspecieTemporadabyid } from './save.selectors';
import { GetEspecieTemporadabyid, DesactivateEspecieTemporada, ActivateEspecieTemporada, ActivateEspecieTemporadaSuccess } from './save.actions';


type Action = fromActions.All;

@Injectable()
export class SaveEffects {


  private error: visibleToast = {
    visible:true,
    mensaje: 'Se encontraron errores en el proceso',
    type: 'error',
  }

  
  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  
  ReadMonitor: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.READ_ESPECIETEMPORADA),
    map((action: fromActions.ReadEspecieTemporada) => action.especietemporada),
    switchMap((request: RequestState) =>
      this.httpClient.post<GridDataResult>(`${environment.url}api/especietemporada/getespecietemporada`, request)
        .pipe(
          map((especietemporadasource: GridDataResult) => new fromActions.ReadEspecieTemporadaSuccess(especietemporadasource)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.ReadEspecieTemporadaError(err.message));
          })
        )
    )
  )
);


  getEspecieTemporadabyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_ESPECIETEMPORADA),
    map((action: fromActions.GetEspecieTemporadabyid) => action.id),
    switchMap((id: string) => {
      return this.httpClient.get<EspecieTemporadaResponse>(`${environment.url}api/especietemporada/getespecietemporadabyid/${id}`)
      .pipe(
        map((especietemporada: EspecieTemporadaResponse) => new fromActions.GetEspecieTemporadabyidSuccess(especietemporada)),
        catchError(err => of(new fromActions.GetEspecieTemporadabyidError(err.message)))
      )
    }
    )
  )
);


createespecietemporada: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_ESPECIETEMPORADA),
      map((action: fromActions.CreateEspecieTemporada) => action.especietemporada),
      switchMap((request: EspecieTemporadaRequest) =>
        this.httpClient.post<EspecieTemporadaResponse>(`${environment.url}api/especietemporada/createespecietemporada`, request)
          .pipe(
            delay(1000),
            tap((response: EspecieTemporadaResponse) => {
              const id = response.esp02llave;
              this.router.navigate([`dashboard/especies/especietemporada/list`]); 
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Especie Temporada grabada con éxito', type:'success'}}));
            }),
            map((especietemporada: EspecieTemporadaResponse) => new fromActions.CreateEspecieTemporadaSuccess(especietemporada, true)),
            catchError(err => {
              //console.log(err);
              if(err){
                this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              }
              return of(new fromActions.CreateEspecieTemporadaError(err.message));
            })
          )
      )
    )
  );

  updateespecietemporada: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.UPDATE_ESPECIETEMPORADA),
    map((action: fromActions.UpdateEspecieTemporada) => action.especietemporada),
    switchMap((request: EspecieTemporadaRequestUpdate) =>
      this.httpClient.put<EspecieTemporadaResponse>(`${environment.url}api/especietemporada`, request)
        .pipe(
          delay(1000),
          tap((response: EspecieTemporadaResponse) => {

            //console.log('response', response);
            this.store.dispatch(fromvisibleToast.onSuccess({success: {visible:true, mensaje:'Especie Temporada Actualizada con Éxito', type:'success'}}));
            this.router.navigate([`dashboard/especies/especietemporada/list`]); 
          }),

          map(() => new fromActions.UpdateEspecieTemporadaSuccess(true)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.UpdateEspecieTemporadaError(err.message));
          })
        )
    )
  )
);

Delete: Observable<Action> = createEffect(() =>
this.actions.pipe(
  ofType(fromActions.Types.DELETE_ESPECIETEMPORADA),
  map((action: fromActions.DeleteEspecieTemporada) => action.id),
  switchMap((id: string) => {
    return this.httpClient.get(`${environment.url}api/especietemporada/DeleteEspecieTemporada/${id}`)
    .pipe(
      map(() => new fromActions.DeleteEspecieTemporadaSuccess(true)),

      catchError(err => 
        {
          this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
          return of(new fromActions.UpdateEspecieTemporadaError(err.message));
        })
    )
  }
  )
)
);

DesactivateEspecieTemporada: Observable<Action> = createEffect(() =>
this.actions.pipe(
  ofType(fromActions.Types.DESACTIVATE_ESPECIETEMPORADA),
  map((action: fromActions.DesactivateEspecieTemporada) => action.especietemporadas),
  switchMap((especietemporadas: EspecieTemporadaRequestActivate[]) => {
    return this.httpClient.post(`${environment.url}api/especietemporada/disableespecietemporada/`, especietemporadas)
    .pipe(
      map(() => new fromActions.DesactivateEspecieTemporadaSuccess(true)),

      catchError(err => {
        this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
        return of(new fromActions.DesactivateEspecieTemporadaError(err.message));
      })
    )
  }
  )
)
);

ActivateEspecieTemporada: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_ESPECIETEMPORADA),
      map((action: fromActions.ActivateEspecieTemporada) => action.especietemporadas),
      switchMap((especietemporadas: EspecieTemporadaRequestActivate[]) => {
        return this.httpClient.post(`${environment.url}api/especietemporada/ActivateespecieTemporada`, especietemporadas)
        .pipe(
          map(() => new fromActions.ActivateEspecieTemporadaSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.ActivateEspecieTemporadaError(err.message));
          })
        )
      }
      )
    )
  );



}
