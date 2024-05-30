import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { ClienteestacioncomunicacionResponse, ClienteestacioncomunicacionRequest, ClienteestacioncomunicacionbyidRequest } from './save.models';
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


  ReadClienteestacioncomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_CLIENTEESTACION_COMUNICACION),
      map((action: fromActions.ReadClienteestacioncomunicacion) => action.clienteestacioncomunicacion),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/clienteestacioncomunicacion/getclienteestacioncomunicacion`, request)
          .pipe(
            map((clienteestacioncomunicacionsource: GridDataResult) => new fromActions.ReadClienteestacioncomunicacionSuccess(clienteestacioncomunicacionsource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadClienteestacioncomunicacionError(err.message));
            })
          )
      )
    )
  );

  
  GetClienteEstacionComunicacionbyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_CLIENTEESTACION_COMUNICACION_BYID),
    map((action: fromActions.GetClienteestacionCommunicacionbyid) => action.requestbyid),
    switchMap((requestbyid: ClienteestacioncomunicacionbyidRequest) => {
      return this.httpClient.post<ClienteestacioncomunicacionResponse>(`${environment.url}api/clienteestacioncomunicacion/getclienteestacioncomunicacionbyid/`, requestbyid)
      .pipe(
        map((clienteestacioncomunicacion: ClienteestacioncomunicacionResponse) => new fromActions.GetClienteestacionCommunicacionbyidSuccess(clienteestacioncomunicacion)),

        catchError(err => {
          this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
          return of(new fromActions.GetClienteestacionCommunicacionbyidError(err.message));
        })
      )
    }
    )
  )
);

createclienteestacioncomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_CLIENTEESTACION_COMUNICACION),
      map((action: fromActions.CreateClienteestacioncomunicacion) => action.clienteestacioncomunicacion),
      switchMap((request: ClienteestacioncomunicacionRequest) =>
        this.httpClient.post<ClienteestacioncomunicacionResponse>(`${environment.url}api/clienteestacioncomunicacion/createclienteestacioncomunicacion`, request)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Datos de comunicacón actualizado', type:'success'}}));
            }),
            map((clienteestacioncomunicacion: ClienteestacioncomunicacionResponse) => new fromActions.CreateClienteestacioncomunicacionSuccess(clienteestacioncomunicacion, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              return of(new fromActions.CreateClienteestacioncomunicacionError(err.message));
            })
          )
      )
    )
  );

  deleteclienteestacioncomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_CLIENTEESTACION_COMUNICACION),
      map((action: fromActions.DeleteClienteestacioncomunicacion) => action.requestbyid),
      switchMap((requestbyid: ClienteestacioncomunicacionbyidRequest) => 
        this.httpClient.post(`${environment.url}api/clienteestacioncomunicacion/deleteclienteestacioncomunicacion`, requestbyid)
          .pipe(
            delay(1000),
            map(() => new fromActions.DeleteClienteestacioncomunicacionSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.DeleteClienteestacioncomunicacionError(err.message));
            })
            )
        )
      )
    );

/*
  updateclienteestacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_CLIENTEESTACION),
      map((action: fromActions.UpdateClienteestacion) => action.clienteestacion),
      switchMap((request: ClienteestacionRequestUpdate) =>
        this.httpClient.put<ClienteestacionResponse>(`${environment.url}api/clienteestacion/updateclienteestacion`, request)
          .pipe(
            delay(1000),
            tap((response: ClienteestacionResponse) => {
              this.router.navigate(['dashboard/clienteestacion/datoscomunicacion']);
            }),
            map((clienteestacion: ClienteestacionResponse) => new fromActions.UpdateClienteestacionSuccess(clienteestacion, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.UpdateClienteestacionError(err.message));
            })
          )
      )
    )
  );
  */

}
