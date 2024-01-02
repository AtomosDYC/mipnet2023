import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromList from '../../store/save';
import { Router } from '@angular/router';
import * as fromMenu from '../../../../store/menu';

import { GridDataResult, PageChangeEvent } from "@progress/kendo-angular-grid";

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

import { FormControl, FormGroup } from '@angular/forms';
import { CompositeFilterDescriptor, SortDescriptor } from '@progress/kendo-data-query';
import { State as RequestState } from "@progress/kendo-data-query";

import { monitordesactivateRequest } from '../../store/save/save.models';

import {
  filePdfIcon, SVGIcon,
} from "@progress/kendo-svg-icons";

@Component({
  selector: 'app-monitor-list',
  templateUrl: './monitor-list.component.html',
  styleUrls: ['./monitor-list.component.scss']
})
export class MonitorListComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';

  public customMsgService: CustomMessagesService;

  public Form: FormGroup = new FormGroup(
    {
      txtSearch: new FormControl(null),
    }
  );

  loadGrid: boolean = true;
  public filter: CompositeFilterDescriptor = {
    logic: 'and',
    filters: [
      {
        field: 'per01nombrerazon',
        operator: 'contains',
        value: '',
      },
    ],
  };

  public skip : number = 0;
  public take : number = 10;
  
  public sort: SortDescriptor[] = [
    {
      field: "mnt01activo",
      dir: "asc",
    },
    {
      field: "per01nombrerazon",
      dir: "asc",
    },
  ];

  public requeststate: RequestState = {
    skip: this.skip,
    take: this.take,
    filter: this.filter,
    sort: this.sort
  };

  public svgpdf: SVGIcon = filePdfIcon;

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
    }

  
  ngOnInit(): void {
   
    this.Form = new FormGroup({
      txtSearch: new FormControl(null),
    });

    this.OnloadGrid();
    
  }

  public OnloadGrid(): void{

    this.filter = {
      logic: 'and',
      filters: [
        {
          field: 'per01nombrerazon',
          operator: "contains",
          value: this.filtro.toString()
        },
      ],
    };

    this.requeststate = {
      skip: this.skip,
      take: this.take,
      filter: this.filter,
      sort: this.sort
    }

    this.store.dispatch(new fromList.ReadMonitor(this.requeststate));

    this.loading$ = this.store.pipe(select(fromList.getLoading));

    this.data$ =  this.store.pipe(select(fromList.getMonitores));

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });
    
  }

  public sortChange(sort: SortDescriptor[]): void {
    this.sort = sort;
    this.OnloadGrid();
  }

  public SubmitSearch(state: any): void {

    this.filtro = state.txtSearch;
    this.OnloadGrid();
    
  }

  public pageChange(state: PageChangeEvent): void {

    this.skip = state.skip; 
    this.OnloadGrid();
  }

  public onKeyDown(pressedKey) {
    //console.log('pressedKey',pressedKey);
    if (pressedKey.key==="Enter") {
      
    }
  }

  OnNuevo(){
    this._Route.navigate(['/dashboard/monitor/datosgenerales']);
  }

  OnEditar(id: number){
    this.store.dispatch(new fromMenu.MenuExpanded(false));
    this._Route.navigate(['/dashboard/monitor/datosgenerales/', id.toString()]);
  }

  OnEliminar(id: number, estado : number){
    
    if(estado == 0){
      if (confirm("Esta seguro de eliminar este tipo de Parametro?"))
      {
        this.store.dispatch(new fromList.DeleteMonitor(id.toString()));
        var success$:Observable<boolean | null> = this.store.pipe(select(fromList.getSuccess));  
        
        success$.subscribe((success) => { 
          if(success) {

            this.OnloadGrid();
            
          }
        })
      }
    } else {
      this.store.dispatch(new fromList.DeleteMonitor(id.toString()));
      
      var success$:Observable<boolean | null> = this.store.pipe(select(fromList.getSuccess));  
      success$.subscribe((success) => { 
        if(success) {

          this.OnloadGrid();
          
        }
      })
    }
  }

  OndisableRegion():void {

    
    const request: monitordesactivateRequest[] =  this.mySelection.map((item) => {
      const data:monitordesactivateRequest = {
        mnt01llave: Number(item)
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.DesactivateMonitor(request!));
      this.mySelection = [];
      var success$:Observable<boolean | null> = this.store.pipe(select(fromList.getSuccess));  
        
      success$.subscribe((success) => { 
        if(success) {

          this.OnloadGrid();
          
        }
      })
    }
    
  }

  onactivateRegion():void {

    
    const request: monitordesactivateRequest[] =  this.mySelection.map((item) => {

      const data:monitordesactivateRequest = {
        mnt01llave: Number(item)
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.Activatemonitor(request!));

      this.mySelection = [];

      var successactivate$:Observable<boolean | null> = this.store.pipe(select(fromList.getSuccess));  
        
      successactivate$.subscribe((success) => { 
        if(success) {

          this.OnloadGrid();
          
        }
      })
    }

  }

}
