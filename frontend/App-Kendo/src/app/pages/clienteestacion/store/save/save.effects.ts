import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { ClienteEstacionRequest, ClienteEstacionResponse, ClienteEstacionRequestUpdate, clienteestaciondesactivateRequest } from './save.models';
import { environment } from '../../../../../environments/environment';

import * as fromvisibleToast from '../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../store/index';
import { datasourcerequest } from '../../../../models/frontend/datasource/request';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { getClienteEstacionbyid } from './save.selectors';

type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }


  ReadClienteEstacionActiva: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_CLIENTEESTACIONACTIVA),
      map((action: fromActions.ReadClienteEstacionActiva) => action.clienteestacion),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/clienteestacion/getclienteestacionactiva`, request)
          .pipe(
            map((clienteestacionactivasource: GridDataResult) => new fromActions.ReadClienteEstacionActivaSuccess(clienteestacionactivasource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadClienteEstacionActivaError(err.message));
            })
          )
      )
    )
  );

  GetClienteEstacionbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_CLIENTEESTACION_BYID),
      map((action: fromActions.GetClienteEstacionbyid) => action.id),
      switchMap((identificador: string) => 
       this.httpClient.get<ClienteEstacionResponse>(`${environment.url}api/clienteestacion/getclienteestacionbyid/${identificador}`)
        .pipe(
          map((clienteestacion: ClienteEstacionResponse) => new fromActions.GetClienteEstacionbyidSuccess(clienteestacion)),
          
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'No hay clientes estaciones Registrados al ID ingresado', type:'error'}}));
            return of(new fromActions.GetClienteEstacionbyidError(err.message));
          })
        )
      
      )
    )
  );

  GetClienteEstacionbyrut: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_CLIENTEESTACION_BYRUT),
      map((action: fromActions.GetClienteEstacionbyrut) => action.rut),
      switchMap((rut: string) => 
        this.httpClient.get<ClienteEstacionResponse>(`${environment.url}api/clienteestacion/getclienteestacionbyrut/${rut}`)
          .pipe(
            map((clienteestacion: ClienteEstacionResponse) => new fromActions.GetClienteEstacionbyrutSuccess(clienteestacion)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'No hay clientes estaciones Registrados al rut ingresado', type:'error'}}));
              return of(new fromActions.GetClienteEstacionbyrutError(err.message));
            })
          )
      )
    )
  );

  createclienteestacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_CLIENTEESTACION),
      map((action: fromActions.CreateClienteEstacion) => action.clienteestacion),
      switchMap((request: ClienteEstacionRequest) =>
        this.httpClient.post<ClienteEstacionResponse>(`${environment.url}api/clienteestacion/createclienteestacion`, request)
          .pipe(
            delay(1000),
            tap((response: ClienteEstacionResponse) => {
              const id = response.cnt01llave;
              this.router.navigate([`dashboard/clienteestacion/datoscomunicacion/${id}`]); 
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Datos Generales grabados con éxito', type:'success'}}));
            }),
            map((clienteestacion: ClienteEstacionResponse) => new fromActions.CreateClienteEstacionSuccess(clienteestacion, true)),
            catchError(err => {
              //console.log(err);
              if(err){
                this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              }
              return of(new fromActions.CreateClienteEstacionError(err.message));
            })
          )
      )
    )
  );

  updateclienteestacion: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.UPDATE_CLIENTEESTACION),
    map((action: fromActions.UpdateClienteEstacion) => action.clienteestacion),
    switchMap((request: ClienteEstacionRequestUpdate) =>
      this.httpClient.put<ClienteEstacionResponse>(`${environment.url}api/clienteestacion/updateclienteestacion`, request)
        .pipe(
          delay(1000),
          tap((response: ClienteEstacionResponse) => {

            console.log('response', response);
            this.store.dispatch(fromvisibleToast.onSuccess({success: {visible:true, mensaje:'ClienteEstacion Actualizado con Éxito', type:'success'}}));
            const id = response.cnt01llave;
            this.router.navigate([`dashboard/clienteestacion/datoscomunicacion/${id}`]); 
          }),

          map((clienteestacion: ClienteEstacionResponse) => new fromActions.UpdateClienteEstacionSuccess(clienteestacion, true)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.UpdateClienteEstacionError(err.message));
          })
        )
    )
  )
);

Deleteclienteestacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_CLIENTEESTACION),
      map((action: fromActions.DeleteClienteEstacion) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<ClienteEstacionResponse[]>(`${environment.url}api/clienteestacion/deleteclienteestacion/
        ${id}`)
        .pipe(
          map(() => new fromActions.DeleteClienteEstacionSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.DeleteClienteEstacionError(err.message));
          })
        )
      }
      )
    )
  );

  Desactivateclienteestacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_CLIENTEESTACION),
      map((action: fromActions.DesactivateClienteEstacion) => action.clienteestaciones),
      switchMap((clienteestaciones: clienteestaciondesactivateRequest[]) => {
        return this.httpClient.post<ClienteEstacionResponse[]>(`${environment.url}api/clienteestacion/disableclienteestacion/`, clienteestaciones)
        .pipe(
          map(() => new fromActions.DesactivateClienteEstacionSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.DesactivateClienteEstacionError(err.message));
          })
        )
      }

      )
    )
  );

  Activateclienteestacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_CLIENTEESTACION),
      map((action: fromActions.ActivateClienteEstacion) => action.clienteestaciones),
      switchMap((clienteestaciones: clienteestaciondesactivateRequest[]) => {
        return this.httpClient.post<ClienteEstacionResponse[]>(`${environment.url}api/clienteestacion/activateclienteestacion/`, clienteestaciones)
        .pipe(
          map(() => new fromActions.ActivateClienteEstacionSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.ActivateClienteEstacionError(err.message));
          })
        )
      }
      )
    )
  );

}
