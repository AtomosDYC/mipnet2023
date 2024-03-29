import { Component, OnInit } from '@angular/core';
import { navItems } from '../default-layout/_nav';

import * as fromRoot from '../../store';
import * as fromUser from '../../store/user';
import { Store, select} from '@ngrx/store';
import { Observable, } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';



@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
})
export class DefaultLayoutComponent implements OnInit {

  public navItems = navItems;
  public perfectScrollbarConfig = {
    suppressScrollX: true,
  };
  user$ : Observable<fromUser.UserResponse>;
  isAuthorized$: Observable<boolean>;

  constructor(
    private router: Router,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute
  ) {}

  ngOnInit(): void {

    this.user$ = this.store.pipe(select(fromUser.getUser)) as Observable<fromUser.UserResponse>;
    this.isAuthorized$ = this.store.pipe(select(fromUser.getIsAuthorized)) as Observable<boolean>;

    this.store.dispatch(new fromUser.Init());

    this._routeParams.paramMap.subscribe(params => {

    })

  }

  onSignOut(): void {
    localStorage.removeItem('token');
    this.store.dispatch(new fromUser.SignOut());
    this.router.navigate(['/join/login']);
  }
}
