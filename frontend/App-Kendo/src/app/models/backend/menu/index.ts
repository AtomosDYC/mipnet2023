export interface Menu{
    text: string;
    path: string;
    selected: boolean;
    id: number;
    icon: string;
    parentId: number | null;
  }
  
  export interface Menus{
    menus: Menu[];
  }
  