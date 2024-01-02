import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TipoDocumentoCreateRequest, TipoDocumentoResponse, TipoDocumentoUpdateRequest } from './save.models';
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
          this.httpClient.get<TipoDocumentoResponse[]>(`${environment.url}api/tipodocumento`)
          .pipe(
            //delay(1000),
            map((tipodocumentos: TipoDocumentoResponse[]) => new fromActions.ReadSuccess(tipodocumentos) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TIPODOCUMENTO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TipoDocumentoResponse>(`${environment.url}api/tipodocumento/GetTipoDocumentoById/${id}`)
        .pipe(
          map((tipodocumento: TipoDocumentoResponse) => new fromActions.GetbyidSuccess(tipodocumento)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TIPODOCUMENTO),
      map((action: fromActions.Create) => action.tipodocumento),
      switchMap((request: TipoDocumentoCreateRequest) =>
        this.httpClient.post<TipoDocumentoResponse>(`${environment.url}api/tipodocumento`, request)
          .pipe(
            delay(1000),
            tap((response: TipoDocumentoResponse) => {
              this.router.navigate(['dashboard/tipodocumento/list']);
            }),
            map((tipodocumento: TipoDocumentoResponse) => new fromActions.CreateSuccess(tipodocumento)),
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
      ofType(fromActions.Types.UPDATE_TIPODOCUMENTO),
      map((action: fromActions.Update) => action.tipodocumento),
      switchMap((request: TipoDocumentoResponse) =>
        this.httpClient.put<TipoDocumentoResponse>(`${environment.url}api/tipodocumento`, request)
          .pipe(
            delay(1000),
            tap((response: TipoDocumentoResponse) => {
              this.router.navigate(['dashboard/tipodocumento/list']);
            }),
            map((tipodocumento: TipoDocumentoResponse) => new fromActions.UpdateSuccess(tipodocumento)),
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
      ofType(fromActions.Types.DELETE_TIPODOCUMENTO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TipoDocumentoResponse[]>(`${environment.url}api/tipodocumento/${id}`)
        .pipe(
          map((tipodocumentos: TipoDocumentoResponse[]) => new fromActions.DeleteSuccess(tipodocumentos)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TIPODOCUMENTO),
      map((action: fromActions.Desactivate) => action.tipodocumentos),
      switchMap((tipodocumentos: TipoDocumentoResponse[]) => {
        return this.httpClient.post<TipoDocumentoResponse[]>(`${environment.url}api/tipodocumento/disabletipodocumento/`, tipodocumentos)
        .pipe(
          map((tipodocumentos: TipoDocumentoResponse[]) => new fromActions.DesactivateSuccess(tipodocumentos)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TIPODOCUMENTO),
      map((action: fromActions.Activate) => action.tipodocumentos),
      switchMap((tipodocumentos: TipoDocumentoResponse[]) => {
        return this.httpClient.post<TipoDocumentoResponse[]>(`${environment.url}api/tipodocumento/activatetipodocumento/`, tipodocumentos)
        .pipe(
          map((tipodocumentos: TipoDocumentoResponse[]) => new fromActions.ActivateSuccess(tipodocumentos)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
