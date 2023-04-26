import { FormControlOptions } from '@angular/forms';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { Store, select } from '@ngrx/store';
import * as fromRoot from '../../store';
import * as fromUser from './../../store/user';
import { Observable } from 'rxjs';
import { filter, tap, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UnauthGuard implements CanActivate, CanActivateChild, CanLoad {

  constructor(
    private router: Router,
    private store: Store<fromRoot.State>
  ){}
  canLoad(route: Route, segments: UrlSegment[]): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
   return this.check();
  }
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    return this.check();
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
     return this.check();
  }

    private check() : Observable<boolean> {
      return this.store.pipe(select(fromUser.getUserState)).pipe(
        filter(state => !state.loading),
        tap( state => {
          console.log('antes del unauth', state);
          if(state.email){
            this.router.navigate(['/dashboard']);
          }
        }),
        map(state => !state.email)
      )
    }





}
