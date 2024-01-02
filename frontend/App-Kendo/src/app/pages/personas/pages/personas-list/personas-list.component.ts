import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromList from '../../store/save';
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
  selector: 'app-personas-list',
  templateUrl: './personas-list.component.html',
  styleUrls: ['./personas-list.component.scss']
})
export class PersonasListComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;

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

    this.store.dispatch(new fromList.ReadPersona(this.requeststate));

    this.loading$ = this.store.pipe(select(fromList.getLoading));

    this.data$ =  this.store.pipe(select(fromList.getPersonas));

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });
    
  }

 

  OnNuevo(){
    this._Route.navigate(['/dashboard/personas/datosgenerales']);
  }

  OnEditar(id: number){
    this._Route.navigate(['/dashboard/personas/datosgenerales/', id.toString()]);
  }

  OnEliminar(id: number, estado : number){
    /*
    if(estado == 0){
      if (confirm("Esta seguro de eliminar este tipo de Parametro?"))
      {
        this.store.dispatch(new fromList.Delete(id.toString()));
      }
    } else {
      this.store.dispatch(new fromList.Delete(id.toString()));
    }
    */
  }

  OndisableRegion():void {

    /*
    const request: Response[] =  this.mySelection.map((item) => {
      const data:Response = {
        wkf10llave: Number(item),
        wkf10activo: 1,
        wkf10nombre:'',
        wkf10descripcion:''
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.Desactivate(request!));
      this.mySelection = [];
    }
    */

  }

  onactivateRegion():void {

    /*
    const request: Response[] =  this.mySelection.map((item) => {

      const data:Response = {
        wkf10llave: Number(item),
        wkf10activo: 1,
        wkf10nombre:'',
        wkf10descripcion:''
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.Activate(request!));
      this.mySelection = [];
    }
    */
  }

}
