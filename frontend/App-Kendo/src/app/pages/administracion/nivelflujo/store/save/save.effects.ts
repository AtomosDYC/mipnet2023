import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { NivelFlujoCreateRequest, NivelFlujoResponse, NivelFlujoUpdateRequest } from './save.models';
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
          this.httpClient.get<NivelFlujoResponse[]>(`${environment.url}api/nivelflujo`)
          .pipe(
            //delay(1000),
            map((nivelflujos: NivelFlujoResponse[]) => new fromActions.ReadSuccess(nivelflujos) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_NIVELFLUJO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<NivelFlujoResponse>(`${environment.url}api/nivelflujo/GetNivelFlujoById/${id}`)
        .pipe(
          map((nivelflujo: NivelFlujoResponse) => new fromActions.GetbyidSuccess(nivelflujo)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_NIVELFLUJO),
      map((action: fromActions.Create) => action.nivelflujo),
      switchMap((request: NivelFlujoCreateRequest) =>
        this.httpClient.post<NivelFlujoResponse>(`${environment.url}api/nivelflujo`, request)
          .pipe(
            delay(1000),
            tap((response: NivelFlujoResponse) => {
              this.router.navigate(['dashboard/nivelflujo/list']);
            }),
            map((nivelflujo: NivelFlujoResponse) => new fromActions.CreateSuccess(nivelflujo)),
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
      ofType(fromActions.Types.UPDATE_NIVELFLUJO),
      map((action: fromActions.Update) => action.nivelflujo),
      switchMap((request: NivelFlujoResponse) =>
        this.httpClient.put<NivelFlujoResponse>(`${environment.url}api/nivelflujo`, request)
          .pipe(
            delay(1000),
            tap((response: NivelFlujoResponse) => {
              this.router.navigate(['dashboard/nivelflujo/list']);
            }),
            map((nivelflujo: NivelFlujoResponse) => new fromActions.UpdateSuccess(nivelflujo)),
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
      ofType(fromActions.Types.DELETE_NIVELFLUJO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<NivelFlujoResponse[]>(`${environment.url}api/nivelflujo/${id}`)
        .pipe(
          map((nivelflujos: NivelFlujoResponse[]) => new fromActions.DeleteSuccess(nivelflujos)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_NIVELFLUJO),
      map((action: fromActions.Desactivate) => action.nivelflujos),
      switchMap((nivelflujos: NivelFlujoResponse[]) => {
        return this.httpClient.post<NivelFlujoResponse[]>(`${environment.url}api/nivelflujo/disablenivelflujo/`, nivelflujos)
        .pipe(
          map((nivelflujos: NivelFlujoResponse[]) => new fromActions.DesactivateSuccess(nivelflujos)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_NIVELFLUJO),
      map((action: fromActions.Activate) => action.nivelflujos),
      switchMap((nivelflujos: NivelFlujoResponse[]) => {
        return this.httpClient.post<NivelFlujoResponse[]>(`${environment.url}api/nivelflujo/activatenivelflujo/`, nivelflujos)
        .pipe(
          map((nivelflujos: NivelFlujoResponse[]) => new fromActions.ActivateSuccess(nivelflujos)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
