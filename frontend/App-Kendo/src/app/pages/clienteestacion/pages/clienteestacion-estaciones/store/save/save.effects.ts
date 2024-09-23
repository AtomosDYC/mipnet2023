import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { EstacionResponse, EstacionRequest, EstacionbyidRequest } from './save.models';

import { environment } from '../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../store/index';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";

type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  ReadEstacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_ESTACION),
      map((action: fromActions.ReadEstacion) => action.Estacion),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/clienteestacion/getestaciones`, request)
          .pipe(
            map((Estacionsource: GridDataResult) => new fromActions.ReadEstacionSuccess(Estacionsource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadEstacionError(err.message));
            })
          )
      )
    )
  );
  
  GetEstacionbyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_ESTACION_BYID),
    map((action: fromActions.GetEstacionbyid) => action.requestbyid),
    switchMap((requestbyid: EstacionbyidRequest) => {
      return this.httpClient.post<EstacionResponse>(`${environment.url}api/clienteestacion/getEstacionbyid/`, requestbyid)
      .pipe(
        map((Estacion: EstacionResponse) => new fromActions.GetEstacionbyidSuccess(Estacion)),

        catchError(err => {
          this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
          return of(new fromActions.GetEstacionbyidError(err.message));
        })
      )
    }
    )
  )
);

createEstacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_ESTACION),
      map((action: fromActions.CreateEstacion) => action.Estacion),
      switchMap((request: EstacionRequest) =>
        this.httpClient.post<EstacionResponse>(`${environment.url}api/Estacion/createEstacion`, request)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Datos de comunicacón actualizado', type:'success'}}));
            }),
            map((Estacion: EstacionResponse) => new fromActions.CreateEstacionSuccess(Estacion, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              return of(new fromActions.CreateEstacionError(err.message));
            })
          )
      )
    )
  );

  deleteEstacion: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.DELETE_ESTACION),
    map((action: fromActions.DeleteEstacion) => action.requestbyid),
    switchMap((requestbyid: EstacionbyidRequest) => 
      this.httpClient.post(`${environment.url}api/Estacion/deleteEstacion`, requestbyid)
        .pipe(
          delay(1000),
          map(() => new fromActions.DeleteEstacionSuccess(true)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
            return of(new fromActions.DeleteEstacionError(err.message));
          })
          )
      )
    )
  );

}
