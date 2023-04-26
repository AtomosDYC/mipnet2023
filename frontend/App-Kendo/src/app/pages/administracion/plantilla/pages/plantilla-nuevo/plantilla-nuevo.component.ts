import { Component, OnInit } from '@angular/core';
import { DrawerItem, DrawerSelectEvent } from '@progress/kendo-angular-layout';

import { PlantillaItemsNav } from './_nav'
import { Router, ActivatedRoute, UrlSegment } from '@angular/router';

interface Item {
  text: string;
  id: number;
  path: string;
  selected?: boolean;
  disabled?: boolean;
}

@Component({
  selector: 'app-plantilla-nuevo',
  templateUrl: './plantilla-nuevo.component.html',
  styleUrls: ['./plantilla-nuevo.component.scss']
})
export class PlantillaNuevoComponent implements OnInit {

  public selectedItem: any;
  public PlantillaItems: Array<Item> = PlantillaItemsNav;
  
  public selected = "Datos Generales";

  public ID: string | null;

  

  constructor(private router: Router, 
    private _routeParams: ActivatedRoute) { 

    }

  ngOnInit(): void {

    this._routeParams.parent?.url.subscribe(path =>{
      const url: UrlSegment[] = path.map(path =>{ return path })
      this.selectedItem = url[0]!.path;
    });

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        const dato =  this.PlantillaItems.map((item:Item)=>{
          
          const d = {
            text: item.text,
            path: item.path,
            id: item.id,
            disabled: false
          } 
          return d;
        });
    
        this.PlantillaItems = dato;

      }
    });

  }

  public onSelect(ev: DrawerSelectEvent): void {
    this.selected = ev.item.text;
    const current = ev.item.id;

    if(ev.item.path){
        this.router.navigate([ev.item.path + this.ID]);
    }

  }

}
