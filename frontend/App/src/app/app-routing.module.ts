import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DefaultLayoutComponent, StaticLayoutComponent } from './containers';
import { Page404Component } from './pages/static/pages/page404/page404.component';
import { PageInicioComponent } from './pages/static/pages/page-inicio/page-inicio.component';
import { LoginComponent  } from './pages/auth/login/login.component'




const routes: Routes = [
  {
    path: '',
    redirectTo: '/inicio',
    pathMatch: 'full',

  },
  {
    path: '',
    component: StaticLayoutComponent,
    children: [
      {
        path: 'inicio',
        component: PageInicioComponent
      },
      {
        path: 'login',
        component: LoginComponent
      }
    ]
  },

  {
    path: 'dashboard',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'dashboard',
        loadChildren: () =>
          import('./views/dashboard/dashboard.module').then((m) => m.DashboardModule)
      },
      {
        path: 'theme',
        loadChildren: () =>
          import('./views/theme/theme.module').then((m) => m.ThemeModule)
      }
    ]
  },
  {path: '**', component: Page404Component}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'top',
      anchorScrolling: 'enabled',
      initialNavigation: 'enabledBlocking',
      useHash: false,
      relativeLinkResolution: 'legacy'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
