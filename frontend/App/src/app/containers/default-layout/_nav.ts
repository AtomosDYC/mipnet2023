import { INavData } from '@coreui/angular-pro';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
    badge: {
      color: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'Inmueble',
    url: '/dashboard/inmueble/list',
  },

  {
    title: true,
    name: 'CUENTAS DE USUARIO'
  },
  {
    name: 'cuentas de usuario',
    url: '/dashboard/usuarios/list'
  },
  {
    name: 'ADMINISTRADOR',
    title: true
  },
  {
    name: 'Usuarios',
    url: '/base',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'usuarios',
        url: '/dashboard/usuarios/list'
      },
    ]
  },
  {
    name: 'CONFIGURACIÓN',
    title: true
  },
  {
    name: 'Permisos de Usuarios',
    url: '/',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Roles',
        url: '/dashboard/roles/list'
      },
      {
        name: 'Plantillas Perfiles',
        url: '/dashboard/plantilla/list'
      },
    ]
  },
  {
    name: 'FLujo de trabajo',
    url: '/',
    iconComponent: { name: 'cil-puzzle' },
    children: [

      {
        name: 'FLujo de trabajo',
        url: '/dashboard/flujo/list'
      },
      {
        name: 'Niveles de Permisos',
        url: '/dashboard/nivelpermiso/list'
      },
      {
        name: 'Tipo de Flujo',
        url: '/dashboard/tipoflujo/list'
      },
      {
        name: 'Niveles de Flujo',
        url: '/dashboard/nivelflujo/list'
      },
      {
        name: 'Tipo Permiso',
        url: '/dashboard/tipopermiso/list'
      },
      {
        name: 'Variables de  parametros',
        url: '/dashboard/parametros/list'
      },
      {
        name: 'Tipo Parametro',
        url: '/dashboard/tipoparametro/list'
      },
    ]
  },
  {
    name: 'Personas',
    url: '/',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Tipo de Saludos',
        url: '/dashboard/saludos/list'
      },
      {
        name: 'Tipo Persona',
        url: '/dashboard/tipopersona/list'
      },
      {
        name: 'Tipo Comunicación Persona',
        url: '/dashboard/tipocomunicacionpersona/list'
      }
    ]
  },
  {
    name: 'Ubicación',
    url: '/',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Región',
        url: '/dashboard/region/list'
      },
      {
        name: 'Comuna',
        url: '/dashboard/comuna/list'
      },
      {
        name: 'Zona',
        url: '/dashboard/zona/list'
      },
    ]
  },
  {
    name: 'Especie',
    url: '/',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Tipo Especie',
        url: '/dashboard/tipoespecie/list'
      },
      {
        name: 'Medida de Umbrales',
        url: '/dashboard/medidaumbral/list'
      },
      {
        name: 'Umbrales de Daño',
        url: '/'
      },

      {
        name: 'Estados de Daños',
        url: '/dashboard/estadodanio/list'
      },
      {
        name: 'Reglas de Especie',
        url: '/'
      },
    ]
  },
];
