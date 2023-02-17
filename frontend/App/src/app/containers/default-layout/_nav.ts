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
    url: '/theme/colors',
    iconComponent: { name: 'cil-drop' }
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
        url: '/'
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
