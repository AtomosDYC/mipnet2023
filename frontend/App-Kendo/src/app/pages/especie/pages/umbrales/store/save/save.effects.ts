import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { EspecieUmbralResponse, EspecieUmbralsResponse, EspecieUmbralRequest } from './save.models';
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

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_ESPECIEUMBRAL),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<EspecieUmbralResponse[]>(`${environment.url}api/especieumbral/GetUmbralEspecieByid/${id}`)
        .pipe(
          map((especieumbrals: EspecieUmbralResponse[]) => new fromActions.GetbyidSuccess(especieumbrals)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_ESPECIEUMBRAL),
      map((action: fromActions.Create) => action.especieumbral),
      switchMap((request: EspecieUmbralRequest) =>
        this.httpClient.post<EspecieUmbralResponse[]>(`${environment.url}api/especieumbral/CreateUmbralEspecie`, request)
          .pipe(
            map((especieumbrals: EspecieUmbralResponse[]) => new fromActions.CreateSuccess(especieumbrals, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  deleteespecieumbral: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_ESPECIEUMBRAL),
      map((action: fromActions.DeleteEspecieUmbral) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<EspecieUmbralResponse[]>(`${environment.url}api/especieumbral/DeleteUmbralEspecie/${id}`)
        .pipe(
          map((especieumbrals: EspecieUmbralResponse[]) => new fromActions.DeleteEspecieUmbralSuccess(especieumbrals, true)),

          catchError(err => of(new fromActions.DeleteEspecieUmbralError(err.message)))
        )
      }
      )
    )
  );

}
