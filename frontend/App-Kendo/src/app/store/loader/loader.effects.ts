import { Injectable } from '@angular/core';
import * as fromActions from './loader.action';
import { Actions, createEffect, ofType } from '@ngrx/effects'
import { Observable, of } from 'rxjs';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { State } from '../index';
import { Store } from '@ngrx/store';


type Action = fromActions.All;

@Injectable()
export class MenuEffects {

  constructor(
    private actions: Actions,
    private store: Store<State>,
  ) { }

  onsuccess = createEffect(() => {
    return this.actions.pipe(
      ofType(fromActions.Types.ON_SUCCESS),
      map((action: fromActions.onsuccess) =>  { 
        return  of(new fromActions.onsuccess());
      })
    );
    }, { dispatch: false }
  );

  cambiarestado = createEffect(() => {
    return this.actions.pipe(
      ofType(fromActions.Types.CAMBIAR_ESTADO),
      map((action: fromActions.cambiarestado) =>  { 
        return  of(new fromActions.cambiarestado());
      })
    );
    }, { dispatch: false }
  );
  
}


