import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { DanioEspecieResponse, DanioEspeciesResponse, DanioEspecieRequest } from './save.models';
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

  getdanioespeciebyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_DANIOESPECIE),
      map((action: fromActions.GetDanioespeciebyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<DanioEspecieResponse[]>(`${environment.url}api/danioespecie/GetEstadosDanioById/${id}`)
        .pipe(
          map((danioespecies: DanioEspecieResponse[]) => new fromActions.GetDanioespeciebyidSuccess(danioespecies)),

          catchError(err => of(new fromActions.GetDanioespeciebyidError(err.message)))
        )
      }
      )
    )
  );

  createdanioespecie: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_DANIOESPECIE),
      map((action: fromActions.CreateDanioespecie) => action.danioespecie),
      switchMap((request: DanioEspecieRequest) =>
        this.httpClient.post<DanioEspecieResponse[]>(`${environment.url}api/danioespecie/CreateDanioespecie`, request)
          .pipe(
            map((danioespecies: DanioEspecieResponse[]) => new fromActions.CreateDanioespecieSuccess(danioespecies, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateDanioespecieError(err.message));
            })
          )
      )
    )
  );

  Deletedanioespecie: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_DANIOESPECIE),
      map((action: fromActions.DeleteDanioEspecie) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<DanioEspecieResponse[]>(`${environment.url}api/especiedanio/deleteDanioespecie/${id}`)
        .pipe(
          map((danioespecies: DanioEspecieResponse[]) => new fromActions.DeleteDanioEspecieSuccess(danioespecies, true)),

          catchError(err => of(new fromActions.DeleteDanioEspecieError(err.message)))
        )
      }
      )
    )
  );

}
