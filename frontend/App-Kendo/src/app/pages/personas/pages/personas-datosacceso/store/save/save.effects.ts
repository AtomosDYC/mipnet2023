import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { PersonaAccesoResponse, PersonaAccesoRequest } from './save.models';
import { environment } from '../../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../../store/index';


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

 
  GetPersonaAcceso: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_PERSONA_ACCESO),
    map((action: fromActions.GetPersonaAcceso) => action.id),
    switchMap((id: string) => {
      return this.httpClient.get<PersonaAccesoResponse>(`${environment.url}api/persona/getpersonaacceso/${id}`)
      .pipe(
        map((personaacceso: PersonaAccesoResponse) => new fromActions.GetPersonaAccesoSuccess(personaacceso)),

        catchError(err => of(new fromActions.GetPersonaAccesoError(err.message)))
      )
    }
    )
  )
);

createpersonaacceso: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_PERSONA_ACCESO),
      map((action: fromActions.CreatePersonaAcceso) => action.personaacceso),
      switchMap((request: PersonaAccesoRequest) =>
        this.httpClient.post<PersonaAccesoResponse>(`${environment.url}api/persona/createpersonaacceso`, request)
          .pipe(
            delay(1000),
            tap((response: PersonaAccesoResponse) => {
               
            }),
            map((personaacceso: PersonaAccesoResponse) => new fromActions.CreatePersonaAccesoSuccess(personaacceso, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreatePersonaAccesoError(err.message));
            })
          )
      )
    )
  );

  updatepersonaaacceso: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.UPDATE_PERSONA_ACCESO),
      map((action: fromActions.UpdatePersonaAcceso) => action.personaacceso),
      switchMap((request: PersonaAccesoRequest) =>
        this.httpClient.put<PersonaAccesoResponse>(`${environment.url}api/persona/updatepersonaacceso`, request)
          .pipe(
            delay(1000),
            tap((response: PersonaAccesoResponse) => {
              
            }),
            map((personaacceso: PersonaAccesoResponse) => new fromActions.UpdatePersonaAccesoSuccess(personaacceso, true)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.UpdatePersonaAccesoError(err.message));
            })
          )
      )
    )
  );

}
