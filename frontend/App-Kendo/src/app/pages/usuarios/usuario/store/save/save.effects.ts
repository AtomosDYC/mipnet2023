import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { UsuarioResponse, UsuarioRegistroCreateRequest, UsuarioRegistroCreateResponse } from './save.models';
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

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_USUARIOREGISTRO),
      map((action: fromActions.Create) => action.usuarioregistro),
      switchMap((request: UsuarioRegistroCreateRequest) =>
        this.httpClient.post<UsuarioResponse[]>(`${environment.url}api/usuario`, request)
          .pipe(
            delay(1000),
            tap((response: UsuarioResponse[]) => {
              this.router.navigate(['dashboard/usuario/list']);
            }),
            map((usuarioregistros: UsuarioResponse[]) => new fromActions.CreateSuccess(usuarioregistros)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError());
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );


}
