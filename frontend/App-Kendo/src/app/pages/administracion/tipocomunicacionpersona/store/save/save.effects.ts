import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TipoComPersonaCreateRequest, TipoComPersonaResponse } from './save.models';
import { environment } from '../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../store/index';



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
          this.httpClient.get<TipoComPersonaResponse[]>(`${environment.url}api/TipoComunicacionPersona`)
          .pipe(
            //delay(1000),
            map((tipocompersonas: TipoComPersonaResponse[]) => new fromActions.ReadSuccess(tipocompersonas) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TIPOCOMPERSONA),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TipoComPersonaResponse>(`${environment.url}api/tipocomunicacionpersona/GetTipoComPersonaById/${id}`)
        .pipe(
          map((tipocompersona: TipoComPersonaResponse) => new fromActions.GetbyidSuccess(tipocompersona)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TIPOCOMPERSONA),
      map((action: fromActions.Create) => action.tipocompersona),
      switchMap((request: TipoComPersonaCreateRequest) =>
        this.httpClient.post<TipoComPersonaResponse>(`${environment.url}api/TipoComunicacionPersona`, request)
          .pipe(
            delay(1000),
            tap((response: TipoComPersonaResponse) => {
              return 'ok';
            }),
            map((tipocompersona: TipoComPersonaResponse) => new fromActions.CreateSuccess(tipocompersona)),
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
      ofType(fromActions.Types.UPDATE_TIPOCOMPERSONA),
      map((action: fromActions.Update) => action.tipocompersona),
      switchMap((request: TipoComPersonaResponse) =>
        this.httpClient.put<TipoComPersonaResponse>(`${environment.url}api/TipoComunicacionPersona`, request)
          .pipe(
            delay(1000),
            tap((response: TipoComPersonaResponse) => {
              return 'ok';
            }),
            map((tipocompersona: TipoComPersonaResponse) => new fromActions.UpdateSuccess(tipocompersona)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  Delete: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_TIPOCOMPERSONA),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TipoComPersonaResponse[]>(`${environment.url}api/TipoComunicacionPersona/${id}`)
        .pipe(
          map((tipocompersonas: TipoComPersonaResponse[]) => new fromActions.DeleteSuccess(tipocompersonas)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TIPOCOMPERSONA),
      map((action: fromActions.Desactivate) => action.tipocompersonas),
      switchMap((tipocompersonas: TipoComPersonaResponse[]) => {
        return this.httpClient.post<TipoComPersonaResponse[]>(`${environment.url}api/TipoComunicacionPersona/disableTipoComPersona/`, tipocompersonas)
        .pipe(
          map((tipocompersonas: TipoComPersonaResponse[]) => new fromActions.DesactivateSuccess(tipocompersonas)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TIPOCOMPERSONA),
      map((action: fromActions.Activate) => action.tipocompersonas),
      switchMap((tipocompersonas: TipoComPersonaResponse[]) => {
        return this.httpClient.post<TipoComPersonaResponse[]>(`${environment.url}api/TipoComunicacionPersona/activateTipoComPersona/`, tipocompersonas)
        .pipe(
          map((tipocompersonas: TipoComPersonaResponse[]) => new fromActions.ActivateSuccess(tipocompersonas)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
