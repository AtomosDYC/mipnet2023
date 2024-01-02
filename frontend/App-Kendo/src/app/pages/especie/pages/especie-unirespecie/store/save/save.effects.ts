import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { UnirEspecieResponse, UnirEspeciesResponse, UnirEspecieRequest } from './save.models';
import { environment } from '../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../store/index';



type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  getunirespciebyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_UNIRESPECIE),
      map((action: fromActions.GetUnirespeciebyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<UnirEspecieResponse[]>(`${environment.url}api/especie/GetUnirEspeciesById/${id}`)
        .pipe(
          map((unirespecies: UnirEspecieResponse[]) => new fromActions.GetUnirespeciebyidSuccess(unirespecies)),

          catchError(err => of(new fromActions.GetUnirespeciebyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_UNIRESPECIE),
      map((action: fromActions.CreateUnirespecie) => action.unirespecie),
      switchMap((request: UnirEspecieRequest) =>
        this.httpClient.post<UnirEspecieResponse[]>(`${environment.url}api/especie/createunirespecie`, request)
          .pipe(
            map((unirespecies: UnirEspecieResponse[]) => new fromActions.CreateUnirespecieSuccess(unirespecies, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateUnirespecieError(err.message));
            })
          )
      )
    )
  );

  deleteunirespecie: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_UNIRESPECIE),
      map((action: fromActions.DeleteUnirEspecie) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<UnirEspecieResponse[]>(`${environment.url}api/especie/deleteUnirespecie/${id}`)
        .pipe(
          map((unirespecies: UnirEspecieResponse[]) => new fromActions.DeleteUnirEspecieSuccess(unirespecies, true)),

          catchError(err => of(new fromActions.DeleteUnirEspecieError(err.message)))
        )
      }
      )
    )
  );

}
