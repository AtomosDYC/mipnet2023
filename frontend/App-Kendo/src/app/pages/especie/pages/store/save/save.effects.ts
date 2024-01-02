import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { EspecieResponse, EspecieDatosgeneralesRequest, EspecieDatosgeneralesUpdateRequest } from './save.models';
import { environment } from '../../../../../../environments/environment';

import * as fromvisibleToast from '../../../../../store/notification/notification.actions';
import { Store } from '@ngrx/store';
import { State } from '../../../../../store/index';
import { Especie } from '../../../../../models/backend/especie/index';
import { ReadEspecieDatosgenerales, CreateEspecie, UpdateEspecie, CreateEspecieSuccess } from './save.actions';

type Action = fromActions.All;

@Injectable()
export class SaveEffects {

  constructor(
    private actions: Actions,
    private httpClient: HttpClient,
    private router: Router,
    private store: Store<State>,

  ) { }

  ReadEspecieDatosgenerales: Observable<Action> = createEffect( () =>
      this.actions.pipe(
        ofType(fromActions.Types.READ_ESPECIE),
        switchMap( () =>
          this.httpClient.get<EspecieResponse[]>(`${environment.url}api/especie`)
          .pipe(
            //delay(1000),
            map((especies: EspecieResponse[]) => new fromActions.ReadEspecieDatosgeneralesSuccess(especies) ),
            catchError(err => of(new fromActions.ReadEspecieDatosgeneralesError(err.message)))
          )
        )
      )
  );

  GetEspecieDatosGeneralesbyid: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.GET_ESPECIE),
    map((action: fromActions.GetEspecieDatosGeneralesbyid) => action.id),
    switchMap((id: string) => {
      return this.httpClient.get<EspecieResponse>(`${environment.url}api/especie/GetEspecieById/${id}`)
      .pipe(
        map((especie: EspecieResponse) => new fromActions.GetEspecieDatosGeneralesbyidSuccess(especie)),

        catchError(err => of(new fromActions.GetEspecieDatosGeneralesbyidError(err.message)))
      )
    }
    )
  )
);

CreateEspecie: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_ESPECIE_DATOSGENERALES),
      map((action: fromActions.CreateEspecie) => action.especie),
      switchMap((request: EspecieDatosgeneralesRequest) =>
        this.httpClient.post<EspecieResponse>(`${environment.url}api/especie/createdatosgenerales`, request)
          .pipe(
            delay(1000),
            tap((response: EspecieResponse) => {
              const id = response.esp03llave;
              this.router.navigate([`dashboard/especies/especies/unirespecies/${id}`]); 
            }),
            map((especie: EspecieResponse) => new fromActions.CreateEspecieSuccess(especie)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
              return of(new fromActions.CreateEspecieError(err.message));
            })
          )
      )
    )
  );

  UpdateEspecie: Observable<Action> = createEffect(() =>
  this.actions.pipe(
    ofType(fromActions.Types.UPDATE_ESPECIE_DATOSGENERALES),
    map((action: fromActions.UpdateEspecie) => action.especie),
    switchMap((request: EspecieDatosgeneralesUpdateRequest) =>
      this.httpClient.put<EspecieResponse>(`${environment.url}api/especie/updatedatosgenerales`, request)
        .pipe(
          delay(1000),
          tap((response: EspecieResponse) => {
            const id = response.esp03llave;
            this.router.navigate([`dashboard/especies/especies/unirespecies/${id}`]); 
          }),
          map((especie: EspecieResponse) => new fromActions.UpdateEspecieSuccess(especie)),
          catchError(err => {
            this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));
            return of(new fromActions.UpdateEspecieError(err.message));
          })
        )
    )
  )
);


}
