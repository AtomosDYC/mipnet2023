import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { EstadoDanioCreateRequest, EstadoDanioResponse, EstadoDanioUpdateRequest } from './save.models';
import { environment } from 'environments/environment';

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
          this.httpClient.get<EstadoDanioResponse[]>(`${environment.url}api/estadosdanio`)
          .pipe(
            //delay(1000),
            map((estadosdanios: EstadoDanioResponse[]) => new fromActions.ReadSuccess(estadosdanios) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_ESTADODANIO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<EstadoDanioResponse>(`${environment.url}api/estadosdanio/GetEstadoDanioById/${id}`)
        .pipe(
          map((estadodanio: EstadoDanioResponse) => new fromActions.GetbyidSuccess(estadodanio)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_ESTADODANIO),
      map((action: fromActions.Create) => action.estadodanio),
      switchMap((request: EstadoDanioCreateRequest) =>
        this.httpClient.post<EstadoDanioResponse>(`${environment.url}api/estadosdanio`, request)
          .pipe(
            delay(1000),
            tap((response: EstadoDanioResponse) => {
              this.router.navigate(['dashboard/estadodanio/list']);
            }),
            map((estadodanio: EstadoDanioResponse) => new fromActions.CreateSuccess(estadodanio)),
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
      ofType(fromActions.Types.UPDATE_ESTADODANIO),
      map((action: fromActions.Update) => action.estadodanio),
      switchMap((request: EstadoDanioResponse) =>
        this.httpClient.put<EstadoDanioResponse>(`${environment.url}api/estadosdanio`, request)
          .pipe(
            delay(1000),
            tap((response: EstadoDanioResponse) => {
              this.router.navigate(['dashboard/estadodanio/list']);
            }),
            map((estadodanio: EstadoDanioResponse) => new fromActions.UpdateSuccess(estadodanio)),
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
      ofType(fromActions.Types.DELETE_ESTADODANIO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<EstadoDanioResponse[]>(`${environment.url}api/estadosdanio/${id}`)
        .pipe(
          map((estadosdanios: EstadoDanioResponse[]) => new fromActions.DeleteSuccess(estadosdanios)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_ESTADODANIO),
      map((action: fromActions.Desactivate) => action.estadosdanios),
      switchMap((estadosdanios: EstadoDanioResponse[]) => {
        return this.httpClient.post<EstadoDanioResponse[]>(`${environment.url}api/estadosdanio/disableestadodanio/`, estadosdanios)
        .pipe(
          map((estadosdanios: EstadoDanioResponse[]) => new fromActions.DesactivateSuccess(estadosdanios)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_ESTADODANIO),
      map((action: fromActions.Activate) => action.estadosdanios),
      switchMap((estadosdanios: EstadoDanioResponse[]) => {
        return this.httpClient.post<EstadoDanioResponse[]>(`${environment.url}api/estadosdanio/activateestadodanio/`, estadosdanios)
        .pipe(
          map((estadosdanios: EstadoDanioResponse[]) => new fromActions.ActivateSuccess(estadosdanios)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
