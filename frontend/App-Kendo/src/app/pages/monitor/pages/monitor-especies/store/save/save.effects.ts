import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { MonitorespecieResponse, MonitorespecieRequest } from './save.models';
import { environment } from '../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../store/index';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { getMonitorespeciebyid } from './save.selectors';


type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }


  ReadMonitorespecie: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_MONITOR_ESPECIE),
      map((action: fromActions.ReadMonitorespecie) => action.monitorespecie),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/monitor/getmonitorespecie`, request)
          .pipe(
            map((monitorespeciesource: GridDataResult) => new fromActions.ReadMonitorespecieSuccess(monitorespeciesource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadMonitorespecieError(err.message));
            })
          )
      )
    )
  );

  /*
  
  getmonitorespeciebyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_MONITOR_ESPECIE),
    map((action: fromActions.GetMonitorCommunicacionbyid) => action.requestbyid),
    switchMap((requestbyid: MonitorespeciebyidRequest) => {
      return this.httpClient.post<MonitorespecieResponse>(`${environment.url}api/monitor/getmonitorespeciebyid/`, requestbyid)
      .pipe(
        map((monitorespecie: MonitorespecieResponse) => new fromActions.GetMonitorCommunicacionbyidSuccess(monitorespecie)),

        catchError(err => {
          this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
          return of(new fromActions.GetMonitorCommunicacionbyidError(err.message));
        })
      )
    }
    )
  )
);
*/
createmonitorespecie: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_MONITOR_ESPECIE),
      map((action: fromActions.CreateMonitorespecie) => action.monitorespecie),
      switchMap((request: MonitorespecieRequest) =>
        this.httpClient.post<MonitorespecieResponse>(`${environment.url}api/monitor/createmonitorespecie`, request)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Datos de comunicacón actualizado', type:'success'}}));
            }),
            map(() => new fromActions.CreateMonitorespecieSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              return of(new fromActions.CreateMonitorespecieError(err.message));
            })
          )
      )
    )
  );

  deletemonitorespecie: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_MONITOR_ESPECIE),
      map((action: fromActions.DeleteMonitorespecie) => action.monitorespecie),
      switchMap((request: MonitorespecieRequest) => 
        this.httpClient.post(`${environment.url}api/monitor/deletemonitorespecie`, request)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Especie de Temproada Eliminada del listado', type:'success'}}));
            }),
            map(() => new fromActions.DeleteMonitorespecieSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.DeleteMonitorespecieError(err.message));
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
              this.router.navigate(['dashboard/monitor/datosespecie']);
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
