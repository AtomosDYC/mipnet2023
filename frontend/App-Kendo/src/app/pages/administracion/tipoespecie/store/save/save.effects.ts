import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { TipoEspecieCreateRequest, TipoEspecieResponse, TipoEspecieUpdateRequest } from './save.models';
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
          this.httpClient.get<TipoEspecieResponse[]>(`${environment.url}api/tipoespecie`)
          .pipe(
            //delay(1000),
            map((tipoespecies: TipoEspecieResponse[]) => new fromActions.ReadSuccess(tipoespecies) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_TIPOESPECIE),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<TipoEspecieResponse>(`${environment.url}api/tipoespecie/GetTipoEspecieById/${id}`)
        .pipe(
          map((tipoespecie: TipoEspecieResponse) => new fromActions.GetbyidSuccess(tipoespecie)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_TIPOESPECIE),
      map((action: fromActions.Create) => action.tipoespecie),
      switchMap((request: TipoEspecieCreateRequest) =>
        this.httpClient.post<TipoEspecieResponse>(`${environment.url}api/tipoespecie`, request)
          .pipe(
            delay(1000),
            tap((response: TipoEspecieResponse) => {
              this.router.navigate(['dashboard/tipoespecie/list']);
            }),
            map((tipoespecie: TipoEspecieResponse) => new fromActions.CreateSuccess(tipoespecie)),
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
      ofType(fromActions.Types.UPDATE_TIPOESPECIE),
      map((action: fromActions.Update) => action.tipoespecie),
      switchMap((request: TipoEspecieResponse) =>
        this.httpClient.put<TipoEspecieResponse>(`${environment.url}api/tipoespecie`, request)
          .pipe(
            delay(1000),
            tap((response: TipoEspecieResponse) => {
              this.router.navigate(['dashboard/tipoespecie/list']);
            }),
            map((tipoespecie: TipoEspecieResponse) => new fromActions.UpdateSuccess(tipoespecie)),
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
      ofType(fromActions.Types.DELETE_TIPOESPECIE),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<TipoEspecieResponse[]>(`${environment.url}api/tipoespecie/${id}`)
        .pipe(
          map((tipoespecies: TipoEspecieResponse[]) => new fromActions.DeleteSuccess(tipoespecies)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_TIPOESPECIE),
      map((action: fromActions.Desactivate) => action.tipoespecies),
      switchMap((tipoespecies: TipoEspecieResponse[]) => {
        return this.httpClient.post<TipoEspecieResponse[]>(`${environment.url}api/tipoespecie/disabletipoespecie/`, tipoespecies)
        .pipe(
          map((tipoespecies: TipoEspecieResponse[]) => new fromActions.DesactivateSuccess(tipoespecies)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_TIPOESPECIE),
      map((action: fromActions.Activate) => action.tipoespecies),
      switchMap((tipoespecies: TipoEspecieResponse[]) => {
        return this.httpClient.post<TipoEspecieResponse[]>(`${environment.url}api/tipoespecie/activatetipoespecie/`, tipoespecies)
        .pipe(
          map((tipoespecies: TipoEspecieResponse[]) => new fromActions.ActivateSuccess(tipoespecies)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
