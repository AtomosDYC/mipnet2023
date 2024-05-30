import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DefaultLayoutComponent, StaticLayoutComponent } from '../app/containers';
import { UnauthGuard } from './guards/unauth/unauth.guard';
import { AuthGuard } from './guards/auth/auth.guard';
import { RegisterModule } from './pages/auth/pages/register/register.module';
import { EmailConfirmationModule } from './pages/auth/pages/email-confirmation/email-confirmation.module';
import { TemporadaModule } from './pages/temporada/temporada.module';

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

      },
      {
        path: 'user/forgotpassword',
        loadChildren:() => import('./pages/auth/pages/forgot-password/forgot-password.module').then(m=>m.ForgotPasswordModule)

      },
      {
        path: 'user/resetpassword',
        loadChildren:() => import('./pages/auth/pages/reset-password/reset-password.module').then(m=>m.ResetPasswordModule)
      },
      {
        path: 'mailconfirmation',
        loadChildren:() => import('./pages/auth/pages/email-confirmation/email-confirmation.module').then(m=>m.EmailConfirmationModule)
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
          import('./pages/dashboard/dashboard.module').then((m) => m.DashboardModule),
          canActivate: [AuthGuard]
      },
      {
        path: '',
        loadChildren: () =>
          import('./pages/dashboard/dashboard.module').then((m) => m.DashboardModule),
      },
//cliente estacion
      {
        path: 'clienteusuario',
        loadChildren: () =>
          import('./pages/clienteusuario/clienteusuario.module').then((m) => m.ClienteusuarioModule),
      },
//cliente estacion
      {
        path: 'clienteestacion',
        loadChildren: () =>
          import('./pages/clienteestacion/clienteestacion.module').then((m) => m.ClienteestacionModule),
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
        path: 'defaultuser',
        loadChildren: () =>
          import('./pages/administracion/defaultuser/defaultuser.module').then((m) => m.DefaultuserModule),
      },
      {
        path: 'plantilla',
        loadChildren: () =>
          import('./pages/administracion/plantilla/plantilla.module').then((m) => m.PlantillaModule),
      },
      // monitor
      {
        path: 'monitor',
        loadChildren: () =>
          import('./pages/monitor/monitor.module').then((m) => m.MonitorModule),
      },
      //personas
      {
        path: 'personas',
        loadChildren: () =>
          import('./pages/personas/personas.module').then((m) => m.PersonasModule),
      },
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
        path: 'tipodocumento',
        loadChildren: () =>
          import('./pages/administracion/tipodocumento/tipodocumento.module').then((m) => m.TipodocumentoModule),
      },
      {
        path: 'tipocomunicacionpersona',
        loadChildren: () =>
          import('./pages/administracion/tipocomunicacionpersona/tipocomunicacionpersona.module').then((m) => m.TipocomunicacionpersonaModule),
      },

      //workflow
      {
        path: 'workflow',
        loadChildren: () =>
          import('./pages/administracion/workflow/workflow.module').then((m) => m.WorkflowModule),
      },
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
//regiones
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
  //especies
      {
        path: 'especies/especies',
        loadChildren: () =>
          import('./pages/especie/especie.module').then((m) => m.EspecieModule),
      },
      {
        path: 'especies/tipoespecie',
        loadChildren: () =>
          import('./pages/administracion/tipoespecie/tipoespecie.module').then((m) => m.TipoespecieModule),
      },
      {
        path: 'especies/medidaumbral',
        loadChildren: () =>
          import('./pages/administracion/medidaumbral/medidaumbral.module').then((m) => m.MedidaumbralModule),
      },
      {
        path: 'especies/estadodanio',
        loadChildren: () =>
          import('./pages/administracion/estadodanio/estadodanio.module').then((m) => m.EstadodanioModule),
      },
      //especie temporada
      {
        path: 'especies/especietemporada',
        loadChildren: () =>
          import('./pages/especietemporada/especietemporada.module').then((m) => m.EspecietemporadaModule),
      },
      //temporada
      {
        path: 'temporadas/segmentartemporada',
        loadChildren: () =>
          import('./pages/administracion/segmentartemporada/segmentartemporada.module').then((m) => m.SegmentartemporadaModule),
      },
      {
        path: 'temporadas/temporadabase',
        loadChildren: () =>
          import('./pages/administracion/temporadabase/temporadabase.module').then((m) => m.TemporadabaseModule),
      },
      {
        path: 'temporada',
        loadChildren: () =>
          import('./pages/temporada/temporada.module').then((m) => m.TemporadaModule),
      },
      //monitoreo
      {
        path: 'monitoreos/monitoreo',
        loadChildren: () =>
          import('./pages/monitoreo/monitoreo.module').then((m) => m.MonitoreoModule),
      },
      {
        path: 'monitoreo/visarmonitoreo',
        loadChildren: () =>
          import('./pages/visarmonitoreo/visarmonitoreo.module').then((m) => m.VisarmonitoreoModule),
      },
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
