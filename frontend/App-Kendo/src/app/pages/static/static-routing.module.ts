import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./pages/welcome/welcome.module').then(m=> m.WelcomeModule)
  },
  {
    path: 'welcome',
    loadChildren: () => import('./pages/welcome/welcome.module').then(m=> m.WelcomeModule)
  },
  {
    path: 'error500',
    loadChildren:()=> import('./pages/error500/error500.module').then(m=> m.Error500Module)
  },
  {
    path: '404',
    loadChildren:()=> import('./pages/not-found/not-found.module').then(m=> m.NotFoundModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StaticRoutingModule { }
