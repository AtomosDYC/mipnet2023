import { Component, OnInit, OnDestroy } from '@angular/core';

import * as fromRoot from '../../store';
import * as fromUser from '../../store/user';
import { Store, select} from '@ngrx/store';
import { Observable, } from 'rxjs';
import { Router, ActivatedRoute, NavigationStart } from '@angular/router';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from '../../services/custom-messages.service';
import { DrawerComponent, DrawerSelectEvent, DrawerMode, DrawerItem, DrawerItemExpandedFn } from '@progress/kendo-angular-layout';
import { navItems } from './_nav';



@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
})
export class DefaultLayoutComponent implements OnInit, OnDestroy{

    public selected = 'DashBoard';
    public customMsgService: CustomMessagesService;
    public mode: DrawerMode = 'push';
    public mini = true;

    public navItems: Array<DrawerItem> = navItems;

    public expandedIndices = [2];

    public isItemExpanded: DrawerItemExpandedFn = (item): boolean => {
        return this.expandedIndices.indexOf(item.id) >= 0;
    };

    public toggleDrawer(drawer: DrawerComponent): void {
      drawer.toggle();
  }

    constructor(
      private router: Router, 
      public msgService: MessageService,
      private store: Store<fromRoot.State>,
      private _routeParams: ActivatedRoute
      ) {
        this.customMsgService = this.msgService as CustomMessagesService;
      }

    ngOnInit() {

      this.user$ = this.store.pipe(select(fromUser.getUser)) as Observable<fromUser.UserResponse>;
      this.isAuthorized$ = this.store.pipe(select(fromUser.getIsAuthorized)) as Observable<boolean>;

      this.store.dispatch(new fromUser.Init());

      this.setDrawerConfig();

      window.addEventListener('resize', () => {
          this.setDrawerConfig();
      });
        
    }

    public setDrawerConfig() {
      const pageWidth = window.innerWidth;
      if (pageWidth <= 840) {
          this.mode = 'overlay';
          this.mini = false;
      } else {
          this.mode = 'push';
          this.mini = true;
      }
  }



    ngOnDestroy() {
        window.removeEventListener('resize', () => {});
    }

    public onSelect(ev: DrawerSelectEvent): void {

        console.log('dentro del onselect',ev);

        this.selected = ev.item.text;
        const current = ev.item.id;

        if (this.expandedIndices.indexOf(current) >= 0) {

          this.expandedIndices = this.expandedIndices.filter(
              (id) => id !== current
          );
          if(ev.item.path){
            this.router.navigate([ev.item.path]);
          }

        } else {

          this.expandedIndices.push(current);
          if(ev.item.path){
            this.router.navigate([ev.item.path]);
          }

        }

        
        this.selected = ev.item.text;
    }


  public perfectScrollbarConfig = {
    suppressScrollX: true,
  };

  user$ : Observable<fromUser.UserResponse>;
  isAuthorized$: Observable<boolean>;


  onSignOut(): void {
    localStorage.removeItem('token');
    this.store.dispatch(new fromUser.SignOut());
    this.router.navigate(['/join/login']);
  }
}
