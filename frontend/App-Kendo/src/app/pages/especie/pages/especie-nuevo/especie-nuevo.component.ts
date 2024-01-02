import { Component, OnInit } from '@angular/core';
import { DrawerItem, DrawerSelectEvent } from '@progress/kendo-angular-layout';

import { EspecieItems } from './_nav'
import { Router, ActivatedRoute } from '@angular/router';

interface Item {
  text: string;
  id: number;
  path: string;
  selected?: boolean;
  disabled?: boolean;
}

@Component({
  selector: 'app-especie-nuevo',
  templateUrl: './especie-nuevo.component.html',
  styleUrls: ['./especie-nuevo.component.scss']
})
export class EspecieNuevoComponent implements OnInit {

  public EspecieItems: Array<Item> = EspecieItems;
  
  public selected = "Tipo Comunicacion";

  public ID: string | null;

  

  constructor(private router: Router, 
    private _routeParams: ActivatedRoute) { 

    }

  ngOnInit(): void {

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        const dato =  this.EspecieItems.map((item:Item)=>{
          
          const d = {
            text: item.text,
            path: item.path,
            id: item.id,
            disabled: false
          } 
          return d;
        });
    
        this.EspecieItems = dato;

      }
    });

  }

  public onSelect(ev: DrawerSelectEvent): void {
    this.selected = ev.item.text;
    const current = ev.item.id;

    if(ev.item.path){
      if(this.ID) {
        this.router.navigate([ev.item.path + this.ID]);
      } else {
        this.router.navigate([ev.item.path]);
      }
    }

  }

}