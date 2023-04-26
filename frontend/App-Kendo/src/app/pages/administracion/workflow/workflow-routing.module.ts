import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/workflow-list/workflow-list.module').then(m=>m.WorkflowListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/workflow-nuevo/workflow-nuevo.module').then(m=>m.WorkflowNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    loadChildren: () => import('./pages/workflow-nuevo/workflow-nuevo.module').then(m=>m.WorkflowNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datosgenerales',
    loadChildren: () => import('./pages/workflow-nuevo/workflow-nuevo.module').then(m=>m.WorkflowNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nodopadre',
    loadChildren: () => import('./pages/workflow-nuevo/workflow-nuevo.module').then(m=>m.WorkflowNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'configuracionweb',
    loadChildren: () => import('./pages/workflow-nuevo/workflow-nuevo.module').then(m=>m.WorkflowNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'parametros',
    loadChildren: () => import('./pages/workflow-nuevo/workflow-nuevo.module').then(m=>m.WorkflowNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'perfil',
    loadChildren: () => import('./pages/workflow-nuevo/workflow-nuevo.module').then(m=>m.WorkflowNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'list'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkflowRoutingModule { }
