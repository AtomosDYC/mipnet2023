import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DefaultLayoutComponent, StaticLayoutComponent } from './containers';
import { UnauthGuard } from './guards/unauth/unauth.guard';
import { AuthGuard } from './guards/auth/auth.guard';
import { RegisterModule } from './pages/auth/pages/register/register.module';

const routes: Routes = [
  {
    path: '',
    component: StaticLayoutComponent,
    children: [
      {
        path: '',
        loadChildren:() => import('./pages/static/static.module').then(m=>m.StaticModule)
      },
      {
        path: 'join/login',
        loadChildren:() => import('./pages/auth/pages/login/login.module').then(m=>m.LoginModule),
        canActivate: [UnauthGuard]
      },
      {
        path: 'user/registro',
        loadChildren:() => import('./pages/auth/pages/register/register.module').then(m=>m.RegisterModule)

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
          import('./views/dashboard/dashboard.module').then((m) => m.DashboardModule),
          canActivate: [AuthGuard]
      },
      {
        path: '',
        loadChildren: () =>
          import('./views/dashboard/dashboard.module').then((m) => m.DashboardModule),
      },
//usuarios
      {
        path: 'usuarios',
        loadChildren: () =>
          import('./pages/usuarios/usuario/usuario.module').then((m) => m.UsuarioModule),
      },

      {
        path: 'roles',
        loadChildren: () =>
          import('./pages/administracion/roles/roles.module').then((m) => m.RolesModule),
      },
      {
        path: 'plantilla',
        loadChildren: () =>
          import('./pages/administracion/plantilla/plantilla.module').then((m) => m.PlantillaModule),
      },
      //personas
      {
        path: 'saludos',
        loadChildren: () =>
          import('./pages/administracion/saludo/saludo.module').then((m) => m.SaludoModule),
      },
      {
        path: 'tipopersona',
        loadChildren: () =>
          import('./pages/administracion/tipopersona/tipopersona.module').then((m) => m.TipopersonaModule),
      },
      {
        path: 'tipocomunicacionpersona',
        loadChildren: () =>
          import('./pages/administracion/tipocomunicacionpersona/tipocomunicacionpersona.module').then((m) => m.TipocomunicacionpersonaModule),
      },

      //workflow
      {
        path: 'tipoflujo',
        loadChildren: () =>
          import('./pages/administracion/tipoflujo/tipoflujo.module').then((m) => m.TipoflujoModule),
      },
      {
        path: 'nivelflujo',
        loadChildren: () =>
          import('./pages/administracion/nivelflujo/nivelflujo.module').then((m) => m.NivelflujoModule),
      },
      {
        path: 'tipopermiso',
        loadChildren: () =>
          import('./pages/administracion/tipopermiso/tipopermiso.module').then((m) => m.TipopermisoModule),
      },
      {
        path: 'nivelpermiso',
        loadChildren: () =>
          import('./pages/administracion/nivelpermiso/nivelpermiso.module').then((m) => m.NivelpermisoModule),
      },
      {
        path: 'tipoparametro',
        loadChildren: () =>
          import('./pages/administracion/tipoparametro/tipoparametro.module').then((m) => m.TipoparametroModule),
      },


      {
        path: 'inmueble',
        loadChildren: () =>
          import('./pages/inmueble/inmueble.module').then((m) => m.InmuebleModule),
      },
      {
        path: 'region',
        loadChildren: () =>
          import('./pages/administracion/region/region.module').then((m) => m.RegionModule),
      },
      {
        path: 'comuna',
        loadChildren: () =>
          import('./pages/administracion/comuna/comuna.module').then((m) => m.ComunaModule),
      },
      {
        path: 'zona',
        loadChildren: () =>
          import('./pages/administracion/zona/zona.module').then((m) => m.ZonaModule),
      },
      {
        path: 'tipoespecie',
        loadChildren: () =>
          import('./pages/administracion/tipoespecie/tipoespecie.module').then((m) => m.TipoespecieModule),
      },
      {
        path: 'medidaumbral',
        loadChildren: () =>
          import('./pages/administracion/medidaumbral/medidaumbral.module').then((m) => m.MedidaumbralModule),
      },
      {
        path: 'estadodanio',
        loadChildren: () =>
          import('./pages/administracion/estadodanio/estadodanio.module').then((m) => m.EstadodanioModule),
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
