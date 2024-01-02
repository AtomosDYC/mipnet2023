import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TipoPersonaCreateRequest, TipoPersonaResponse, TipoPersonaUpdateRequest } from './save.models';
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
          this.httpClient.get<TipoPersonaResponse[]>(`${environment.url}api/tipopersona`)
          .pipe(
            //delay(1000),
            map((tipopersonas: TipoPersonaResponse[]) => new fromActions.ReadSuccess(tipopersonas) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TIPOPERSONA),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TipoPersonaResponse>(`${environment.url}api/tipopersona/GetTipoPersonaById/${id}`)
        .pipe(
          map((tipopersona: TipoPersonaResponse) => new fromActions.GetbyidSuccess(tipopersona)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TIPOPERSONA),
      map((action: fromActions.Create) => action.tipopersona),
      switchMap((request: TipoPersonaCreateRequest) =>
        this.httpClient.post<TipoPersonaResponse>(`${environment.url}api/tipopersona`, request)
          .pipe(
            delay(1000),
            tap((response: TipoPersonaResponse) => {
              this.router.navigate(['dashboard/tipopersona/list']);
            }),
            map((tipopersona: TipoPersonaResponse) => new fromActions.CreateSuccess(tipopersona)),
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
      ofType(fromActions.Types.UPDATE_TIPOPERSONA),
      map((action: fromActions.Update) => action.tipopersona),
      switchMap((request: TipoPersonaResponse) =>
        this.httpClient.put<TipoPersonaResponse>(`${environment.url}api/tipopersona`, request)
          .pipe(
            delay(1000),
            tap((response: TipoPersonaResponse) => {
              this.router.navigate(['dashboard/tipopersona/list']);
            }),
            map((tipopersona: TipoPersonaResponse) => new fromActions.UpdateSuccess(tipopersona)),
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
      ofType(fromActions.Types.DELETE_TIPOPERSONA),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TipoPersonaResponse[]>(`${environment.url}api/tipopersona/${id}`)
        .pipe(
          map((tipopersonas: TipoPersonaResponse[]) => new fromActions.DeleteSuccess(tipopersonas)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TIPOPERSONA),
      map((action: fromActions.Desactivate) => action.tipopersonas),
      switchMap((tipopersonas: TipoPersonaResponse[]) => {
        return this.httpClient.post<TipoPersonaResponse[]>(`${environment.url}api/tipopersona/disabletipopersona/`, tipopersonas)
        .pipe(
          map((tipopersonas: TipoPersonaResponse[]) => new fromActions.DesactivateSuccess(tipopersonas)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TIPOPERSONA),
      map((action: fromActions.Activate) => action.tipopersonas),
      switchMap((tipopersonas: TipoPersonaResponse[]) => {
        return this.httpClient.post<TipoPersonaResponse[]>(`${environment.url}api/tipopersona/activatetipopersona/`, tipopersonas)
        .pipe(
          map((tipopersonas: TipoPersonaResponse[]) => new fromActions.ActivateSuccess(tipopersonas)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
