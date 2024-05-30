import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { ClienteestacioncontactoResponse, ClienteestacioncontactoRequest, ClienteestacioncontactobyidRequest } from './save.models';
import { PersonaResponse, PersonaBuscarRutRequest } from './save.models';
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


  ReadClienteestacioncontacto: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_CLIENTEESTACION_CONTACTO),
      map((action: fromActions.ReadClienteestacioncontacto) => action.clienteestacioncontacto),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/clienteestacioncontacto/getclienteestacioncontacto`, request)
          .pipe(
            map((clienteestacioncontactosource: GridDataResult) => new fromActions.ReadClienteestacioncontactoSuccess(clienteestacioncontactosource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadClienteestacioncontactoError(err.message));
            })
          )
      )
    )
  );

  
  GetClienteEstacionComunicacionbyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_CLIENTEESTACION_CONTACTO_BYID),
    map((action: fromActions.GetClienteestacioncontactobyid) => action.requestbyid),
    switchMap((requestbyid: ClienteestacioncontactobyidRequest) => {
      return this.httpClient.post<ClienteestacioncontactoResponse>(`${environment.url}api/clienteestacioncontacto/getclienteestacioncontactobyid/`, requestbyid)
      .pipe(
        map((clienteestacioncontacto: ClienteestacioncontactoResponse) => new fromActions.GetClienteestacioncontactobyidSuccess(clienteestacioncontacto)),

        catchError(err => {
          this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
          return of(new fromActions.GetClienteestacioncontactobyidError(err.message));
        })
      )
    }
    )
  )
);

getpersonabyrut: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_PERSONA_BYRUT),
    map((action: fromActions.GetPersonabyrut) => action.persona),
    switchMap((request: PersonaBuscarRutRequest) => 
      this.httpClient.post<PersonaResponse>(`${environment.url}api/persona/getpersonabyrut`, request)
        .pipe(
          map((persona: PersonaResponse) => new fromActions.GetPersonabyrutSuccess(persona)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'No hay personas Registrada al rut ingresado', type:'error'}}));
            return of(new fromActions.GetPersonabyrutError(err.message));
          })
        )
    )
  )
);

createclienteestacioncontacto: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_CLIENTEESTACION_CONTACTO),
      map((action: fromActions.CreateClienteestacioncontacto) => action.clienteestacioncontacto),
      switchMap((request: ClienteestacioncontactoRequest) =>
        this.httpClient.post<ClienteestacioncontactoResponse>(`${environment.url}api/clienteestacioncontacto/createclienteestacioncontacto`, request)
          .pipe(
            delay(1000),
            tap(() => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: 'Datos de comunicacón actualizado', type:'success'}}));
            }),
            map((clienteestacioncontacto: ClienteestacioncontactoResponse) => new fromActions.CreateClienteestacioncontactoSuccess(clienteestacioncontacto, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError({error: {visible:true, mensaje: err.error.errores.mensaje, type:'error'}}));
              return of(new fromActions.CreateClienteestacioncontactoError(err.message));
            })
          )
      )
    )
  );

  deleteclienteestacioncontacto: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_CLIENTEESTACION_CONTACTO),
      map((action: fromActions.DeleteClienteestacioncontacto) => action.requestbyid),
      switchMap((requestbyid: ClienteestacioncontactobyidRequest) => 
        this.httpClient.post(`${environment.url}api/clienteestacioncontacto/deleteclienteestacioncontacto`, requestbyid)
          .pipe(
            delay(1000),
            map(() => new fromActions.DeleteClienteestacioncontactoSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.DeleteClienteestacioncontactoError(err.message));
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
              this.router.navigate(['dashboard/clienteestacion/datoscontacto']);
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
