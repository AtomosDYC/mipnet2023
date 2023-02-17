import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { PlantillaCreateRequest, PlantillaResponse, PlantillaUpdateRequest } from './save.models';
import { environment } from 'environments/environment';

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
          this.httpClient.get<PlantillaResponse[]>(`${environment.url}api/plantilla`)
          .pipe(
            //delay(1000),
            map((plantillas: PlantillaResponse[]) => new fromActions.ReadSuccess(plantillas) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_PLANTILLA),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<PlantillaResponse>(`${environment.url}api/plantilla/GetPlantillaById/${id}`)
        .pipe(
          map((plantilla: PlantillaResponse) => new fromActions.GetbyidSuccess(plantilla)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_PLANTILLA),
      map((action: fromActions.Create) => action.plantilla),
      switchMap((request: PlantillaCreateRequest) =>
        this.httpClient.post<PlantillaResponse>(`${environment.url}api/plantilla`, request)
          .pipe(
            delay(1000),
            tap((response: PlantillaResponse) => {
              this.router.navigate(['dashboard/plantilla/list']);
            }),
            map((plantilla: PlantillaResponse) => new fromActions.CreateSuccess(plantilla)),
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
      ofType(fromActions.Types.UPDATE_PLANTILLA),
      map((action: fromActions.Update) => action.plantilla),
      switchMap((request: PlantillaResponse) =>
        this.httpClient.put<PlantillaResponse>(`${environment.url}api/plantilla`, request)
          .pipe(
            delay(1000),
            tap((response: PlantillaResponse) => {
              this.router.navigate(['dashboard/plantilla/list']);
            }),
            map((plantilla: PlantillaResponse) => new fromActions.UpdateSuccess(plantilla)),
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
      ofType(fromActions.Types.DELETE_PLANTILLA),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<PlantillaResponse[]>(`${environment.url}api/plantilla/${id}`)
        .pipe(
          map((plantillas: PlantillaResponse[]) => new fromActions.DeleteSuccess(plantillas)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_PLANTILLA),
      map((action: fromActions.Desactivate) => action.plantillas),
      switchMap((plantillas: PlantillaResponse[]) => {
        return this.httpClient.post<PlantillaResponse[]>(`${environment.url}api/plantilla/disableplantilla/`, plantillas)
        .pipe(
          map((plantillas: PlantillaResponse[]) => new fromActions.DesactivateSuccess(plantillas)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_PLANTILLA),
      map((action: fromActions.Activate) => action.plantillas),
      switchMap((plantillas: PlantillaResponse[]) => {
        return this.httpClient.post<PlantillaResponse[]>(`${environment.url}api/plantilla/activateplantilla/`, plantillas)
        .pipe(
          map((plantillas: PlantillaResponse[]) => new fromActions.ActivateSuccess(plantillas)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
