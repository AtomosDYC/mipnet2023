import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { UsuarioResponse, UsuarioRegistroCreateRequest, UsuarioRegistroCreateResponse, UsuarioRegistroUpdateRequest } from './save.models';
import { environment } from '../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../store/index';
import { usuarioregistro, usuarioregistros } from '../../../../../models/backend/usuario/index';

type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  read: Observable<Action> = createEffect( () =>
      this.actions.pipe(
        ofType(fromActions.Types.READ),
        switchMap( () =>
          this.httpClient.get<UsuarioResponse[]>(`${environment.url}api/usuario`)
          .pipe(
            //delay(1000),
            map((usuarios: UsuarioResponse[]) => new fromActions.ReadSuccess(usuarios) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_USUARIOREGISTRO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<UsuarioResponse>(`${environment.url}api/usuario/GetAllUsuariosById/${id}`)
        .pipe(
          map((usuarioregistro: UsuarioResponse) => new fromActions.GetbyidSuccess(usuarioregistro)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_USUARIOREGISTRO),
      map((action: fromActions.Create) => action.usuarioregistro),
      switchMap((request: UsuarioRegistroCreateRequest) =>
        this.httpClient.post<UsuarioResponse[]>(`${environment.url}api/usuario`, request)
          .pipe(
            delay(1000),
            tap((response: UsuarioResponse[]) => {
              this.router.navigate(['dashboard/usuarios/list']);
            }),
            map((usuarioregistros: UsuarioResponse[]) => new fromActions.CreateSuccess(usuarioregistros)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );


  update: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_USUARIOREGISTRO),
      map((action: fromActions.Update) => action.usuarioregistro),
      switchMap((request: UsuarioRegistroUpdateRequest) =>
        this.httpClient.put<UsuarioResponse[]>(`${environment.url}api/usuario`, request)
          .pipe(
            delay(1000),
            tap((response: UsuarioResponse[]) => {
              this.router.navigate(['dashboard/usuarios/list']);
            }),
            map((usuarioregistros: UsuarioResponse[]) => new fromActions.UpdateSuccess(usuarioregistros)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.UpdateError(err.message));
            })
          )
      )
    )
  );

  send: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.SEND_MAILCONFIRMATION),
      map((action: fromActions.Send) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get(`${environment.url}api/usuario/SendMailConfirmation/${id}`)
        .pipe(
          map((success) => new fromActions.SendSuccess(true)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

}
