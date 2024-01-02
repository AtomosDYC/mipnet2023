import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { PersonacomunicacionResponse, PersonacomunicacionRequest, PersonacomunicacionSource, PersonacomunicacionbyidRequest } from './save.models';
import { environment } from '../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../store/index';
import { Personacomunicacion } from '../../../../../../models/backend/persona';
import { datasourcerequest } from '../../../../../../models/frontend/datasource/request';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";
import { ReadPersonacomunicacion } from './save.actions';


type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }


  ReadPersonacomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_PERSONA_COMUNICACION),
      map((action: fromActions.ReadPersonacomunicacion) => action.personacomunicacion),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/persona/getpersonacomunicacion`, request)
          .pipe(
            map((personacomunicacionsource: GridDataResult) => new fromActions.ReadPersonacomunicacionSuccess(personacomunicacionsource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadPersonacomunicacionError(err.message));
            })
          )
      )
    )
  );

  /*
  GetPersonabyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_PERSONA),
    map((action: fromActions.GetPersonabyid) => action.id),
    switchMap((id: string) => {
      return this.httpClient.get<PersonaResponse>(`${environment.url}api/persona/getpersonabyid/${id}`)
      .pipe(
        map((persona: PersonaResponse) => new fromActions.GetPersonabyidSuccess(persona)),

        catchError(err => of(new fromActions.GetPersonabyidError(err.message)))
      )
    }
    )
  )
);
*/
createpersonacomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_PERSONA_COMUNICACION),
      map((action: fromActions.CreatePersonacomunicacion) => action.personacomunicacion),
      switchMap((request: PersonacomunicacionRequest) =>
        this.httpClient.post<PersonacomunicacionResponse>(`${environment.url}api/persona/createpersonacomunicacion`, request)
          .pipe(
            delay(1000),
            map((personacomunicacion: PersonacomunicacionResponse) => new fromActions.CreatePersonacomunicacionSuccess(personacomunicacion, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreatePersonacomunicacionError(err.message));
            })
          )
      )
    )
  );

  deletepersonacomunicacion: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.DELETE_PERSONA_COMUNICACION),
      map((action: fromActions.DeletePersonacomunicacion) => action.requestbyid),
      switchMap((requestbyid: PersonacomunicacionbyidRequest) => 
        this.httpClient.post(`${environment.url}api/persona/deletepersonacomunicacion`, requestbyid)
          .pipe(
            delay(1000),
            map(() => new fromActions.DeletePersonacomunicacionSuccess(true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.DeletePersonacomunicacionError(err.message));
            })
            )
        )
      )
    );

/*
  updatepersona: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_PERSONA),
      map((action: fromActions.UpdatePersona) => action.persona),
      switchMap((request: PersonaRequestUpdate) =>
        this.httpClient.put<PersonaResponse>(`${environment.url}api/persona/updatepersona`, request)
          .pipe(
            delay(1000),
            tap((response: PersonaResponse) => {
              this.router.navigate(['dashboard/persona/datoscomunicacion']);
            }),
            map((persona: PersonaResponse) => new fromActions.UpdatePersonaSuccess(persona, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.UpdatePersonaError(err.message));
            })
          )
      )
    )
  );
  */

}
