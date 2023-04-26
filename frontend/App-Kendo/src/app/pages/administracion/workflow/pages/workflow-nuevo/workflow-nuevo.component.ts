import { Component, OnInit } from '@angular/core';
import { DrawerItem, DrawerSelectEvent } from '@progress/kendo-angular-layout';

import { WorkflowItemsNav } from './_nav'
import { Router, ActivatedRoute } from '@angular/router';

interface Item {
  text: string;
  id: number;
  path: string;
  selected?: boolean;
  disabled?: boolean;
}

@Component({
  selector: 'app-workflow-nuevo',
  templateUrl: './workflow-nuevo.component.html',
  styleUrls: ['./workflow-nuevo.component.scss']
})
export class WorkflowNuevoComponent implements OnInit {

  public WorkflowItems: Array<Item> = WorkflowItemsNav;
  
  public selected = "Tipo Comunicacion";

  public ID: string | null;

  

  constructor(private router: Router, 
    private _routeParams: ActivatedRoute) { 

    }

  ngOnInit(): void {

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        const dato =  this.WorkflowItems.map((item:Item)=>{
          
          const d = {
            text: item.text,
            path: item.path,
            id: item.id,
            disabled: false
          } 
          return d;
        });
    
        this.WorkflowItems = dato;

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
