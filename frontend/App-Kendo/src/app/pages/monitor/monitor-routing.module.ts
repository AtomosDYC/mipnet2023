import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth/auth.guard';
import { MonitorCelularesModule } from './pages/monitor-celulares/monitor-celulares.module';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/monitor-list/monitor-list.module').then(m=>m.MonitorListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/monitor-nuevo/monitor-nuevo.module').then(m=>m.MonitorNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datosgenerales',
    loadChildren: () => import('./pages/monitor-nuevo/monitor-nuevo.module').then(m=>m.MonitorNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datoscomunicacion',
    loadChildren: () => import('./pages/monitor-nuevo/monitor-nuevo.module').then(m=>m.MonitorNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datosacceso',
    loadChildren: () => import('./pages/monitor-nuevo/monitor-nuevo.module').then(m=>m.MonitorNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'especiesasignadas',
    loadChildren: () => import('./pages/monitor-nuevo/monitor-nuevo.module').then(m=>m.MonitorNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'trampasasignadas',
    loadChildren: () => import('./pages/monitor-nuevo/monitor-nuevo.module').then(m=>m.MonitorNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'movertrampas',
    loadChildren: () => import('./pages/monitor-nuevo/monitor-nuevo.module').then(m=>m.MonitorNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datoscelulares',
    loadChildren: () => import('./pages/monitor-nuevo/monitor-nuevo.module').then(m=>m.MonitorNuevoModule),
    canActivate: [AuthGuard]
  },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MonitorRoutingModule { }
