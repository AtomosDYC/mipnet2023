import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { PlantillaflujoCreateRequest, PlantillaflujoResponse, PlantillaflujoUpdateRequest } from './save.models';
import { environment } from '../../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../../store/index';



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
          this.httpClient.get<PlantillaflujoResponse[]>(`${environment.url}api/plantillaflujo`)
          .pipe(
            //delay(1000),
            map((plantillas: PlantillaflujoResponse[]) => new fromActions.ReadSuccess(plantillas) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_PLANTILLAFLUJO),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<PlantillaflujoResponse>(`${environment.url}api/plantillaflujo/GetPlantillaById/${id}`)
        .pipe(
          map((plantilla: PlantillaflujoResponse) => new fromActions.GetbyidSuccess(plantilla)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_PLANTILLAFLUJO),
      map((action: fromActions.Create) => action.plantillaflujo),
      switchMap((request: PlantillaflujoCreateRequest) =>
        this.httpClient.post<PlantillaflujoResponse>(`${environment.url}api/plantillaflujo`, request)
          .pipe(
            delay(1000),
            tap((response: PlantillaflujoResponse) => {
              
            }),
            map((plantilla: PlantillaflujoResponse) => new fromActions.CreateSuccess(plantilla, true)),
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
      ofType(fromActions.Types.UPDATE_PLANTILLAFLUJO),
      map((action: fromActions.Update) => action.plantillaflujo),
      switchMap((request: PlantillaflujoResponse) =>
        this.httpClient.put<PlantillaflujoResponse>(`${environment.url}api/plantillaflujo`, request)
          .pipe(
            delay(1000),
            tap((response: PlantillaflujoResponse) => {
              this.router.navigate(['dashboard/plantilla/list']);
            }),
            map((plantilla: PlantillaflujoResponse) => new fromActions.UpdateSuccess(plantilla)),
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
      ofType(fromActions.Types.DELETE_PLANTILLAFLUJO),
      map((action: fromActions.Delete) => action.id),
      switchMap((id: string) => {
        return this.httpClient.delete<PlantillaflujoResponse[]>(`${environment.url}api/plantilla/${id}`)
        .pipe(
          map((plantillas: PlantillaflujoResponse[]) => new fromActions.DeleteSuccess(plantillas, true)),

          catchError(err => of(new fromActions.DeleteError(err.message)))
        )
      }
      )
    )
  );

  Desactivate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DESACTIVATE_PLANTILLAFLUJO),
      map((action: fromActions.Desactivate) => action.plantillaflujos),
      switchMap((plantillas: PlantillaflujoResponse[]) => {
        return this.httpClient.post<PlantillaflujoResponse[]>(`${environment.url}api/plantilla/disableplantilla/`, plantillas)
        .pipe(
          map((plantillas: PlantillaflujoResponse[]) => new fromActions.DesactivateSuccess(plantillas)),

          catchError(err => of(new fromActions.DesactivateError(err.message)))
        )
      }

      )
    )
  );

  Activate: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.ACTIVATE_PLANTILLAFLUJO),
      map((action: fromActions.Activate) => action.plantillaflujos),
      switchMap((plantillas: PlantillaflujoResponse[]) => {
        return this.httpClient.post<PlantillaflujoResponse[]>(`${environment.url}api/plantilla/activateplantilla/`, plantillas)
        .pipe(
          map((plantillas: PlantillaflujoResponse[]) => new fromActions.ActivateSuccess(plantillas)),

          catchError(err => of(new fromActions.ActivateError(err.message)))
        )
      }
      )
    )
  );

}
