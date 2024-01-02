import { Injectable } from '@angular/core';
import * as fromActions from './save.actions';
import { HttpClient } from '@angular/common/http'
import { Actions, createEffect, ofType } from '@ngrx/effects'
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { MenuResponse } from './save.models';
import { environment } from '../../../environments/environment';
import { State } from '../index';
import { Store } from '@ngrx/store';
import * as fromvisibleToast from '../notification/notification.actions';

import {ActionReducer, INIT, MetaReducer} from '@ngrx/store';
import { getExpanded } from './save.selectors';

//this.store.dispatch(fromvisibleToast.onError(err.error.errores.mensaje));


type Action = fromActions.All;

@Injectable()
export class MenuEffects {

  constructor(
    private actions: Actions,
    private router: Router,
    private httpClient: HttpClient,
    private store: Store<State>,
  ) { }

  Menu: Observable<Action> = createEffect( () =>
      this.actions.pipe(
        ofType(fromActions.Types.MENU),
        switchMap( () =>
          this.httpClient.get<MenuResponse[]>(`${environment.url}api/menu`)
          .pipe(
            //delay(1000),
            map((menus: MenuResponse[]) => new fromActions.MenuSuccess(menus))) ),
            catchError(err => of(new fromActions.MenuError(err.message)))
          )
        )
    
  MenuExpanded: Observable<Action> = createEffect(() => 
    this.actions.pipe(
      ofType(fromActions.Types.MENU_EXPANDED),
      map((action: fromActions.MenuExpanded) => action.expand),
      switchMap((expand) => {

        console.log('dentro del menuexpanded', 'expand');

        if(expand == true){
          localStorage.setItem('expanded', 'true');
          return  of(new fromActions.MenuExpandedSuccess(true));
        } else {
          localStorage.setItem('expanded', 'false');
          return  of(new fromActions.MenuExpandedSuccess(false));
        }
      }
      )
    )
  );
  
}


