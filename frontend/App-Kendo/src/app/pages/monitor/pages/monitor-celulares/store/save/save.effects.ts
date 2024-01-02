import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { MonitorSincronizacionResponse, MonitorSincronizacionRequest } from './save.models';
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


  ReadMonitorsincronizacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_MONITOR_SINCRONIZACION),
      map((action: fromActions.ReadMonitorsincronizacion) => action.monitorsincronizacion),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/monitor/getmonitorsincronizacion`, request)
          .pipe(
            map((monitorsincronizacionsource: GridDataResult) => new fromActions.ReadMonitorsincronizacionSuccess(monitorsincronizacionsource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadMonitorsincronizacionError(err.message));
            })
          )
      )
    )
  );

  asignarmonitortrampa: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.SINCRONIZAR_MONITOR_TRAMPA),
      map((action: fromActions.SincronizarMonitortrampa) => action.monitorId),
      switchMap((monitorId: string) =>
        this.httpClient.get<number>(`${environment.url}api/monitor/sincronizartodo/${monitorId}`)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Sincronizacion realizada con exito', type:'success'}}));
            }),
            map(() => new fromActions.SincronizarMonitortrampaSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              return of(new fromActions.SincronizarMonitortrampaError(err.message));
            })
          )
      )
    )
  );
    


}
