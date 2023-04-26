import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TipoParametroCreateRequest, TipoParametroResponse, TipoParametroUpdateRequest } from './save.models';
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
          this.httpClient.get<TipoParametroResponse[]>(`${environment.url}api/tipoparametro`)
          .pipe(
            //delay(1000),
            map((tipoparametros: TipoParametroResponse[]) => new fromActions.ReadSuccess(tipoparametros) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TIPOPARAMETRO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TipoParametroResponse>(`${environment.url}api/tipoparametro/GetTipoParametroById/${id}`)
        .pipe(
          map((tipoparametro: TipoParametroResponse) => new fromActions.GetbyidSuccess(tipoparametro)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TIPOPARAMETRO),
      map((action: fromActions.Create) => action.tipoparametro),
      switchMap((request: TipoParametroCreateRequest) =>
        this.httpClient.post<TipoParametroResponse>(`${environment.url}api/tipoparametro`, request)
          .pipe(
            delay(1000),
            tap((response: TipoParametroResponse) => {
              this.router.navigate(['dashboard/tipoparametro/list']);
            }),
            map((tipoparametro: TipoParametroResponse) => new fromActions.CreateSuccess(tipoparametro)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError());
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  update: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_TIPOPARAMETRO),
      map((action: fromActions.Update) => action.tipoparametro),
      switchMap((request: TipoParametroResponse) =>
        this.httpClient.put<TipoParametroResponse>(`${environment.url}api/tipoparametro`, request)
          .pipe(
            delay(1000),
            tap((response: TipoParametroResponse) => {
              this.router.navigate(['dashboard/tipoparametro/list']);
            }),
            map((tipoparametro: TipoParametroResponse) => new fromActions.UpdateSuccess(tipoparametro)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError());
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  Delete: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_TIPOPARAMETRO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TipoParametroResponse[]>(`${environment.url}api/tipoparametro/${id}`)
        .pipe(
          map((tipoparametros: TipoParametroResponse[]) => new fromActions.DeleteSuccess(tipoparametros)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TIPOPARAMETRO),
      map((action: fromActions.Desactivate) => action.tipoparametros),
      switchMap((tipoparametros: TipoParametroResponse[]) => {
        return this.httpClient.post<TipoParametroResponse[]>(`${environment.url}api/tipoparametro/disabletipoparametro/`, tipoparametros)
        .pipe(
          map((tipoparametros: TipoParametroResponse[]) => new fromActions.DesactivateSuccess(tipoparametros)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TIPOPARAMETRO),
      map((action: fromActions.Activate) => action.tipoparametros),
      switchMap((tipoparametros: TipoParametroResponse[]) => {
        return this.httpClient.post<TipoParametroResponse[]>(`${environment.url}api/tipoparametro/activatetipoparametro/`, tipoparametros)
        .pipe(
          map((tipoparametros: TipoParametroResponse[]) => new fromActions.ActivateSuccess(tipoparametros)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
