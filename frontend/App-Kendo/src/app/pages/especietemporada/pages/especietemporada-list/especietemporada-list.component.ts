import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromList from '../../store/save';
import { Router } from '@angular/router';

import { GridDataResult, PageChangeEvent } from "@progress/kendo-angular-grid";

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

import { FormControl, FormGroup } from '@angular/forms';
import { CompositeFilterDescriptor, SortDescriptor } from '@progress/kendo-data-query'; 
import { State as RequestState } from "@progress/kendo-data-query";

import { EspecieTemporadaRequestActivate as RequestActive } from '../../store/save';



import {
  filePdfIcon, SVGIcon,
} from "@progress/kendo-svg-icons";

@Component({
  selector: 'app-especietemporada-list',
  templateUrl: './especietemporada-list.component.html',
  styleUrls: ['./especietemporada-list.component.scss']
})
export class EspecietemporadaListComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  success$ !: Observable<boolean | null>;

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
        field: 'esp03nombre',
        operator: 'contains',
        value: '',
      },
    ],
  };

  public skip : number = 0;
  public take : number = 10;
  
  public sort: SortDescriptor[] = [
    {
      field: "temp02llave",
      dir: "desc",
    },
    {
      field: "esp03nombre",
      dir: "desc",
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
          field: 'esp03nombre',
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

    this.store.dispatch(new fromList.ReadEspecieTemporada(this.requeststate));

    this.loading$ = this.store.pipe(select(fromList.getLoadingespecietemporada));

    this.data$ =  this.store.pipe(select(fromList.getEspeciesTemporadas));

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
    this._Route.navigate(['/dashboard/especies/especietemporada/nuevo']);
  }

  OnEditar(id: number){
    this._Route.navigate(['/dashboard/especies/especietemporada/nuevo/', id.toString()]);
  }

  OnEliminar(id: number, estado : number){
    
    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta temporada de especie ?"))
      {
        this.store.dispatch(new fromList.DeleteEspecieTemporada(id.toString()));
      }
    } else {
      this.store.dispatch(new fromList.DeleteEspecieTemporada(id.toString()));
    }

    this.success$ = this.store.pipe(select(fromList.getEspeciesTemporadaSuccess));
 
      this.success$.subscribe((success) => { 
        if(success) {

          this.mySelection = [];
          this.OnloadGrid();
          
        }
      })

  }

  OndisableEspecietemporada():void {

    
    var request:RequestActive[] = this.mySelection.map((item) => {
      const data:RequestActive = {
        esp02llave: Number(item),
        esp02activo: 1
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.DesactivateEspecieTemporada(request!));

      this.success$ = this.store.pipe(select(fromList.getEspeciesTemporadaSuccess));
 
      this.success$.subscribe((success) => { 
        if(success) {

          this.mySelection = [];
          this.OnloadGrid();
          
        }
      })

      
    }
    

  }

  onactivateEspecietemporada():void {

    var request:RequestActive[] = this.mySelection.map((item) => {
      const data:RequestActive = {
        esp02llave: Number(item),
        esp02activo: 1
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.ActivateEspecieTemporada(request!));

      this.success$ = this.store.pipe(select(fromList.getEspeciesTemporadaSuccess));
 
      this.success$.subscribe((success) => { 
        if(success) {

          this.mySelection = [];
          this.OnloadGrid();
          
        }
      })

      
    }
  }

}
