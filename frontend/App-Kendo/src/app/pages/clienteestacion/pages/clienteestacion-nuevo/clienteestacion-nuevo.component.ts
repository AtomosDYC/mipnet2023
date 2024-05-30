import { Component, OnInit } from '@angular/core';

import { clienteestacionItems } from './_nav';
import { Router, ActivatedRoute } from '@angular/router';
import { Path } from '@progress/kendo-drawing';
import { DrawerSelectEvent } from '@progress/kendo-angular-layout';

interface Item {
  text: string;
  id: number;
  path: string;
  selected?: boolean;
  disabled?: boolean;
}

@Component({
  selector: 'app-clienteestacion-nuevo',
  templateUrl: './clienteestacion-nuevo.component.html',
  styleUrls: ['./clienteestacion-nuevo.component.scss']
})
export class ClienteestacionNuevoComponent implements OnInit {

  public clienteestacionItems: Array<Item> = clienteestacionItems;
  
  public selected = "Tipo Comunicacion";

  public ID: string | null;

  constructor(private router: Router, 
    private _routeParams: ActivatedRoute) { 

    }

  ngOnInit(): void {

    //console.log('url',this._routeParams.snapshot);
    const rutas = this.router.url.split('/')
    const largo = rutas.length;

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        const dato =  this.clienteestacionItems.map((item:Item)=>{
          var d:Item;
          if(item.path.split('/')[3] == this.router.url.split('/')[3]){
            d = {
              text: item.text,
              path: item.path,
              id: item.id,
              disabled: false,
              selected:true,
            }
          } else {
            d = {
              text: item.text,
              path: item.path,
              id: item.id,
              disabled: false,
              selected:false,
            }
          }
         return d;
        });
    
        this.clienteestacionItems = dato;
        //console.log('cliente estacion dato',dato);

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
