import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { RegionCreateRequest, RegionResponse, RegionUpdateRequest } from './save.models';
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
          this.httpClient.get<RegionResponse[]>(`${environment.url}api/region`)
          .pipe(
            //delay(1000),
            map((regiones: RegionResponse[]) => new fromActions.ReadSuccess(regiones) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_REGION),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<RegionResponse>(`${environment.url}api/region/GetRegionById/${id}`)
        .pipe(
          map((region: RegionResponse) => new fromActions.GetbyidSuccess(region)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_REGION),
      map((action: fromActions.Create) => action.region),
      switchMap((request: RegionCreateRequest) =>
        this.httpClient.post<RegionResponse>(`${environment.url}api/region`, request)
          .pipe(
            delay(1000),
            tap((response: RegionResponse) => {
              this.router.navigate(['dashboard/region/list']);
            }),
            map((region: RegionResponse) => new fromActions.CreateSuccess(region)),
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
      ofType(fromActions.Types.UPDATE_REGION),
      map((action: fromActions.Update) => action.region),
      switchMap((request: RegionResponse) =>
        this.httpClient.put<RegionResponse>(`${environment.url}api/region`, request)
          .pipe(
            delay(1000),
            tap((response: RegionResponse) => {
              this.router.navigate(['dashboard/region/list']);
            }),
            map((region: RegionResponse) => new fromActions.UpdateSuccess(region)),
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
      ofType(fromActions.Types.DELETE_REGION),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<RegionResponse[]>(`${environment.url}api/region/${id}`)
        .pipe(
          map((regiones: RegionResponse[]) => new fromActions.DeleteSuccess(regiones)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_REGION),
      map((action: fromActions.Desactivate) => action.regiones),
      switchMap((regiones: RegionResponse[]) => {
        return this.httpClient.post<RegionResponse[]>(`${environment.url}api/region/disableregion/`, regiones)
        .pipe(
          map((regiones: RegionResponse[]) => new fromActions.DesactivateSuccess(regiones)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_REGION),
      map((action: fromActions.Activate) => action.regiones),
      switchMap((regiones: RegionResponse[]) => {
        return this.httpClient.post<RegionResponse[]>(`${environment.url}api/region/activateregion/`, regiones)
        .pipe(
          map((regiones: RegionResponse[]) => new fromActions.ActivateSuccess(regiones)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
