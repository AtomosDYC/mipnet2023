import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromList from '../../store/save';
import * as fromMenu from '../../../../store/menu';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { CompositeFilterDescriptor, SortDescriptor } from "@progress/kendo-data-query";


import { State as RequestState } from "@progress/kendo-data-query";

import { GridDataResult, PageChangeEvent } from "@progress/kendo-angular-grid";


import {
  filePdfIcon, SVGIcon,
} from "@progress/kendo-svg-icons";
import { FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-clienteusuario-list',
  templateUrl: './clienteusuario-list.component.html',
  styleUrls: ['./clienteusuario-list.component.scss']
})
export class ClienteusuarioListComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;
  datainactiva$! : Observable<GridDataResult | null>;

  public svgpdf: SVGIcon = filePdfIcon;

  public Form: FormGroup = new FormGroup(
    {
      txtSearch: new FormControl(null),
    }
  );

  listadatos : any;
  loading$! : Observable<boolean | null>;
  loadGrid: boolean = true;
  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';
  public events: string[] = [];

  public customMsgService: CustomMessagesService;

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


  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService
    ) 
  {
    this.customMsgService = this.messages as CustomMessagesService;
  }

  ngOnInit(): void {
    
    this.Form = new FormGroup({
      txtSearch: new FormControl(null),
    });

    this.OnloadGrid();
    this.OnloadGridInactivo();
    
  }

  public sortChange(sort: SortDescriptor[]): void {
    this.sort = sort;
    this.OnloadGrid();
    this.OnloadGridInactivo();
  }

  public SubmitSearch(state: any): void {

    this.filtro = state.txtSearch;
    this.OnloadGrid();
    this.OnloadGridInactivo();
    
  }

  public pageChange(state: PageChangeEvent): void {

    this.skip = state.skip; 
    this.OnloadGrid();
    this.OnloadGridInactivo();
  }

  public onKeyDown(pressedKey) {
    //console.log('pressedKey',pressedKey);
    if (pressedKey.key==="Enter") {
      
    }
  }

  public OnloadGrid(): void{

    console.log('dentro del grid');
    console.log(this.filtro.toString());

    this.filter = {
      logic: 'and',
      filters: [
        {
          field: 'quecontenga',
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

    this.store.dispatch(new fromList.ReadClienteUsuarioActiva(this.requeststate));
    this.loading$ = this.store.pipe(select(fromList.getLoading));

    
    this.data$ =  this.store.pipe(select(fromList.getClienteUsuarioActiva));

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });
    
  }

  public OnloadGridInactivo(): void{

    this.filter = {
      logic: 'and',
      filters: [
        {
          field: 'quecontenga',
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

    this.store.dispatch(new fromList.ReadClienteUsuarioInactiva(this.requeststate));
    this.loading$ = this.store.pipe(select(fromList.getLoading));

    
    this.datainactiva$ =  this.store.pipe(select(fromList.getClienteUsuarioInactiva));
    console.log('this.datainactiva$', this.datainactiva$);

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });
    
  }

 

  OnNuevo(){

    this.store.dispatch(new fromMenu.MenuExpanded(false));
    this._Route.navigate(['/dashboard/clienteusuario/datosgenerales']);
 
    }

  OnEditar(id: number){
    
    const llave = btoa(id.toString()); 
    
    this.store.dispatch(new fromMenu.MenuExpanded(false));

    this._Route.navigate(['/dashboard/clienteusuario/datosgenerales/', llave]);
  
  }

  OnEliminar(id: number, estado : number){

/*
    
    if(estado == 0){
      if (confirm("Esta seguro de eliminar el cliente estación?"))
      {
        this.store.dispatch(new fromList.DeleteClienteEstacion(id.toString()));
        var success$:Observable<boolean | null> = this.store.pipe(select(fromList.getSuccess));  
        
        success$.subscribe((success) => { 
          if(success) {

            this.OnloadGrid();
            
          }
        })
      }
    } else {
      this.store.dispatch(new fromList.DeleteClienteEstacion(id.toString()));
      
      var success$:Observable<boolean | null> = this.store.pipe(select(fromList.getSuccess));  
      success$.subscribe((success) => { 
        if(success) {

          this.OnloadGrid();
          
        }
      })
    }
      */
  }

  OndisableClienteestacion():void {

    /*
    const request: clienteusuariodesactivateRequest[] =  this.mySelection.map((item) => {
      const data:clienteusuariodesactivateRequest = {
        cnt01llave: Number(item)
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.DesactivateClienteEstacion(request!));
      this.mySelection = [];
      var success$:Observable<boolean | null> = this.store.pipe(select(fromList.getSuccess));  
        
      success$.subscribe((success) => { 
        if(success) {

          this.OnloadGrid();
          
        }
      })
    }
    */
  }

  onactivateClienteestacion():void {
/*
    
    const request: clienteusuariodesactivateRequest[] =  this.mySelection.map((item) => {

      const data:clienteusuariodesactivateRequest = {
        cnt01llave: Number(item)
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.ActivateClienteEstacion(request!));

      this.mySelection = [];

      var successactivate$:Observable<boolean | null> = this.store.pipe(select(fromList.getSuccess));  
        
      successactivate$.subscribe((success) => { 
        if(success) {

          this.OnloadGrid();
          
        }
      })
    }
      */

  }

}