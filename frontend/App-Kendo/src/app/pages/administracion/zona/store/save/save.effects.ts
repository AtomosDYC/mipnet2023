import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { ZonaCreateRequest, ZonaResponse, ZonaUpdateRequest } from './save.models';
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
          this.httpClient.get<ZonaResponse[]>(`${environment.url}api/zona`)
          .pipe(
            //delay(1000),
            map((zonas: ZonaResponse[]) => new fromActions.ReadSuccess(zonas) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_ZONA),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<ZonaResponse>(`${environment.url}api/zona/GetZonaById/${id}`)
        .pipe(
          map((zona: ZonaResponse) => new fromActions.GetbyidSuccess(zona)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_ZONA),
      map((action: fromActions.Create) => action.zona),
      switchMap((request: ZonaCreateRequest) =>
        this.httpClient.post<ZonaResponse>(`${environment.url}api/zona`, request)
          .pipe(
            delay(1000),
            tap((response: ZonaResponse) => {
              this.router.navigate(['dashboard/zona/list']);
            }),
            map((zona: ZonaResponse) => new fromActions.CreateSuccess(zona)),
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
      ofType(fromActions.Types.UPDATE_ZONA),
      map((action: fromActions.Update) => action.zona),
      switchMap((request: ZonaResponse) =>
        this.httpClient.put<ZonaResponse>(`${environment.url}api/omuna`, request)
          .pipe(
            delay(1000),
            tap((response: ZonaResponse) => {
              this.router.navigate(['dashboard/Zona/list']);
            }),
            map((zona: ZonaResponse) => new fromActions.UpdateSuccess(zona)),
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
      ofType(fromActions.Types.DELETE_ZONA),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<ZonaResponse[]>(`${environment.url}api/zona/${id}`)
        .pipe(
          map((zonas: ZonaResponse[]) => new fromActions.DeleteSuccess(zonas)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_ZONA),
      map((action: fromActions.Desactivate) => action.zonas),
      switchMap((zonas: ZonaResponse[]) => {
        return this.httpClient.post<ZonaResponse[]>(`${environment.url}api/Zona/disableZona/`, zonas)
        .pipe(
          map((zonas: ZonaResponse[]) => new fromActions.DesactivateSuccess(zonas)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_ZONA),
      map((action: fromActions.Activate) => action.zonas),
      switchMap((Zonas: ZonaResponse[]) => {
        return this.httpClient.post<ZonaResponse[]>(`${environment.url}api/Zona/activateZona/`, Zonas)
        .pipe(
          map((zonas: ZonaResponse[]) => new fromActions.ActivateSuccess(zonas)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
