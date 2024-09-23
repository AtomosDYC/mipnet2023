import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { ClienteUsuarioRequest, ClienteUsuarioResponse, ClienteUsuarioActivaSource, ClienteUsuarioRequestUpdate, clienteusuariodesactivateRequest, menuclienteusuarioRequest, MenuUsuarioResponse  } from './save.models';
import { environment } from '../../../../../environments/environment';

import * as fromvisibleToast from '../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../store/index';


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


  ReadClienteUsuarioActiva: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_CLIENTEUSUARIOACTIVA),
      map((action: fromActions.ReadClienteUsuarioActiva) => action.clienteusuario),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/clienteusuario/getclienteusuarioactiva`, request)
          .pipe(
            map((clienteusuarioctivasource: GridDataResult) => new fromActions.ReadClienteUsuarioActivaSuccess(clienteusuarioctivasource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadClienteUsuarioActivaError(err.message));
            })
          )
      )
    )
  );

  ReadClienteUsuarioInactiva: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_CLIENTEUSUARIOINACTIVA),
      map((action: fromActions.ReadClienteUsuarioInactiva) => action.clienteusuario),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/clienteusuario/getclienteusuarioinactivo`, request)
          .pipe(
            map((clienteusuarioinactivasource: GridDataResult) => new fromActions.ReadClienteUsuarioInactivaSuccess(clienteusuarioinactivasource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadClienteUsuarioInactivaError(err.message));
            })
          )
      )
    )
  );

  GetClienteUsuariobyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_CLIENTEUSUARIO_BYID),
      map((action: fromActions.GetClienteUsuariobyid) => action.id),
      switchMap((identificador: string) => 
       this.httpClient.get<ClienteUsuarioResponse>(`${environment.url}api/clienteusuario/getclienteusuariobyid/${identificador}`)
        .pipe(
          map((clienteusuario: ClienteUsuarioResponse) => new fromActions.GetClienteUsuariobyidSuccess(clienteusuario)),
          
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'No hay clientes estaciones Registrados al ID ingresado', type:'error'}}));
            return of(new fromActions.GetClienteUsuariobyidError(err.message));
          })
        )
      
      )
    )
  );

  GetClienteUsuariobyrut: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_CLIENTEUSUARIO_BYRUT),
      map((action: fromActions.GetClienteUsuariobyrut) => action.rut),
      switchMap((rut: string) => 
        this.httpClient.get<ClienteUsuarioResponse>(`${environment.url}api/clienteusuario/getclienteusuariobyrut/${rut}`)
          .pipe(
            map((clienteusuario: ClienteUsuarioResponse) => new fromActions.GetClienteUsuariobyrutSuccess(clienteusuario)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'No hay clientes estaciones Registrados al rut ingresado', type:'error'}}));
              return of(new fromActions.GetClienteUsuariobyrutError(err.message));
            })
          )
      )
    )
  );

  

  
  GetClienteUsuariomenu: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_CLIENTEUSUARIO_MENU),
      map((action: fromActions.GetClienteUsuariomenu) => action.menuclienteusuario),
      switchMap((request: menuclienteusuarioRequest) =>
        this.httpClient.post<MenuUsuarioResponse[]>(`${environment.url}api/clienteusuario/getmenuestaciones`, request)
          .pipe(
            map((menuestacion: MenuUsuarioResponse[]) => new fromActions.GetClienteUsuariomenuSuccess(menuestacion)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.GetClienteUsuariomenuError(err.message));
            })
          )
      )
    )
  );
  
  createclienteusuario: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_CLIENTEUSUARIO),
      map((action: fromActions.CreateClienteUsuario) => action.clienteusuario),
      switchMap((request: ClienteUsuarioRequest) =>
        this.httpClient.post<ClienteUsuarioResponse>(`${environment.url}api/clienteusuario/createclienteusuario`, request)
          .pipe(
            delay(1000),
            tap((response: ClienteUsuarioResponse) => {
              const id = response.cnt01llave;
              this.router.navigate([`dashboard/clienteusuario/datoscomunicacion/${id}`]); 
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Datos Generales grabados con éxito', type:'success'}}));
            }),
            map((clienteusuario: ClienteUsuarioResponse) => new fromActions.CreateClienteUsuarioSuccess(clienteusuario, true)),
            catchError(err => {
              //console.log(err);
              if(err){
                this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              }
              return of(new fromActions.CreateClienteUsuarioError(err.message));
            })
          )
      )
    )
  );

  updateclienteusuario: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.UPDATE_CLIENTEUSUARIO),
    map((action: fromActions.UpdateClienteUsuario) => action.clienteusuario),
    switchMap((request: ClienteUsuarioRequestUpdate) =>
      this.httpClient.put<ClienteUsuarioResponse>(`${environment.url}api/clienteusuario/updateclienteusuario`, request)
        .pipe(
          delay(1000),
          tap((response: ClienteUsuarioResponse) => {

            console.log('response', response);
            this.store.dispatch(fromvisibleToast.onSuccess({success: {visible:true, mensaje:'ClienteUsuario Actualizado con Éxito', type:'success'}}));
            const id = response.cnt01llave;
            this.router.navigate([`dashboard/clienteusuario/datoscomunicacion/${id}`]); 
          }),

          map((clienteusuario: ClienteUsuarioResponse) => new fromActions.UpdateClienteUsuarioSuccess(clienteusuario, true)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.UpdateClienteUsuarioError(err.message));
          })
        )
    )
  )
);

Deleteclienteusuario: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_CLIENTEUSUARIO),
      map((action: fromActions.DeleteClienteUsuario) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<ClienteUsuarioResponse[]>(`${environment.url}api/clienteusuario/deleteclienteusuario/
        ${id}`)
        .pipe(
          map(() => new fromActions.DeleteClienteUsuarioSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.DeleteClienteUsuarioError(err.message));
          })
        )
      }
      )
    )
  );

  Desactivateclienteusuario: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_CLIENTEUSUARIO),
      map((action: fromActions.DesactivateClienteUsuario) => action.clienteusuarios),
      switchMap((clienteusuarioes: clienteusuariodesactivateRequest[]) => {
        return this.httpClient.post<ClienteUsuarioResponse[]>(`${environment.url}api/clienteusuario/disableclienteusuario/`, clienteusuarioes)
        .pipe(
          map(() => new fromActions.DesactivateClienteUsuarioSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.DesactivateClienteUsuarioError(err.message));
          })
        )
      }

      )
    )
  );

  Activateclienteusuario: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_CLIENTEUSUARIO),
      map((action: fromActions.ActivateClienteUsuario) => action.clienteusuarios),
      switchMap((clienteusuarioes: clienteusuariodesactivateRequest[]) => {
        return this.httpClient.post<ClienteUsuarioResponse[]>(`${environment.url}api/clienteusuario/activateclienteusuario/`, clienteusuarioes)
        .pipe(
          map(() => new fromActions.ActivateClienteUsuarioSuccess(true)),

          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
            return of(new fromActions.ActivateClienteUsuarioError(err.message));
          })
        )
      }
      )
    )
  );

  

}
