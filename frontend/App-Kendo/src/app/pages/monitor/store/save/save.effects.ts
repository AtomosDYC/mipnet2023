import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import * as fromvisibleToast from '../../../../store/notification/notification.actions';


import { MonitorResponse, MonitorRequest, MonitorRequestUpdate, monitordesactivateRequest } from './save.models';
import { PersonaResponse, PersonaBuscarRutRequest } from './save.models';

import { environment } from '../../../../../environments/environment';

import { Store } from '@ngrx/store';
import { State } from '../../../../store/index';
import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { datasourcerequest } from '../../../../models/frontend/datasource/request';
import { GetMonitorbyrut, CreateMonitorError } from './save.actions';
import { visibleToast } from './../../../../store/notification/notification.models';


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
    ofType(fromActions.Types.READ_MONITOR),
    map((action: fromActions.ReadMonitor) => action.monitor),
    switchMap((request: RequestState) =>
      this.httpClient.post<GridDataResult>(`${environment.url}api/monitor/getmonitores`, request)
        .pipe(
          map((monitorsource: GridDataResult) => new fromActions.ReadMonitorSuccess(monitorsource)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
            return of(new fromActions.ReadMonitorError(err.message));
          })
        )
    )
  )
);

  GetMonitorbyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_MONITOR),
    map((action: fromActions.GetMonitorbyid) => action.id),
    switchMap((id: string) => {
      return this.httpClient.get<MonitorResponse>(`${environment.url}api/monitor/getmonitorbyid/${id}`)
      .pipe(
        map((monitor: MonitorResponse) => new fromActions.GetMonitorbyidSuccess(monitor)),
        catchError(err => of(new fromActions.GetMonitorbyidError(err.message)))
      )
    }
    )
  )
);

getmonitorbyrut: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_MONITOR_BYRUT),
    map((action: fromActions.GetMonitorbyrut) => action.persona),
    switchMap((request: PersonaBuscarRutRequest) => 
      this.httpClient.post<PersonaResponse>(`${environment.url}api/persona/getpersonabyrut`, request)
        .pipe(
          map((persona: PersonaResponse) => new fromActions.GetMonitorbyrutSuccess(persona)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'No hay personas Registrada al rut ingresado', type:'error'}}));
            return of(new fromActions.GetMonitorbyrutError(err.message));
          })
        )
    )
  )
);

createmonitor: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_MONITOR),
      map((action: fromActions.CreateMonitor) => action.monitor),
      switchMap((request: MonitorRequest) =>
        this.httpClient.post<MonitorResponse>(`${environment.url}api/monitor/createmonitor`, request)
          .pipe(
            delay(1000),
            tap((response: MonitorResponse) => {
              const id = response.mnt01llave;
              this.router.navigate([`dashboard/monitor/datoscomunicacion/${id}`]); 
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Datos Generales grabados con éxito', type:'success'}}));
            }),
            map((monitor: MonitorResponse) => new fromActions.CreateMonitorSuccess(monitor, true)),
            catchError(err => {
              //console.log(err);
              if(err){
                this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              }
              return of(new fromActions.CreateMonitorError(err.message));
            })
          )
      )
    )
  );

  updatemonitor: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.UPDATE_MONITOR),
    map((action: fromActions.UpdateMonitor) => action.monitor),
    switchMap((request: MonitorRequestUpdate) =>
      this.httpClient.put<MonitorResponse>(`${environment.url}api/monitor/updatemonitor`, request)
        .pipe(
          delay(1000),
          tap((response: MonitorResponse) => {

            //console.log('response', response);
            this.store.dispatch(fromvisibleToast.onSuccess({success: {visible:true, mensaje:'Monitor Actualizado con Éxito', type:'success'}}));


            const id = response.mnt01llave;
            this.router.navigate([`dashboard/monitor/datoscomunicacion/${id}`]); 
          }),

          map((monitor: MonitorResponse) => new fromActions.UpdateMonitorSuccess(monitor, true)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.UpdateMonitorError(err.message));
          })
        )
    )
  )
);

Deletemonitor: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_MONITOR),
      map((action: fromActions.DeleteMonitor) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<MonitorResponse[]>(`${environment.url}api/monitor/deletemonitor/
        ${id}`)
        .pipe(
          map(() => new fromActions.DeleteMonitorSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.DeleteMonitorError(err.message));
          })
        )
      }
      )
    )
  );

  Desactivatemonitor: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_MONITOR),
      map((action: fromActions.DesactivateMonitor) => action.monitores),
      switchMap((monitores: monitordesactivateRequest[]) => {
        return this.httpClient.post<MonitorResponse[]>(`${environment.url}api/monitor/disablemonitor/`, monitores)
        .pipe(
          map(() => new fromActions.DesactivateMonitorSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.DesactivateMonitorError(err.message));
          })
        )
      }

      )
    )
  );

  Activatemonitor: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_MONITOR),
      map((action: fromActions.Activatemonitor) => action.monitores),
      switchMap((monitores: monitordesactivateRequest[]) => {
        return this.httpClient.post<MonitorResponse[]>(`${environment.url}api/monitor/activatemonitores/`, monitores)
        .pipe(
          map(() => new fromActions.ActivatemonitorSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.ActivatemonitorError(err.message));
          })
        )
      }
      )
    )
  );


}
