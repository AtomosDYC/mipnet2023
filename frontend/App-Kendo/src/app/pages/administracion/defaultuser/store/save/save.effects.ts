import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import * as fromActions from './save.actions';

import { DefaultUserCreateRequest, DefaultUserResponse } from './save.models';
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
          this.httpClient.get<DefaultUserResponse>(`${environment.url}api/defaultuser`)
          .pipe(
            //delay(1000),
            map((defaultuser: DefaultUserResponse) => new fromActions.ReadSuccess(defaultuser) ),
            catchError(err => of(new fromActions.ReadError(err.message)))
          )
        )
      )
  );

  getbyid: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.GET_DEFAULTUSER),
      map((action: fromActions.Getbyid) => action.id),
      switchMap((id: string) => {
        return this.httpClient.get<DefaultUserResponse>(`${environment.url}api/defaultuser/GetDefaultUserById/${id}`)
        .pipe(
          map((defaultuser: DefaultUserResponse) => new fromActions.GetbyidSuccess(defaultuser)),

          catchError(err => of(new fromActions.GetbyidError(err.message)))
        )
      }
      )
    )
  );

  create: Observable<Action> = createEffect(() =>
    this.actions.pipe(
      ofType(fromActions.Types.CREATE_DEFAULTUSER),
      map((action: fromActions.Create) => action.defaultuser),
      switchMap((request: DefaultUserCreateRequest) =>
        this.httpClient.post<DefaultUserResponse>(`${environment.url}api/defaultuser`, request)
          .pipe(
            delay(1000),
            tap((response: DefaultUserResponse) => {
              this.router.navigate(['dashboard/defaultuser/list']);
            }),
            map((defaultuser: DefaultUserResponse) => new fromActions.CreateSuccess(defaultuser)),
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
      ofType(fromActions.Types.UPDATE_DEFAULTUSER),
      map((action: fromActions.Update) => action.defaultuser),
      switchMap((request: DefaultUserResponse) =>
        this.httpClient.put<DefaultUserResponse>(`${environment.url}api/defaultuser`, request)
          .pipe(
            delay(1000),
            tap((response: DefaultUserResponse) => {
              this.router.navigate(['dashboard/defaultuser/list']);
            }),
            map((defaultuser: DefaultUserResponse) => new fromActions.UpdateSuccess(defaultuser)),
            catchError(err => {
              this.store.dispatch(fromvisibleToast.onError());
              return of(new fromActions.CreateError(err.message));
            })
          )
      )
    )
  );

  
 
}
