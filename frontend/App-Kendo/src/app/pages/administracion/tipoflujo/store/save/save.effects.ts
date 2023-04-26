import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TipoFlujoCreateRequest, TipoFlujoResponse, TipoFlujoUpdateRequest } from './save.models';
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
          this.httpClient.get<TipoFlujoResponse[]>(`${environment.url}api/tipoflujo`)
          .pipe(
            //delay(1000),
            map((tipoflujos: TipoFlujoResponse[]) => new fromActions.ReadSuccess(tipoflujos) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TIPOFLUJO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TipoFlujoResponse>(`${environment.url}api/tipoflujo/GetTipoFlujoById/${id}`)
        .pipe(
          map((tipoflujo: TipoFlujoResponse) => new fromActions.GetbyidSuccess(tipoflujo)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TIPOFLUJO),
      map((action: fromActions.Create) => action.tipoflujo),
      switchMap((request: TipoFlujoCreateRequest) =>
        this.httpClient.post<TipoFlujoResponse>(`${environment.url}api/tipoflujo`, request)
          .pipe(
            delay(1000),
            tap((response: TipoFlujoResponse) => {
              this.router.navigate(['dashboard/tipoflujo/list']);
            }),
            map((tipoflujo: TipoFlujoResponse) => new fromActions.CreateSuccess(tipoflujo)),
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
      ofType(fromActions.Types.UPDATE_TIPOFLUJO),
      map((action: fromActions.Update) => action.tipoflujo),
      switchMap((request: TipoFlujoResponse) =>
        this.httpClient.put<TipoFlujoResponse>(`${environment.url}api/tipoflujo`, request)
          .pipe(
            delay(1000),
            tap((response: TipoFlujoResponse) => {
              this.router.navigate(['dashboard/tipoflujo/list']);
            }),
            map((tipoflujo: TipoFlujoResponse) => new fromActions.UpdateSuccess(tipoflujo)),
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
      ofType(fromActions.Types.DELETE_TIPOFLUJO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TipoFlujoResponse[]>(`${environment.url}api/tipoflujo/${id}`)
        .pipe(
          map((tipoflujos: TipoFlujoResponse[]) => new fromActions.DeleteSuccess(tipoflujos)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TIPOFLUJO),
      map((action: fromActions.Desactivate) => action.tipoflujos),
      switchMap((tipoflujos: TipoFlujoResponse[]) => {
        return this.httpClient.post<TipoFlujoResponse[]>(`${environment.url}api/tipoflujo/disabletipoflujo/`, tipoflujos)
        .pipe(
          map((tipoflujos: TipoFlujoResponse[]) => new fromActions.DesactivateSuccess(tipoflujos)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TIPOFLUJO),
      map((action: fromActions.Activate) => action.tipoflujos),
      switchMap((tipoflujos: TipoFlujoResponse[]) => {
        return this.httpClient.post<TipoFlujoResponse[]>(`${environment.url}api/tipoflujo/activatetipoflujo/`, tipoflujos)
        .pipe(
          map((tipoflujos: TipoFlujoResponse[]) => new fromActions.ActivateSuccess(tipoflujos)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
