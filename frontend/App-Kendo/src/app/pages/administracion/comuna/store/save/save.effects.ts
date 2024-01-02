import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { ComunaCreateRequest, ComunaResponse, ComunaUpdateRequest } from './save.models';
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
          this.httpClient.get<ComunaResponse[]>(`${environment.url}api/comuna`)
          .pipe(
            //delay(1000),
            map((comunas: ComunaResponse[]) => new fromActions.ReadSuccess(comunas) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_COMUNA),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<ComunaResponse>(`${environment.url}api/Comuna/GetComunaById/${id}`)
        .pipe(
          map((comuna: ComunaResponse) => new fromActions.GetbyidSuccess(comuna)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_COMUNA),
      map((action: fromActions.Create) => action.comuna),
      switchMap((request: ComunaCreateRequest) =>
        this.httpClient.post<ComunaResponse>(`${environment.url}api/comuna`, request)
          .pipe(
            delay(1000),
            tap((response: ComunaResponse) => {
              this.router.navigate(['dashboard/comuna/list']);
            }),
            map((comuna: ComunaResponse) => new fromActions.CreateSuccess(comuna)),
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
      ofType(fromActions.Types.UPDATE_COMUNA),
      map((action: fromActions.Update) => action.comuna),
      switchMap((request: ComunaResponse) =>
        this.httpClient.put<ComunaResponse>(`${environment.url}api/comuna`, request)
          .pipe(
            delay(1000),
            tap((response: ComunaResponse) => {
              this.router.navigate(['dashboard/comuna/list']);
            }),
            map((comuna: ComunaResponse) => new fromActions.UpdateSuccess(comuna)),
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
      ofType(fromActions.Types.DELETE_COMUNA),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<ComunaResponse[]>(`${environment.url}api/Comuna/${id}`)
        .pipe(
          map((comunas: ComunaResponse[]) => new fromActions.DeleteSuccess(comunas)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_COMUNA),
      map((action: fromActions.Desactivate) => action.comunas),
      switchMap((comunas: ComunaResponse[]) => {
        return this.httpClient.post<ComunaResponse[]>(`${environment.url}api/Comuna/disableComuna/`, comunas)
        .pipe(
          map((comunas: ComunaResponse[]) => new fromActions.DesactivateSuccess(comunas)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_COMUNA),
      map((action: fromActions.Activate) => action.comunas),
      switchMap((Comunas: ComunaResponse[]) => {
        return this.httpClient.post<ComunaResponse[]>(`${environment.url}api/Comuna/activateComuna/`, Comunas)
        .pipe(
          map((comunas: ComunaResponse[]) => new fromActions.ActivateSuccess(comunas)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
