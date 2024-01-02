import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { PersonaResponse, PersonaRequest, PersonaSource, PersonaRequestUpdate } from './save.models';
import { environment } from '../../../../../environments/environment';

import * as fromvisibleToast from '../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../store/index';
import { Persona } from '../../../../models/backend/persona';
import { GetPersonabyidError, CreatePersonaError, CreatePersona } from './save.actions';
import { datasourcerequest } from '../../../../models/frontend/datasource/request';

import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult } from "@progress/kendo-angular-grid";

type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  /*
  ReadEspecieDatosgenerales: Observable<Action> = createEffect( () =>
      this.actions.pipe(
        ofType(fromActions.Types.READ_PERSONA),
        switchMap( () =>
          this.httpClient.get<PersonaResponse[]>(`${environment.url}api/persona`)
          .pipe(
            //delay(1000),
            map((personas: PersonaResponse[]) => new fromActions.ReadPersonaSuccess(personas) ),
            catchError(err => of(new fromActions.ReadPersonaError(err.message)))
          )
        )
      )
  );
  */

  Read: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.READ_PERSONA),
      map((action: fromActions.ReadPersona) => action.persona),
      switchMap((request: RequestState) =>
        this.httpClient.post<GridDataResult>(`${environment.url}api/persona/getpersonas`, request)
          .pipe(
            map((personasource: GridDataResult) => new fromActions.ReadPersonaSuccess(personasource)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.ReadPersonaError(err.message));
            })
          )
      )
    )
  );

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

createpersona: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_PERSONA),
      map((action: fromActions.CreatePersona) => action.persona),
      switchMap((request: PersonaRequest) =>
        this.httpClient.post<PersonaResponse>(`${environment.url}api/persona/createpersona`, request)
          .pipe(
            delay(1000),
            tap((response: PersonaResponse) => {
              const id = response.per01llave;
              this.router.navigate([`dashboard/personas/datoscomunicacion/${id}`]); 
            }),
            map((persona: PersonaResponse) => new fromActions.CreatePersonaSuccess(persona, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreatePersonaError(err.message));
            })
          )
      )
    )
  );

  updatepersona: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_PERSONA),
      map((action: fromActions.UpdatePersona) => action.persona),
      switchMap((request: PersonaRequestUpdate) =>
        this.httpClient.put<PersonaResponse>(`${environment.url}api/persona/updatepersona`, request)
          .pipe(
            delay(1000),
            tap((response: PersonaResponse) => {
              const id = response.per01llave;
              this.router.navigate([`dashboard/personas/datoscomunicacion/${id}`]); 
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

}
