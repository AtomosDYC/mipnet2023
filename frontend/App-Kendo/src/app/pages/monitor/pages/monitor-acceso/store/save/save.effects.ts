import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { MonitorAccesoResponse, MonitorAccesoRequest } from './save.models';
import { environment } from '../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../store/index';


import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { CreateMonitorAcceso } from './save.actions';

type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

 
  getmonitoracceso: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_MONITOR_ACCESO),
    map((action: fromActions.GetMonitorAcceso) => action.id),
    switchMap((id: string) => {
      return this.httpClient.get<MonitorAccesoResponse>(`${environment.url}api/monitor/getmonitoracceso/${id}`)
      .pipe(
        map((monitoraccesos: MonitorAccesoResponse) => new fromActions.GetMonitorAccesoSuccess(monitoraccesos)),

        catchError(err => of(new fromActions.GetMonitorAccesoError(err.message)))
      )
    }
    )
  )
);

createmonitoracceso: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_MONITOR_ACCESO),
      map((action: fromActions.CreateMonitorAcceso) => action.monitoracceso),
      switchMap((request: MonitorAccesoRequest) =>
        this.httpClient.post<MonitorAccesoResponse>(`${environment.url}api/monitor/createmonitoracceso`, request)
          .pipe(
            delay(1000),
            tap((response: MonitorAccesoResponse) => {
               
            }),
            map((monitoracceso: MonitorAccesoResponse) => new fromActions.CreateMonitorAccesoSuccess(monitoracceso, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateMonitorAccesoError(err.message));
            })
          )
      )
    )
  );

  updatemonitoraacceso: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_MONITOR_ACCESO),
      map((action: fromActions.UpdateMonitorAcceso) => action.monitoracceso),
      switchMap((request: MonitorAccesoRequest) =>
        this.httpClient.put<MonitorAccesoResponse>(`${environment.url}api/monitor/updatemonitoracceso`, request)
          .pipe(
            delay(1000),
            tap((response: MonitorAccesoResponse) => {
              
            }),
            map((monitoracceso: MonitorAccesoResponse) => new fromActions.UpdateMonitorAccesoSuccess(monitoracceso, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.UpdateMonitorAccesoError(err.message));
            })
          )
      )
    )
  );

}
