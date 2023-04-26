import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { NivelPermisoCreateRequest, NivelPermisoResponse, NivelPermisoUpdateRequest } from './save.models';
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
          this.httpClient.get<NivelPermisoResponse[]>(`${environment.url}api/nivelpermiso`)
          .pipe(
            //delay(1000),
            map((nivelpermisos: NivelPermisoResponse[]) => new fromActions.ReadSuccess(nivelpermisos) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_NIVELPERMISO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<NivelPermisoResponse>(`${environment.url}api/nivelpermiso/GetNivelPermisoById/${id}`)
        .pipe(
          map((nivelpermiso: NivelPermisoResponse) => new fromActions.GetbyidSuccess(nivelpermiso)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_NIVELPERMISO),
      map((action: fromActions.Create) => action.nivelpermiso),
      switchMap((request: NivelPermisoCreateRequest) =>
        this.httpClient.post<NivelPermisoResponse>(`${environment.url}api/nivelpermiso`, request)
          .pipe(
            delay(1000),
            tap((response: NivelPermisoResponse) => {
              this.router.navigate(['dashboard/nivelpermiso/list']);
            }),
            map((nivelpermiso: NivelPermisoResponse) => new fromActions.CreateSuccess(nivelpermiso)),
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
      ofType(fromActions.Types.UPDATE_NIVELPERMISO),
      map((action: fromActions.Update) => action.nivelpermiso),
      switchMap((request: NivelPermisoResponse) =>
        this.httpClient.put<NivelPermisoResponse>(`${environment.url}api/nivelpermiso`, request)
          .pipe(
            delay(1000),
            tap((response: NivelPermisoResponse) => {
              this.router.navigate(['dashboard/nivelpermiso/list']);
            }),
            map((nivelpermiso: NivelPermisoResponse) => new fromActions.UpdateSuccess(nivelpermiso)),
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
      ofType(fromActions.Types.DELETE_NIVELPERMISO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<NivelPermisoResponse[]>(`${environment.url}api/nivelpermiso/${id}`)
        .pipe(
          map((nivelpermisos: NivelPermisoResponse[]) => new fromActions.DeleteSuccess(nivelpermisos)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_NIVELPERMISO),
      map((action: fromActions.Desactivate) => action.nivelpermisos),
      switchMap((nivelpermisos: NivelPermisoResponse[]) => {
        return this.httpClient.post<NivelPermisoResponse[]>(`${environment.url}api/nivelpermiso/disablenivelpermiso/`, nivelpermisos)
        .pipe(
          map((nivelpermisos: NivelPermisoResponse[]) => new fromActions.DesactivateSuccess(nivelpermisos)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_NIVELPERMISO),
      map((action: fromActions.Activate) => action.nivelpermisos),
      switchMap((nivelpermisos: NivelPermisoResponse[]) => {
        return this.httpClient.post<NivelPermisoResponse[]>(`${environment.url}api/nivelpermiso/activatenivelpermiso/`, nivelpermisos)
        .pipe(
          map((nivelpermisos: NivelPermisoResponse[]) => new fromActions.ActivateSuccess(nivelpermisos)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
