import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { MedidaUmbralCreateRequest, MedidaUmbralResponse, MedidaUmbralUpdateRequest } from './save.models';
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
          this.httpClient.get<MedidaUmbralResponse[]>(`${environment.url}api/medidaumbral`)
          .pipe(
            //delay(1000),
            map((medidaumbrales: MedidaUmbralResponse[]) => new fromActions.ReadSuccess(medidaumbrales) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_MEDIDAUMBRAL),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<MedidaUmbralResponse>(`${environment.url}api/medidaumbral/GetMedidaUmbralById/${id}`)
        .pipe(
          map((medidaumbral: MedidaUmbralResponse) => new fromActions.GetbyidSuccess(medidaumbral)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_MEDIDAUMBRAL),
      map((action: fromActions.Create) => action.medidaumbral),
      switchMap((request: MedidaUmbralCreateRequest) =>
        this.httpClient.post<MedidaUmbralResponse>(`${environment.url}api/medidaumbral`, request)
          .pipe(
            delay(1000),
            tap((response: MedidaUmbralResponse) => {
              this.router.navigate(['dashboard/especies/medidaumbral/list']);
            }),
            map((medidaumbral: MedidaUmbralResponse) => new fromActions.CreateSuccess(medidaumbral)),
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
      ofType(fromActions.Types.UPDATE_MEDIDAUMBRAL),
      map((action: fromActions.Update) => action.medidaumbral),
      switchMap((request: MedidaUmbralResponse) =>
        this.httpClient.put<MedidaUmbralResponse>(`${environment.url}api/medidaumbral`, request)
          .pipe(
            delay(1000),
            tap((response: MedidaUmbralResponse) => {
              this.router.navigate(['dashboard/especies/medidaumbral/list']);
            }),
            map((medidaumbral: MedidaUmbralResponse) => new fromActions.UpdateSuccess(medidaumbral)),
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
      ofType(fromActions.Types.DELETE_MEDIDAUMBRAL),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<MedidaUmbralResponse[]>(`${environment.url}api/medidaumbral/${id}`)
        .pipe(
          map((medidaumbrales: MedidaUmbralResponse[]) => new fromActions.DeleteSuccess(medidaumbrales)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_MEDIDAUMBRAL),
      map((action: fromActions.Desactivate) => action.medidaumbrales),
      switchMap((medidaumbrales: MedidaUmbralResponse[]) => {
        return this.httpClient.post<MedidaUmbralResponse[]>(`${environment.url}api/medidaumbral/disablemedidaumbral/`, medidaumbrales)
        .pipe(
          map((medidaumbrales: MedidaUmbralResponse[]) => new fromActions.DesactivateSuccess(medidaumbrales)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_MEDIDAUMBRAL),
      map((action: fromActions.Activate) => action.medidaumbrales),
      switchMap((medidaumbrales: MedidaUmbralResponse[]) => {
        return this.httpClient.post<MedidaUmbralResponse[]>(`${environment.url}api/medidaumbral/activatemedidaumbral/`, medidaumbrales)
        .pipe(
          map((medidaumbrales: MedidaUmbralResponse[]) => new fromActions.ActivateSuccess(medidaumbrales)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
