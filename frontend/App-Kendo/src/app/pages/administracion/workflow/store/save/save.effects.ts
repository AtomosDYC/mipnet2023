import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { WorkflowDatosgeneralesRequest, WorkflowResponse, WorkflowDatosgeneralesUpdateRequest, WorkflowNodopadreRequest, WorkflowConfiguracionwebRequest } from './save.models';
import { environment } from '../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../store/index';
import { UpdateNodopadre } from './save.actions';



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
          this.httpClient.get<WorkflowResponse[]>(`${environment.url}api/workflow`)
          .pipe(
            //delay(1000),
            map((workflows: WorkflowResponse[]) => new fromActions.ReadSuccess(workflows) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_WORKFLOW),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<WorkflowResponse>(`${environment.url}api/workflow/GetWorkflowById/${id}`)
        .pipe(
          map((workflow: WorkflowResponse) => new fromActions.GetbyidSuccess(workflow)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_WORKFLOW),
      map((action: fromActions.Create) => action.workflow),
      switchMap((request: WorkflowDatosgeneralesRequest) =>
        this.httpClient.post<WorkflowResponse>(`${environment.url}api/workflow`, request)
          .pipe(
            delay(1000),
            tap((response: WorkflowResponse) => {
              const id = response.wkf01llave;
              this.router.navigate([`dashboard/workflow/nodopadre/${id}`]); 
            }),
            map((workflow: WorkflowResponse) => new fromActions.CreateSuccess(workflow)),
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
      ofType(fromActions.Types.UPDATE_WORKFLOW),
      map((action: fromActions.Update) => action.workflow),
      switchMap((request: WorkflowDatosgeneralesUpdateRequest) =>
        this.httpClient.put<WorkflowResponse>(`${environment.url}api/workflow`, request)
          .pipe(
            delay(1000),
            tap((response: WorkflowResponse) => {
              const id = response.wkf01llave;
              this.router.navigate([`dashboard/workflow/nodopadre/${id}`]); 
            }),
            map((workflow: WorkflowResponse) => new fromActions.UpdateSuccess(workflow)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  updatenodopadre: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_WORKFLOW_NODOPADRE),
      map((action: fromActions.UpdateNodopadre) => action.workflow),
      switchMap((request: WorkflowNodopadreRequest) =>
        this.httpClient.post<WorkflowResponse>(`${environment.url}api/workflow/UpdateNodopadre`, request)
          .pipe(
            delay(1000),
            tap((response: WorkflowResponse) => {
              const id = response.wkf01llave;
              this.router.navigate([`dashboard/workflow/configuracionweb/${id}`]); 
            }),
            map((workflow: WorkflowResponse) => new fromActions.UpdateNodopadreSuccess(workflow)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.UpdateNodopadreError(err.message));
            })
          )
      )
    )
  );

  updateconfiguracionweb: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_WORKFLOW_CONFIGURACIONWEB),
      map((action: fromActions.UpdateConfiguracionweb) => action.workflow),
      switchMap((request: WorkflowConfiguracionwebRequest) =>
        this.httpClient.post<WorkflowResponse>(`${environment.url}api/workflow/UpdateConfiguracionWeb`, request)
          .pipe(
            delay(1000),
            tap((response: WorkflowResponse) => {
              const id = response.wkf01llave;
              this.router.navigate([`dashboard/workflow/parametros/${id}`]); 
            }),
            map((workflow: WorkflowResponse) => new fromActions.UpdateConfiguracionwebSuccess(workflow)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.UpdateConfiguracionwebError(err.message));
            })
          )
      )
    )
  );

  /*
  getnodopadrebyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_WORKFLOW_NODOPADRE),
      map((action: fromActions.GetNodopadrebyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<WorkflowResponse>(`${environment.url}api/workflow/GetWorkflowNodopadreById/${id}`)
        .pipe(
          map((workflow: WorkflowResponse) => new fromActions.GetNodopadrebyidSuccess(workflow)),

          catchError(err => of(new fromActions.GetNodopadrebyidError(err.message)))
        )
      }
      )
    )
  );

  */

  Delete: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_WORKFLOW),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<WorkflowResponse[]>(`${environment.url}api/workflow/${id}`)
        .pipe(
          map((workflows: WorkflowResponse[]) => new fromActions.DeleteSuccess(workflows)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_WORKFLOW),
      map((action: fromActions.Desactivate) => action.workflows),
      switchMap((workflows: WorkflowResponse[]) => {
        return this.httpClient.post<WorkflowResponse[]>(`${environment.url}api/workflow/disableworkflow/`, workflows)
        .pipe(
          map((workflows: WorkflowResponse[]) => new fromActions.DesactivateSuccess(workflows)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_WORKFLOW),
      map((action: fromActions.Activate) => action.workflows),
      switchMap((workflows: WorkflowResponse[]) => {
        return this.httpClient.post<WorkflowResponse[]>(`${environment.url}api/workflow/activateworkflow/`, workflows)
        .pipe(
          map((workflows: WorkflowResponse[]) => new fromActions.ActivateSuccess(workflows)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
