import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { SaludoCreateRequest, SaludoResponse, SaludoUpdateRequest } from './save.models';
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
          this.httpClient.get<SaludoResponse[]>(`${environment.url}api/saludo`)
          .pipe(
            //delay(1000),
            map((saludos: SaludoResponse[]) => new fromActions.ReadSuccess(saludos) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_SALUDO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<SaludoResponse>(`${environment.url}api/saludo/GetSaludoById/${id}`)
        .pipe(
          map((saludo: SaludoResponse) => new fromActions.GetbyidSuccess(saludo)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_SALUDO),
      map((action: fromActions.Create) => action.saludo),
      switchMap((request: SaludoCreateRequest) =>
        this.httpClient.post<SaludoResponse>(`${environment.url}api/saludo`, request)
          .pipe(
            delay(1000),
            tap((response: SaludoResponse) => {
              this.router.navigate(['dashboard/saludos/list']);
            }),
            map((saludo: SaludoResponse) => new fromActions.CreateSuccess(saludo)),
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
      ofType(fromActions.Types.UPDATE_SALUDO),
      map((action: fromActions.Update) => action.saludo),
      switchMap((request: SaludoResponse) =>
        this.httpClient.put<SaludoResponse>(`${environment.url}api/saludo`, request)
          .pipe(
            delay(1000),
            tap((response: SaludoResponse) => {
              this.router.navigate(['dashboard/saludos/list']);
            }),
            map((saludo: SaludoResponse) => new fromActions.UpdateSuccess(saludo)),
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
      ofType(fromActions.Types.DELETE_SALUDO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<SaludoResponse[]>(`${environment.url}api/saludo/${id}`)
        .pipe(
          map((saludos: SaludoResponse[]) => new fromActions.DeleteSuccess(saludos)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_SALUDO),
      map((action: fromActions.Desactivate) => action.saludos),
      switchMap((saludos: SaludoResponse[]) => {
        return this.httpClient.post<SaludoResponse[]>(`${environment.url}api/saludo/disablesaludo/`, saludos)
        .pipe(
          map((saludos: SaludoResponse[]) => new fromActions.DesactivateSuccess(saludos)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_SALUDO),
      map((action: fromActions.Activate) => action.saludos),
      switchMap((saludos: SaludoResponse[]) => {
        return this.httpClient.post<SaludoResponse[]>(`${environment.url}api/saludo/activatesaludo/`, saludos)
        .pipe(
          map((saludos: SaludoResponse[]) => new fromActions.ActivateSuccess(saludos)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
