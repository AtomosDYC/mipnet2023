import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { MonitorcomunicacionResponse, MonitorcomunicacionRequest, MonitorcomunicacionbyidRequest } from './save.models';
import { environment } from '../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../store/index';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { getMonitorcomunicacionbyid } from './save.selectors';


type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }


  ReadMonitorcomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_MONITOR_COMUNICACION),
      map((action: fromActions.ReadMonitorcomunicacion) => action.monitorcomunicacion),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/monitor/getmonitorcomunicacion`, request)
          .pipe(
            map((monitorcomunicacionsource: GridDataResult) => new fromActions.ReadMonitorcomunicacionSuccess(monitorcomunicacionsource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadMonitorcomunicacionError(err.message));
            })
          )
      )
    )
  );

  
  getmonitorcomunicacionbyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_MONITOR_COMUNICACION),
    map((action: fromActions.GetMonitorCommunicacionbyid) => action.requestbyid),
    switchMap((requestbyid: MonitorcomunicacionbyidRequest) => {
      return this.httpClient.post<MonitorcomunicacionResponse>(`${environment.url}api/monitor/getmonitorcomunicacionbyid/`, requestbyid)
      .pipe(
        map((monitorcomunicacion: MonitorcomunicacionResponse) => new fromActions.GetMonitorCommunicacionbyidSuccess(monitorcomunicacion)),

        catchError(err => {
          this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
          return of(new fromActions.GetMonitorCommunicacionbyidError(err.message));
        })
      )
    }
    )
  )
);

createmonitorcomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_MONITOR_COMUNICACION),
      map((action: fromActions.CreateMonitorcomunicacion) => action.monitorcomunicacion),
      switchMap((request: MonitorcomunicacionRequest) =>
        this.httpClient.post<MonitorcomunicacionResponse>(`${environment.url}api/monitor/createmonitorcomunicacion`, request)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Datos de comunicacón actualizado', type:'success'}}));
            }),
            map((monitorcomunicacion: MonitorcomunicacionResponse) => new fromActions.CreateMonitorcomunicacionSuccess(monitorcomunicacion, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              return of(new fromActions.CreateMonitorcomunicacionError(err.message));
            })
          )
      )
    )
  );

  deletemonitorcomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_MONITOR_COMUNICACION),
      map((action: fromActions.DeleteMonitorcomunicacion) => action.requestbyid),
      switchMap((requestbyid: MonitorcomunicacionbyidRequest) => 
        this.httpClient.post(`${environment.url}api/monitor/deletemonitorcomunicacion`, requestbyid)
          .pipe(
            delay(1000),
            map(() => new fromActions.DeleteMonitorcomunicacionSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.DeleteMonitorcomunicacionError(err.message));
            })
            )
        )
      )
    );

/*
  updatemonitor: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_MONITOR),
      map((action: fromActions.UpdateMonitor) => action.monitor),
      switchMap((request: MonitorRequestUpdate) =>
        this.httpClient.put<MonitorResponse>(`${environment.url}api/monitor/updatemonitor`, request)
          .pipe(
            delay(1000),
            tap((response: MonitorResponse) => {
              this.router.navigate(['dashboard/monitor/datoscomunicacion']);
            }),
            map((monitor: MonitorResponse) => new fromActions.UpdateMonitorSuccess(monitor, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.UpdateMonitorError(err.message));
            })
          )
      )
    )
  );
  */

}
