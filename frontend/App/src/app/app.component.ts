import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

import { IconSetService } from '@coreui/icons-angular';
import { iconSubset } from './icons/icon-subset';
import { Title } from '@angular/platform-browser';

import { environment } from '../environments/environment';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromRoot from './store';
import * as fromUser from './store/user';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'body',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {
  title = 'mipNET - control de plagas online';

  user$! : Observable<fromUser.UserResponse>;
  isAuthorized$!: Observable<boolean>;

  constructor(
    private router: Router,
    private titleService: Title,
    private iconSetService: IconSetService,
    private store: Store<fromRoot.State>,
  ) {
    titleService.setTitle(this.title);
    // iconSet singleton
    iconSetService.icons = { ...iconSubset };
  }

  ngOnInit(): void {

    this.user$ = this.store.pipe(select(fromUser.getUser)) as Observable<fromUser.UserResponse>;
    this.isAuthorized$ = this.store.pipe(select(fromUser.getIsAuthorized)) as Observable<boolean>;

    this.store.dispatch(new fromUser.Init());


    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
    });
  }

  onSignOut() : void {
    localStorage.removeItem('token');
    this.store.dispatch(new fromUser.SignOut());
    this.router.navigate(['/auth/login']);
  }


}
