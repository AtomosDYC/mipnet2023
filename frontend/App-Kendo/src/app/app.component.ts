import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, NavigationStart, Router, RouterEvent } from '@angular/router';

import { MessageService } from '@progress/kendo-angular-l10n';
import { DrawerComponent, DrawerMode, DrawerSelectEvent } from '@progress/kendo-angular-layout';
import { CustomMessagesService } from './services/custom-messages.service';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromRoot from './store';
import * as fromUser from './store/user';

@Component({
    selector: 'body',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit, OnDestroy {
    public selected = 'Team';
    public items: Array<any> = [];
    public customMsgService: CustomMessagesService;
    public mode: DrawerMode = 'push';
    public mini = true;

    user$! : Observable<fromUser.UserResponse>;
    isAuthorized$!: Observable<boolean>;

    constructor(
        private router: Router, 
        public msgService: MessageService,
        private store: Store<fromRoot.State>
        ) {
            this.customMsgService = this.msgService as CustomMessagesService;
    }

    ngOnInit() {

        this.store.dispatch(new fromUser.Init());

        this.user$ = this.store.pipe(select(fromUser.getUser)) as Observable<fromUser.UserResponse>;
        this.isAuthorized$ = this.store.pipe(select(fromUser.getIsAuthorized)) as Observable<boolean>;

        

        /*

        this.router.events.subscribe((evt) => {
        if (!(evt instanceof NavigationEnd)) {
            return;
        }
        });

        // Update Drawer selected state when change router path
        this.router.events.subscribe((route: any) => {
            if (route instanceof NavigationStart) {
                this.items = this.drawerItems().map((item) => {
                    if (item.path && item.path === route.url) {
                        item.selected = true;
                        return item;
                    } else {
                        item.selected = false;
                        return item;
                    }
                });
            }
        });

        this.setDrawerConfig();

        this.customMsgService.localeChange.subscribe(() => {
            this.items = this.drawerItems();
        });

        window.addEventListener('resize', () => {
            this.setDrawerConfig();
        });
        */
    }

    ngOnDestroy() {
        window.removeEventListener('resize', () => {});
    }

    /*

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
*/
    /*
    public drawerItems() {
        return [
            { text: this.customMsgService.translate('team'), icon: 'k-i-grid', path: '/', selected: true },
            { text: this.customMsgService.translate('dashboard'), icon: 'k-i-chart-line-markers', path: '/dashboard', selected: false },
            { text: this.customMsgService.translate('planning'), icon: 'k-i-calendar', path: '/planning', selected: false },
            { text: this.customMsgService.translate('profile'), icon: 'k-i-user', path: '/profile', selected: false },
            { separator: true },
            { text: this.customMsgService.translate('info'), icon: 'k-i-information', path: '/info', selected: false }
        ];
    }

    public toggleDrawer(drawer: DrawerComponent): void {
        drawer.toggle();
    }
*/
    
}
