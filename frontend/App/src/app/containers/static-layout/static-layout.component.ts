import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../store';
import * as fromUser from '../../store/user';
import { Store, select} from '@ngrx/store';
import { Observable, } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-static-layout',
  templateUrl: './static-layout.component.html',
  styleUrls: ['./static-layout.component.scss']
})
export class StaticLayoutComponent implements OnInit {

  public perfectScrollbarConfig = {
    suppressScrollX: true,
  };
  user$ : Observable<fromUser.UserResponse>;
  isAuthorized$: Observable<boolean>;

  constructor(
    private router: Router,
    private store: Store<fromRoot.State>
  ) { }


  ngOnInit(): void {

    this.user$ = this.store.pipe(select(fromUser.getUser)) as Observable<fromUser.UserResponse>;
    this.isAuthorized$ = this.store.pipe(select(fromUser.getIsAuthorized)) as Observable<boolean>;

    this.store.dispatch(new fromUser.Init());

  }

  onSignOut(): void {
    localStorage.removeItem('token');
    this.store.dispatch(new fromUser.SignOut());
    this.router.navigate(['/join/login']);
  }
}
