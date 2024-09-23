import { Component, OnInit, ViewChild } from '@angular/core';


import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';

import { clienteusuarioItems } from './_nav';
import { Router, ActivatedRoute } from '@angular/router';
import { DrawerComponent, DrawerItemExpandedFn, DrawerMode, DrawerSelectEvent } from '@progress/kendo-angular-layout';

import { MenuService } from '../../../../services/menu.service';
import { MenuestacionService } from '../../../../services/menuestacion.service';

interface Item {
  text: string;
  id: number;
  path: string;
  selected?: boolean;
  disabled?: boolean;
}

@Component({
  selector: 'app-clienteusuario-nuevo',
  templateUrl: './clienteusuario-nuevo.component.html',
  styleUrls: ['./clienteusuario-nuevo.component.scss']
})
export class ClienteusuarioNuevoComponent implements OnInit {

  public ID: string | null;

  public selected = "Tipo Comunicacion";
  public expandedIndices = [1];

  private _Menu;
  public DataMenuEstacion = clienteusuarioItems;
  private errorMessage;
  public mode: DrawerMode = 'push';
  public mini = false;
  public expandible: boolean =  true;

  @ViewChild('drawerestacion')
  drawer!: DrawerComponent;

  
  public isItemExpanded: DrawerItemExpandedFn = (item): boolean => {
    return this.expandedIndices.indexOf(item.id) >= 0;
};


  public toggleDrawer(drawer: DrawerComponent): void {
    if(drawer){
      //drawer.toggle();
    }
  }


  constructor(private router: Router, 
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    MenuestacionService: MenuestacionService) { 
      this._Menu = MenuestacionService;
    }

  ngOnInit(): void {

    console.log('dentro del contenedor nuevo');

    this._routeParams.paramMap.subscribe(params => {
      const llave = (params.get('id'));

      if(llave) {
        this.ID = atob(llave);
      
        this._Menu.GetMenuEstacion(llave.toString(), this.ID.toString()).subscribe(
            allrecords => {

              this.DataMenuEstacion = allrecords   ;  

            },
            error => this.errorMessage = <any>error
          );

          this.setDrawerConfig();

          window.addEventListener('resize', () => {
              this.setDrawerConfig();
          });

          this.toggleDrawer(this.drawer);
        }
      });

    }

  public setDrawerConfig() {
    
    const pageWidth = window.innerWidth;
    if (pageWidth <= 840) {
        this.mode = 'overlay';
        this.mini = false;
    } else {
        this.mode = 'push';
        this.mini = true;
    }

}

  public onSelect(ev: DrawerSelectEvent): void {

    console.log('dentro del onselect de la estacion',ev);

    this.selected = ev.item.text;
    const current = ev.item.id;

    if (this.expandedIndices.indexOf(current) >= 0) {
      //console.log('esta opcion tiene hijos');

      this.expandedIndices = this.expandedIndices.filter(
          (id) => id !== current
      );
      if(ev.item.path){

        console.log('ev.item.path',ev.item.path);
       
        if(ev.item.path == 'default.aspx')
        {

        } else {
          this.router.navigate([ev.item.path]);
          
        }
      }

    } else {

      //console.log('esta opcion no tiene hijos');
      this.expandedIndices.push(current);
      if(ev.item.path){

        console.log('ev.item.path 2 ',ev.item.path);
        
        
        this.router.navigate([ev.item.path]);
        
      } 

    }

    
    this.selected = ev.item.text;
}

}
