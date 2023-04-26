

export const navItems = [
  {
    text: 'Dashboard',
    path: '/dashboard',
    selected: true,
    id: 0,
    icon: 'k-i-user',
  },
  {
    separator: true,
    id: 1,
  },
  {
    text: 'Usuarios',
    icon: 'k-i-user',
    id: 2,
  },
  { 
    text: 'usuarios',
    path: '/dashboard/usuarios/list',
    id: 3,
    parentId: 2,
  },
  {
    separator: true,
    id: 4,
  },
  {
    text: 'ADMINISTRADOR',
    id: 5,
    icon: 'k-i-cog',
  },
  
  {
    text: 'Configuración Usuarios',
    icon: 'k-i-user',
    id: 8,
    parentId: 5,
  },
  {
    text: 'Permisos de Usuarios',
    path: '/',
    id: 9,
    parentId: 8,
    icon: 'k-i-user',
  },
  {
    text: 'Roles',
    path: '/dashboard/roles/list',
    id: 10,
    parentId: 8,
    icon: 'k-i-user',
  },
  {
    text: 'Cuenta por defecto ',
    path: '/dashboard/defaultuser/list',
    id: 10,
    parentId: 8,
    icon: 'k-i-user',
  },
  {
    text: 'Plantillas Perfiles',
    path: '/dashboard/plantilla/list',
    id: 11,
    parentId: 8,
    icon: 'k-i-categorize',
  },
  {
    text: 'FLujo de trabajo',
    icon: 'k-i-inherited',
    id: 12,
    parentId: 5,
  },
  {
    text: 'FLujo de trabajo',
    icon: 'k-i-inherited',
    path: '/dashboard/workflow/list',
    id: 13,
    parentId: 12,
  },
  {
    text: 'Niveles de Permisos',
    icon: 'k-i-inherited',
    path: '/dashboard/nivelpermiso/list',
    id: 14,
    parentId: 12,
  },
  {
    text: 'Tipo de Flujo',
    icon: 'k-i-inherited',
    path: '/dashboard/tipoflujo/list',
    id: 15,
    parentId: 12,
  },
  {
    text: 'Niveles de Flujo',
    icon: 'k-i-inherited',
    path: '/dashboard/nivelflujo/list',
    id: 16,
    parentId: 12,
  },
  {
    text: 'Tipo Permiso',
    icon: 'k-i-inherited',
    path: '/dashboard/tipopermiso/list',
    id: 17,
    parentId: 12,
  },
  {
    text: 'Tipo Parametro',
    icon: 'k-i-inherited',
    path: '/dashboard/tipoparametro/list',
    id: 19,
    parentId: 12,
  },
  {
    text: 'Personas',
    icon: 'cil-puzzle',
    id: 20,
    parentId: 5,
  },
  {
    text: 'Tipo de Saludos',
    path: '/dashboard/saludos/list',
    id: 21,
    parentId: 20,
  },
  {
    text: 'Tipo Persona',
    path: '/dashboard/tipopersona/list',
    id: 22,
    parentId: 20,
  },
  {
    text: 'Tipo Comunicación Persona',
    path: '/dashboard/tipocomunicacionpersona/list',
    id: 23,
    parentId: 20,
  },
  {
    text: 'Tipo Documento',
    path: '/dashboard/tipodocumento/list',
    id: 22,
    parentId: 20,
  },
  {
    text: 'Ubicación',
    icon: 'fa-area-chart',
    id: 24,
    parentId: 5,
  },
  {
    text: 'Región',
    path: '/dashboard/region/list',
    id: 25,
    parentId: 24,
  },
  {
    text: 'Comuna',
    path: '/dashboard/comuna/list',
    id: 26,
    parentId: 24,
  },
  {
    text: 'Zona',
    path: '/dashboard/zona/list',
    id: 27,
    parentId: 24,
  },
  {
    text: 'Especie',
    icon: 'fa-duotone fa-bee',
    id: 28,
    parentId: 5,
  },
  {
    text: 'Tipo Especie',
    path: '/dashboard/tipoespecie/list',
    id: 29,
    parentId: 28,
  },
  {
    text: 'Medida de Umbrales',
    path: '/dashboard/medidaumbral/list',
    id: 30,
    parentId: 28,
  },
  {
    text: 'Umbrales de Daño',
    path: '/',
    id: 31,
    parentId: 28,
  },

  {
    text: 'Estados de Daños',
    path: '/dashboard/estadodanio/list',
    id: 32,
    parentId: 28,
  },
  {
    text: 'Reglas de Especie',
    path: '/',
    id: 39,
    parentId: 28,
  } 
]
