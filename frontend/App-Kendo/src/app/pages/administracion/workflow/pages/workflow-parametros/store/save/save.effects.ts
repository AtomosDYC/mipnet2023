import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { WorkflowParametroRequest, WorkflowParametroResponse, WorkflowParametrosResponse } from './save.models';
import { environment } from '../../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../../store/index';
import { Read } from './save.actions';



type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  read: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ),
      map((action: fromActions.Read) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<WorkflowParametroResponse[]>(`${environment.url}api/workflowparametro/GetWorkflowParametros/${id}`)
        .pipe(
          map((workflowparametros: WorkflowParametroResponse[]) => new fromActions.ReadSuccess(workflowparametros)),

          catchError(err => of(new fromActions.ReadError(err.message)))
        )
      }
      )
    )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_WORKFLOWPARAMETRO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<WorkflowParametroResponse>(`${environment.url}api/workflowparametro/GetWorkflowParametroById/${id}`)
        .pipe(
          map((workflowparametro: WorkflowParametroResponse) => new fromActions.GetbyidSuccess(workflowparametro)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_WORKFLOWPARAMETRO),
      map((action: fromActions.Create) => action.workflowparametro),
      switchMap((request: WorkflowParametroRequest) =>
        this.httpClient.post<WorkflowParametroResponse[]>(`${environment.url}api/workflowparametro`, request)
          .pipe(
            map((workflowparametros: WorkflowParametroResponse[]) => new fromActions.CreateSuccess(workflowparametros, true)),
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
      ofType(fromActions.Types.DELETE_WORKFLOWPARAMETRO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<WorkflowParametroResponse[]>(`${environment.url}api/workflowparametro/DeleteWorkflowParametro/${id}`)
        .pipe(
          map((workflowparametros: WorkflowParametroResponse[]) => new fromActions.DeleteSuccess(workflowparametros)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

}
