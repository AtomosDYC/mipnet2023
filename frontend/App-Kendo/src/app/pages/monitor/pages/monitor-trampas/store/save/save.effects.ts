import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { MonitortrampaResponse, MonitortrampaRequest } from './save.models';
import { environment } from '../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../store/index';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { getMonitortrampabyid, getMonitorbuscartrampas } from './save.selectors';
import { ReplicarTemporadaMonitor } from './save.actions';


type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }


  ReadMonitortrampa: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_MONITOR_TRAMPA),
      map((action: fromActions.ReadMonitortrampa) => action.monitortrampa),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/monitor/getmonitortrampa`, request)
          .pipe(
            map((monitortrampasource: GridDataResult) => new fromActions.ReadMonitortrampaSuccess(monitortrampasource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadMonitortrampaError(err.message));
            })
          )
      )
    )
  );

 
  
  GetMonitorbuscartrampa: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_MONITOR_BUSCAR_TRAMPA),
    map((action: fromActions.GetMonitorbuscartrampa) => action.monitortrampa),
    switchMap((request: RequestState) => {
      return this.httpClient.post<GridDataResult>(`${environment.url}api/monitor/getbuscartrampa`, request)
      .pipe(
        map((monitortrampabuscarsource: GridDataResult) => new fromActions.GetMonitorbuscartrampaSuccess(monitortrampabuscarsource)),

        catchError(err => {
          this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
          return of(new fromActions.GetMonitorbuscartrampaError(err.message));
        })
      )
    }
    )
  )
);

asignarmonitortrampa: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ASIGNAR_MONITOR_TRAMPA),
      map((action: fromActions.AsignarMonitortrampa) => action.asignartrampas),
      switchMap((request: MonitortrampaRequest[]) =>
        this.httpClient.post<MonitortrampaResponse>(`${environment.url}api/monitor/asignartrampa`, request)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Trampas asignadas a monitor', type:'success'}}));
            }),
            map(() => new fromActions.AsignarMonitortrampaSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              return of(new fromActions.AsignarMonitortrampaError(err.message));
            })
          )
      )
    )
  );

  deletemonitortrampa: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_MONITOR_TRAMPA),
      map((action: fromActions.DeleteMonitortrampa) => action.monitortrampa),
      switchMap((request: MonitortrampaRequest) => 
        this.httpClient.post(`${environment.url}api/monitor/deletemonitortrampa`, request)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Especie de Temproada Eliminada del listado', type:'success'}}));
            }),
            map(() => new fromActions.DeleteMonitortrampaSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.DeleteMonitortrampaError(err.message));
            })
            )
        )
      )
    );


    ReplicarTemporadaMonitor: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.REPLICAR_TEMPORADA_MONITOR),
      map((action: fromActions.ReplicarTemporadaMonitor) => action.id),
      switchMap((id: string) => 
        this.httpClient.get(`${environment.url}api/monitor/replicartemporada/${id}`)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Temporada Replicada a monitor', type:'success'}}));
            }),
            map(() => new fromActions.ReplicarTemporadaMonitorSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReplicarTemporadaMonitorError(err.message));
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
              this.router.navigate(['dashboard/monitor/datostrampa']);
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
