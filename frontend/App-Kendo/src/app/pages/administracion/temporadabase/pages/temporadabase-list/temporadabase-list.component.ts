import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from '../../store/save';
import { TemporadaBaseResponse as Response, TemporadabasedesactivateResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { State as RequestState } from "@progress/kendo-data-query";

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import {DataStateChangeEvent, GridDataResult } from "@progress/kendo-angular-grid";
import { FormControl, FormGroup } from '@angular/forms';
import { CompositeFilterDescriptor, SortDescriptor } from '@progress/kendo-data-query';
import { PageChangeEvent } from '@progress/kendo-angular-treelist';

import {
  filePdfIcon, SVGIcon,
} from "@progress/kendo-svg-icons";


@Component({
  selector: 'app-temporadabase-list',
  templateUrl: './temporadabase-list.component.html',
  styleUrls: ['./temporadabase-list.component.scss']
})
export class TemporadabaseListComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;

  public Form: FormGroup = new FormGroup(
    {
      txtSearch: new FormControl(null),
    }
  );

  public svgpdf: SVGIcon = filePdfIcon;

  listadatos : any;
  loading$! : Observable<boolean | null>;
  loadGrid: boolean = true;
  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';

  public customMsgService: CustomMessagesService;

  public filter: CompositeFilterDescriptor = {
    logic: 'and',
    filters: [
      {
        field: 'temp02nombre',
        operator: 'contains',
        value: '',
      },
    ],
  };

  public skip : number = 0;
  public take : number = 10;
  
  public sort: SortDescriptor[] = [
    {
      field: "temp02nombre",
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
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
    }

  ngOnInit(): void {

    this.Form = new FormGroup({
      txtSearch: new FormControl(null),
    });

    this.loadData();
  }

  public sortChange(sort: SortDescriptor[]): void {
    this.sort = sort;
    this.loadData();

  }

  public SubmitSearch(state: any): void {

    this.filtro = state.txtSearch;
    this.loadData();
    
  }

  public pageChange(state: PageChangeEvent): void {

    this.skip = state.skip; 
    this.loadData();

  }

  public onKeyDown(pressedKey) {
    //console.log('pressedKey',pressedKey);
    if (pressedKey.key==="Enter") {
      
    }
  }

  public loadData(): void {

    this.filter = {
      logic: 'and',
      filters: [
        {
          field: 'temp02nombre',
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

    this.store.dispatch(new fromList.Readtemporadabase(this.requeststate));
    this.loading$ = this.store.pipe(select(fromList.getLoading));

    
    this.data$ =  this.store.pipe(select(fromList.getTemporadaBases));

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });

  }

  OnNuevoTemporadabase(){
    this._Route.navigate(['/dashboard/temporadas/temporadabase/nuevo/']);
  }

  OnEditarTemporadabase(id: number){
    this._Route.navigate(['/dashboard/temporadas/temporadabase/edit/', id.toString()]);
  }

  OnEliminarTemporadabase(id: number, estado : number){
    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta Temporada base?"))
      {
        this.store.dispatch(new fromList.Deletetemporadabase(id.toString()));
      }
    } else {
      this.store.dispatch(new fromList.Deletetemporadabase(id.toString()));
    }
  }

  OndisableTemporadabase():void {

    
    this.filter = {
      logic: 'and',
      filters: [
        {
          field: 'temp02nombre',
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
    

    const requestgrid: Response[] =  this.mySelection.map((item) => {
      const data:Response = {
        temp02llave: Number(item),
        temp02activo: 1,
        temp02nombre:'',
        temp02descripcion:'',
        temp02predeterminada:0
      };
      return data;
    });

    const request : TemporadabasedesactivateResponse = {
      ids : requestgrid,
      filtro : this.requeststate ,
      
    }

    if(request){
      this.store.dispatch(new fromList.Desactivatetemporadabase(request!));
      this.mySelection = [];
    }

  }

  onactivateTemporadabase():void {

    this.filter = {
      logic: 'and',
      filters: [
        {
          field: 'temp02nombre',
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

    const requestgrid: Response[] =  this.mySelection.map((item) => {

      const data:Response = {
        temp02llave: Number(item),
        temp02activo: 1,
        temp02nombre:'',
        temp02descripcion:'',
        temp02predeterminada:0
      };
      return data;
    });

    const request : TemporadabasedesactivateResponse = {
      ids : requestgrid,
      filtro : this.requeststate ,
      
    }

    if(request){
      this.store.dispatch(new fromList.Activatetemporadabase(request!));
      this.mySelection = [];
    }

  }

}
