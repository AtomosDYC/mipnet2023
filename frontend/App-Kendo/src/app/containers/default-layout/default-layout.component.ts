import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';

import * as fromRoot from '../../store';
import * as fromUser from '../../store/user';
import * as fromMenu from '../../store/menu';
import * as fromLoader from '../../store/loader';

import { Store, select} from '@ngrx/store';
import { Observable, observable, } from 'rxjs';
import { Router, ActivatedRoute, NavigationStart } from '@angular/router';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from '../../services/custom-messages.service';
import { DrawerComponent, DrawerSelectEvent, DrawerMode, DrawerItem, DrawerItemExpandedFn } from '@progress/kendo-angular-layout';
import { navItems } from './_nav';

import {
  SVGIcon,
  bellIcon,
  calendarIcon,
  inboxIcon,
  menuIcon,
  starOutlineIcon,
} from "@progress/kendo-svg-icons";

import { MenuService } from '../../services/menu.service';
import { getExpanded } from '../../store/menu/save.selectors';
import { MenuExpanded } from '../../store/menu/save.actions';
import { error } from 'console';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
})
export class DefaultLayoutComponent implements OnInit, OnDestroy{

    public selected = 'DashBoard';
    public customMsgService: CustomMessagesService;
    public mode: DrawerMode = 'push';
    public mini = true;
    public expandible: boolean =  true;
    public loading$: Observable<boolean | null | undefined>

    public menuSvg: SVGIcon = menuIcon;

    public navItems: Array<DrawerItem> = navItems;

    public expandedIndices = [2];

    private _Menu;
    public DataMenu;
    private errorMessage;
    public loadingPanelVisible = false;
    public buttonText = "Show Loading Panel";

    user$ : Observable<fromUser.UserResponse>;
    isAuthorized$: Observable<boolean>;

    @ViewChild('drawer')
    drawer!: DrawerComponent;
    

    public isItemExpanded: DrawerItemExpandedFn = (item): boolean => {
        return this.expandedIndices.indexOf(item.id) >= 0;
    };

    public toggleDrawer(drawer: DrawerComponent): void {
      if(drawer){
        drawer.toggle();
      }
  }

    constructor(
      private router: Router, 
      public msgService: MessageService,
      private store: Store<fromRoot.State>,

      
      private _routeParams: ActivatedRoute,
      MenuService: MenuService,
      ) {
        this.customMsgService = this.msgService as CustomMessagesService;
        this._Menu = MenuService;
      }

    ngOnInit() {

      this.store.dispatch(new fromUser.Init());

      this.user$ = this.store.pipe(select(fromUser.getUser)) as Observable<fromUser.UserResponse>;
      this.isAuthorized$ = this.store.pipe(select(fromUser.getIsAuthorized)) as Observable<boolean>;
    
    
      this._Menu.GetMenu().subscribe(
        allrecords => {
          this.DataMenu = allrecords     
        },
        error => this.errorMessage = <any>error
      );

      this.setDrawerConfig();

      window.addEventListener('resize', () => {
          this.setDrawerConfig();
      });

      var expandedaa$ = this.store.pipe(select(fromMenu.getExpanded));
      expandedaa$.subscribe(
        (expand) => {
          this.expandible == expand;

          this.toggleDrawer(this.drawer);

        }
      )


      this.loading$ = this.store.pipe(select(fromLoader.getLoader));
      this.loading$.subscribe(
        success => {

          console.log('dentro del loading, dentro del loading, ', success)

          this.onVisibleLoader(success);
          

        }
      )


      
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


  public onVisibleLoader(success: boolean | undefined | null ): void {

    if(success){
      this.loadingPanelVisible = true;
    } 
    else 
    {
      this.loadingPanelVisible = false;
    }
  }

  public onButtonClick(): void {
    this.loadingPanelVisible = !this.loadingPanelVisible;

    if (this.loadingPanelVisible) {
      this.buttonText = "Hide Loading Panel";
    } else {
      this.buttonText = "Show Loading Panel";
    }
  }

  logout(){
    
  }

    ngOnDestroy() {
        window.removeEventListener('resize', () => {});
    }

    public onSelect(ev: DrawerSelectEvent): void {

        //console.log('dentro del onselect',ev);

        this.selected = ev.item.text;
        const current = ev.item.id;

        if (this.expandedIndices.indexOf(current) >= 0) {
          //console.log('esta opcion tiene hijos');

          this.expandedIndices = this.expandedIndices.filter(
              (id) => id !== current
          );
          if(ev.item.path){
           
            if(ev.item.path == 'default.aspx')
            {

            } else {
              this.router.navigate([ev.item.path]);
              this.store.dispatch(new fromMenu.MenuExpanded(true));
            }
          } else {
            if(ev.item.text == 'Logout'){
              this.onSignOut();
            }
          }

        } else {

          //console.log('esta opcion no tiene hijos');
          this.expandedIndices.push(current);
          if(ev.item.path){
            if(ev.item.path == 'default.aspx')
            {

            } else {
              this.router.navigate([ev.item.path]);
              this.store.dispatch(new fromMenu.MenuExpanded(true));
            }
          } else {
            if(ev.item.text  == 'Logout'){
              this.onSignOut();
            }
          }

        }

        
        this.selected = ev.item.text;
    }


  public perfectScrollbarConfig = {
    suppressScrollX: true,
  };

  


  onSignOut(): void {
    //console.log("inside logout");
    localStorage.removeItem('token');
    this.store.dispatch(new fromUser.SignOut());
    this.router.navigate(['/join/login']);
  }
}
