import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TipoPermisoCreateRequest, TipoPermisoResponse, TipoPermisoUpdateRequest } from './save.models';
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
          this.httpClient.get<TipoPermisoResponse[]>(`${environment.url}api/tipopermiso`)
          .pipe(
            //delay(1000),
            map((tipopermisos: TipoPermisoResponse[]) => new fromActions.ReadSuccess(tipopermisos) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TIPOPERMISO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TipoPermisoResponse>(`${environment.url}api/tipopermiso/GetTipoPermisoById/${id}`)
        .pipe(
          map((tipopermiso: TipoPermisoResponse) => new fromActions.GetbyidSuccess(tipopermiso)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TIPOPERMISO),
      map((action: fromActions.Create) => action.tipopermiso),
      switchMap((request: TipoPermisoCreateRequest) =>
        this.httpClient.post<TipoPermisoResponse>(`${environment.url}api/tipopermiso`, request)
          .pipe(
            delay(1000),
            tap((response: TipoPermisoResponse) => {
              this.router.navigate(['dashboard/tipopermiso/list']);
            }),
            map((tipopermiso: TipoPermisoResponse) => new fromActions.CreateSuccess(tipopermiso)),
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
      ofType(fromActions.Types.UPDATE_TIPOPERMISO),
      map((action: fromActions.Update) => action.tipopermiso),
      switchMap((request: TipoPermisoResponse) =>
        this.httpClient.put<TipoPermisoResponse>(`${environment.url}api/tipopermiso`, request)
          .pipe(
            delay(1000),
            tap((response: TipoPermisoResponse) => {
              this.router.navigate(['dashboard/tipopermiso/list']);
            }),
            map((tipopermiso: TipoPermisoResponse) => new fromActions.UpdateSuccess(tipopermiso)),
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
      ofType(fromActions.Types.DELETE_TIPOPERMISO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TipoPermisoResponse[]>(`${environment.url}api/tipopermiso/${id}`)
        .pipe(
          map((tipopermisos: TipoPermisoResponse[]) => new fromActions.DeleteSuccess(tipopermisos)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TIPOPERMISO),
      map((action: fromActions.Desactivate) => action.tipopermisos),
      switchMap((tipopermisos: TipoPermisoResponse[]) => {
        return this.httpClient.post<TipoPermisoResponse[]>(`${environment.url}api/tipopermiso/disabletipopermiso/`, tipopermisos)
        .pipe(
          map((tipopermisos: TipoPermisoResponse[]) => new fromActions.DesactivateSuccess(tipopermisos)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TIPOPERMISO),
      map((action: fromActions.Activate) => action.tipopermisos),
      switchMap((tipopermisos: TipoPermisoResponse[]) => {
        return this.httpClient.post<TipoPermisoResponse[]>(`${environment.url}api/tipopermiso/activatetipopermiso/`, tipopermisos)
        .pipe(
          map((tipopermisos: TipoPermisoResponse[]) => new fromActions.ActivateSuccess(tipopermisos)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
