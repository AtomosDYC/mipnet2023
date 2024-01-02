import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from './store/save';
import * as fromListmonitor from '../../store/save';
import * as fromLoader from '../../../../store/loader';
import * as fromMenu from '../../../../store/menu';

import { MonitortrampaResponse as Response, MonitortrampaRequest as Request } from './store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';
import { CompositeFilterDescriptor, SortDescriptor } from '@progress/kendo-data-query';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult, PageChangeEvent } from '@progress/kendo-angular-grid';
import { DataStateChangeEvent } from '@progress/kendo-angular-treelist';

@Component({
  selector: 'app-monitor-trampas',
  templateUrl: './monitor-trampas.component.html',
  styleUrls: ['./monitor-trampas.component.scss']
})
export class MonitorTrampasComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;
  dataBuscar$! : Observable<GridDataResult | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  listadatos : any;
  loading$! : Observable<boolean | null>;

  temporadaactivalist: any;
  tipoespecielist: any;
  especielist: any;
  regionlist: any;
  comunalist: any;
  estacionlist: any;

  temporadaLoading : boolean = false;
  tipoespecieLoading : boolean = false;
  especieLoading : boolean = false;
  regionLoading : boolean = false;
  comunaLoading : boolean = false;
  estacionLoading : boolean = false;
  
  isDisabledContinuarMonitorTrampa : boolean = false;

  public verNuevo: boolean = false;
  public ID: string | null;
  public personaID: string | null;
  private _fillcomboservices;

  public Formbuscador: FormGroup = new FormGroup({
    cbxtemporadaactiva: new FormControl( null, [Validators.required]),
    cbxtipoespecie: new FormControl( null ),
    cbxespecie: new FormControl( null ),
    cbxregion: new FormControl( null ),
    cbxcomuna: new FormControl( null ),
    cbxestacion: new FormControl( null ),
    chxdisponibles: new FormControl(),
  });

  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';
  errorMessage: any;
  loadGrid: boolean = true;

  

  setTemporada: SetSelect = {
    tablename : 'Temporada_Base_asignar_especie',
  }

  setTipoespecie: SetSelect = {
    tablename : 'TipoEspecie_asignadas_asignar_trampas',
    prm1 : '',
    prm2 : '',
  }

  setEspecie: SetSelect = {
    tablename : 'EspecieBase_asignadas_asignar_trampas',
    prm1 : '',
    prm2 : '',
    prm3 : ''
  }

  setRegion: SetSelect = {
    tablename : 'Region_asignar_trampa',
    prm1 : '',
    prm2 : '',
    prm3 : '',
    prm4 : ''
  }

  setComuna: SetSelect = {
    tablename : 'comuna_asignar_trampa',
    prm1 : '',
    prm2 : '',
    prm3 : '',
    prm4 : '',
    prm5 : ''
  }

  setEstacion: SetSelect = {
    tablename : 'estacion_asignar_trampa',
    prm1 : '',
    prm2 : '',
    prm3 : '',
    prm4 : '',
    prm5 : '',
    prm6 : ''
  }

  public customMsgService: CustomMessagesService;

  public filter: CompositeFilterDescriptor = {

    logic: 'and',
    filters: [
      {
        field: 'MNT01_Llave',
        operator: 'eq',
        value: '',  
      },
      {
        field: 'TEMP02_Llave',
        operator: 'eq',
        value: '',  
      },
    ],
  };

  public filterBuscar: CompositeFilterDescriptor = {
    logic: 'and',
    filters: [
      {
        field: 'MNT01_Llave',
        operator: 'eq',
        value: '',  
      }
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

  public skipBuscar : number = 0;
  public takeBuscar : number = 10;
  
  public sortBuscar: SortDescriptor[] = [
    {
      field: "per01nombrerazon",
      dir: "asc",
    },
  ];

  public requestBuscarstate: RequestState = {
    skip: this.skipBuscar,
    take: this.takeBuscar,
    filter: this.filterBuscar,
    sort: this.sortBuscar
  };

  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService,
    FillComboService: FillComboService,
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
      this._fillcomboservices = FillComboService;
    }

  onLoadcbx():void {

    this.Formbuscador.patchValue({ 'cbxtipoespecie': null});
    this.Formbuscador.patchValue({ 'cbxespecie': null});
    this.Formbuscador.patchValue({ 'cbxregion': null});
    this.Formbuscador.patchValue({ 'cbxcomuna': null});
    this.Formbuscador.patchValue({ 'cbxestacion': null});

    this.Formbuscador.get('cbxtipoespecie')?.disable();
    this.Formbuscador.get('cbxespecie')?.disable();
    this.Formbuscador.get('cbxregion')?.disable();
    this.Formbuscador.get('cbxcomuna')?.disable();
    this.Formbuscador.get('cbxestacion')?.disable();

    this._fillcomboservices.GetAllSelect(this.setTemporada).subscribe(
      allrecords => {
        this.temporadaactivalist = allrecords
      },
      error => this.errorMessage = <any>error
    );
  }


  ngOnInit(): void {

    this.store.dispatch(new fromLoader.onsuccess());

    this.store.dispatch(new fromLoader.cambiarestado());

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromListmonitor.GetMonitorbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromListmonitor.getLoading))!;

        this.store.pipe(select(fromListmonitor.getMonitorbyid))
          .subscribe(data => {
            if(data)
            {
              this.personaID = data.per01llave.toString();
              //console.log(this.personaID);
            }
          });

        this.OnloadGrid();

        this.onLoadcbx();
        
      }
    });

    

  }

  public OnloadGrid(): void{

    this.loadGrid = true;

    this.filter = {
      logic: 'and',
      filters: [
        {
          field: 'MNT01_Llave',
          operator: 'eq',
          value: this.ID,  
        }
      ],
    };

    this.requeststate = {
      skip: this.skip,
      take: this.take,
      filter: this.filter,
      sort: this.sort
    }

    this.store.dispatch(new fromList.ReadMonitortrampa(this.requeststate));

    this.loading$ = this.store.pipe(select(fromList.getLoadingMonitorTrampa));

    this.data$ =  this.store.pipe(select(fromList.getMonitortrampas));

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });
    
  }

  public pageChange(state: PageChangeEvent): void {

    this.skip = state.skip; 
    this.OnloadGrid();
    
  }

  public sortChange(sort: SortDescriptor[]): void {
    this.sort = sort;
    this.onBuscartrampas();
  }


  public dataStateChange(state: DataStateChangeEvent): void {
    this.requestBuscarstate = state;
    this.query(state);
  }

 
  handleTemporadaChange(value) 
  {
    
    this.Formbuscador.patchValue({ 'cbxtipoespecie': null});
    this.Formbuscador.patchValue({ 'cbxespecie': null});
    this.Formbuscador.patchValue({ 'cbxregion': null});
    this.Formbuscador.patchValue({ 'cbxcomuna': null});
    this.Formbuscador.patchValue({ 'cbxestacion': null});

    this.Formbuscador.get('cbxtipoespecie')?.disable();
    this.Formbuscador.get('cbxespecie')?.disable();
    this.Formbuscador.get('cbxregion')?.disable();
    this.Formbuscador.get('cbxcomuna')?.disable();
    this.Formbuscador.get('cbxestacion')?.disable();


    if (value === undefined) 
    {
      this.Formbuscador.patchValue({ 'cbxtemporadaactiva': null});

    } else {
     
      this.onLoadcbxTipoEspecie(value.value);
    }
    
  }

  onLoadcbxTipoEspecie(id: number):void {

    this.tipoespecieLoading = true;

    this.setTipoespecie.prm1 = String(this.ID);
    this.setTipoespecie.prm2 = String(id);

    var data = this._fillcomboservices.GetAllSelect(this.setTipoespecie);
    //console.log('data',data);
    data.subscribe(
      allrecords => {

        this.tipoespecielist = allrecords
        this.Formbuscador.get('cbxtipoespecie')?.enable();
        this.tipoespecieLoading = false;
      },
      error => { 
        this.errorMessage = <any>error;
        this.tipoespecieLoading = false;
      }
    );


  }
  
  handleTipoespecieChange(value) {


    this.Formbuscador.patchValue({ 'cbxespecie': null});
    this.Formbuscador.patchValue({ 'cbxregion': null});
    this.Formbuscador.patchValue({ 'cbxcomuna': null});
    this.Formbuscador.patchValue({ 'cbxestacion': null});

    this.Formbuscador.get('cbxespecie')?.disable();
    this.Formbuscador.get('cbxregion')?.disable();
    this.Formbuscador.get('cbxcomuna')?.disable();
    this.Formbuscador.get('cbxestacion')?.disable();
    
    if (value === undefined) {

      this.Formbuscador.patchValue({ 'cbxtipoespecie': null});
      this.tipoespecielist = [];

    } else {

      this.onLoadcbxEspecie(value.value);

    }

  }

  onLoadcbxEspecie(id: number):void {

    this.especieLoading = true;

    const { cbxtemporadaactiva } = this.Formbuscador.value;

    this.setEspecie.prm1 = String(this.ID);
    this.setEspecie.prm2 = String(cbxtemporadaactiva.value);
    this.setEspecie.prm3 = String(id);
    

    this._fillcomboservices.GetAllSelect(this.setEspecie).subscribe(
      allrecords => {
        this.especielist = allrecords
        this.Formbuscador.get('cbxespecie')?.enable();
        this.especieLoading = false;
      },
      error => { 
        this.errorMessage = <any>error;
        this.especieLoading = false;
      }
    );

  }

  handleEspecieChange(value) {

    this.Formbuscador.patchValue({ 'cbxregion': null});
    this.Formbuscador.patchValue({ 'cbxcomuna': null});
    this.Formbuscador.patchValue({ 'cbxestacion': null});

    this.Formbuscador.get('cbxregion')?.disable();
    this.Formbuscador.get('cbxcomuna')?.disable();
    this.Formbuscador.get('cbxestacion')?.disable();

    if (value === undefined) {

      this.Formbuscador.patchValue({ 'cbxregion': null});
      this.regionlist = [];

    } else {

      this.onLoadcbxRegion(value.value);

    }
  }

  onLoadcbxRegion(id: number):void 
  {

    this.regionLoading = true;

    const { cbxtemporadaactiva, cbxtipoespecie } = this.Formbuscador.value;

    this.setRegion.prm1 = String(this.ID);
    this.setRegion.prm2 = String(cbxtemporadaactiva.value);
    this.setRegion.prm3 = String(cbxtipoespecie.value);
    this.setRegion.prm4 = String(id);
    

    this._fillcomboservices.GetAllSelect(this.setRegion).subscribe(
      allrecords => {
        this.regionlist = allrecords
        this.Formbuscador.get('cbxregion')?.enable();

        this.regionLoading = false;

      },
      error => {

        this.errorMessage = <any>error;
        this.regionLoading = false;

      }
    );

  }

  handleRegionChange(value) {

    this.Formbuscador.patchValue({ 'cbxcomuna': null});
    this.Formbuscador.patchValue({ 'cbxestacion': null});

    this.Formbuscador.get('cbxcomuna')?.disable();
    this.Formbuscador.get('cbxestacion')?.disable();

    if (value === undefined) {

      this.Formbuscador.patchValue({ 'cbxcomuna': null});
      this.comunalist = [];

    } else {

      this.onLoadcbxComuna(value.value);

    }
  }

  onLoadcbxComuna(id: number):void 
  {

    this.comunaLoading = true;

    const { cbxtemporadaactiva, cbxtipoespecie, cbxespecie } = this.Formbuscador.value;


    this.setComuna.prm1 = String(this.ID);
    this.setComuna.prm2 = String(cbxtemporadaactiva.value);
    this.setComuna.prm3 = String(cbxtipoespecie.value);
    this.setComuna.prm4 = String(cbxespecie.value);
    this.setComuna.prm5 = String(id);
    

    this._fillcomboservices.GetAllSelect(this.setComuna).subscribe(
      allrecords => {
        this.comunalist = allrecords
        this.Formbuscador.get('cbxcomuna')?.enable();
        this.comunaLoading = false;
      },
      error => { 
        this.errorMessage = <any>error;
        this.comunaLoading = false;
      }
    );

  }

  handleComunaChange(value) {

    this.Formbuscador.patchValue({ 'cbxestacion': null});

    this.Formbuscador.get('cbxestacion')?.disable();

    if (value === undefined) {

      this.Formbuscador.patchValue({ 'cbxestacion': null});
      this.estacionlist = [];

    } else {

      this.onLoadcbxEstacion(value.value);

    }
  }

  onLoadcbxEstacion(id: number):void 
  {
   
    this.estacionLoading = true;

    const { cbxtemporadaactiva, cbxtipoespecie, cbxespecie, cbxregion } = this.Formbuscador.value;

    this.setEstacion.prm1 = String(this.ID);
    this.setEstacion.prm2 = String(cbxtemporadaactiva.value);
    this.setEstacion.prm3 = String(cbxtipoespecie.value);
    this.setEstacion.prm4 = String(cbxespecie.value);
    this.setEstacion.prm5 = String(cbxregion.value);
    this.setEstacion.prm6 = String(id);

    this._fillcomboservices.GetAllSelect(this.setEstacion).subscribe(
      allrecords => {
        this.estacionlist = allrecords
        this.Formbuscador.get('cbxestacion')?.enable();
        this.estacionLoading = false;
      },
      error => {
        this.errorMessage = <any>error;
        this.estacionLoading = false;
      }
    );
  }
  
  onBuscartrampas(){

    this.Formbuscador.markAllAsTouched();

    if(this.Formbuscador.valid){

      if(this.ID){

        this.loadGrid = true;

        const { cbxtemporadaactiva, cbxtipoespecie, cbxespecie, cbxregion, cbxcomuna, cbxestacion, chxdisponibles } = this.Formbuscador.value;

        const disponible = chxdisponibles ? 1 : 0
        const tipoespecie =  cbxtipoespecie ? cbxtipoespecie.value : null;
        const especie =  cbxespecie ? cbxespecie.value : null;
        const region =  cbxregion ? cbxregion.value : null;
        const comuna =  cbxcomuna ? cbxcomuna.value : null;
        const estacion =  cbxestacion ? cbxestacion.value : null;
        
        this.filterBuscar = {
          logic: 'and',
          filters: [
            {
              field: 'MNT01_Llave',
              operator: "==",
              value: this.ID,
            },
            {
              field: 'TEMP02_Llave',
              operator: "==",
              value: cbxtemporadaactiva.value,
            },
            {
              field: 'SIST04_Llave',
              operator: "==",
              value: region ?? null ,
            },
            {
              field: 'SIST03_Llave',
              operator: "==",
              value: comuna,
            },
            {
              field: 'CNT08_Llave',
              operator: "==",
              value: estacion,
            },
            {
              field: 'ESP03_Llave',
              operator: "==",
              value: especie,
            },
            {
              field: 'ESP08_Llave',
              operator: "==",
              value: tipoespecie,
            },
            {
              field: 'MNT03_disponible',
              operator: "==",
              value: disponible,
            }

          ],
        };

        this.requestBuscarstate = {
          skip: this.skipBuscar,
          take: this.takeBuscar,
          filter: this.filterBuscar,
          sort: this.sortBuscar
        }
       
        this.store.dispatch(new fromList.GetMonitorbuscartrampa(this.requestBuscarstate));

        this.loading$ = this.store.pipe(select(fromList.getLoadingMonitorTrampa));

        this.dataBuscar$ =  this.store.pipe(select(fromList.getMonitorbuscartrampas));

        this.loading$.subscribe((load) => { 
          this.loadGrid = load!;
        });
      }
    }

  }

  onAsignarTrampas(){

    if(this.Formbuscador.valid)
    {
      if(this.ID)
      {
 
          const { cbxtemporadaactiva } = this.Formbuscador.value;

          const request: Request[] =  this.mySelection.map((item) => {

            const data:Request = {
              mnt01llave: Number(this.ID),
              trp01llave: Number(item),
              temp02llave: cbxtemporadaactiva.value
            };
            return data;
          });

          if(request){
            this.store.dispatch(new fromList.AsignarMonitortrampa(request!));

            this.success$ = this.store.pipe(select(fromList.getSuccess));
 
            this.success$.subscribe((success) => { 
              if(success) {
 
                this.verNuevo = false;
                this.onBuscartrampas();
                this.OnloadGrid();
               
             }
           })
            
          }

      }
    }
  }

  public sortBuscarChange(sort: SortDescriptor[]): void {
    this.sortBuscar = sort;
    this.onBuscartrampas();
  }

  public pageBuscarChange(state: PageChangeEvent): void {

    this.skipBuscar = state.skip; 
    this.onBuscartrampas();
    
  }

  //actualizar paginacion de la grid del buscador
  public dataStateBuscarChange(state: DataStateChangeEvent): void {
    this.requestBuscarstate = state;
    this.query(state);
}

  public query(state: any): void {
    //this.fetch(this.tableName, state)
    //    .subscribe(x => super.next(x));
  }

  OnNuevo(){

    this.verNuevo = true;

  }

  onContinuarMonitorTrampa(){
    if(this.ID) {
      this._Route.navigate(['/dashboard/monitor/datoscelulares', this.ID]);
    }

  }

  OnCancelarcomunicacion(){

    this.verNuevo = false;
    
  }

  onguardarcomunicacion(){

    /*
  
    this.Formasignartrampa.markAllAsTouched();

    if(this.Formasignartrampa.valid){

      if(this.ID){

        if(this.personaID)
        {
          const { cbxdaniotrampa } = this.Formasignartrampa.value;
 
         this.loading$ = this.store.pipe(select(fromList.getLoadingMonitorEspecie));
 
           const UpdateRequest : Request = {
             mnt01llave : Number(this.ID),
             esp02llave: Number(cbxdaniotrampa.value)
           }
 
           //console.log('UpdateRequest', UpdateRequest);
 
           this.store.dispatch(new fromList.CreateMonitortrampa(UpdateRequest));
 
           this.success$ = this.store.pipe(select(fromList.getSuccess));
 
           this.success$.subscribe((success) => { 
             if(success) {
 
               this.verNuevo = false;
               this.OnLimpiarFormulario();
               this.onLoadcbx();
               this.OnloadGrid();
               
             }
           })
        }

        

      }
    }
    */
    
  }

  OnEliminartrampa(mon01llave: number, esp02llave: number){

    /*
    
    if(this.ID){

      this.loading$ = this.store.pipe(select(fromList.getLoadingMonitorTrampa));

      const UpdateRequest : Request = {
        mnt01llave : Number(this.ID),
        esp02llave: Number(esp02llave)
      }

       this.store.dispatch(new fromList.DeleteMonitortrampa(UpdateRequest));

       this.success$ = this.store.pipe(select(fromList.getSuccess));
 
       this.success$.subscribe((success) => { 
         if(success) {

           this.verNuevo = false;
           this.OnLimpiarFormulario();
           this.onLoadcbx();
           this.OnloadGrid();
           
         }
       })
    }
    */
  }
  
  OnEliminarcomunicacion(mon01llave: number, esp02llave: number){
    
    /*
    if(this.ID){

      this.loading$ = this.store.pipe(select(fromList.getLoadingComunicacion));

        const DeleteRequest : requestsearch = {
          mnt01llave: Number(this.ID),
          per01llave : id_per,
          per04llave : id_tipcom,
          per03llave : id_tipper,
        }

        //console.log('dellete', DeleteRequest)

        this.store.dispatch(new fromList.DeleteMonitorcomunicacion(DeleteRequest));

        this.success$ = this.store.pipe(select(fromList.getSuccess));

        this.success$.subscribe((success) => { 
          if(success) {

            //console.log('success');

            this.OnLimpiarFormulario();
            this.onLoadcbx();
            this.OnloadGrid();

          }
        })

    }
    */
  }

  OnLimpiarFormulario(){

    
    this.verNuevo  = false;
    
    this.mySelection = [];

    this.Formbuscador = new FormGroup({
      cbxtemporadaactiva: new FormControl( null, [Validators.required]),
      cbxtipoespecie: new FormControl( null ),
      cbxespecie: new FormControl( null ),
      cbxregion: new FormControl( null ),
      cbxcomuna: new FormControl( null ),
      cbxestacion: new FormControl( null ),
      chxdisponibles: new FormControl(),
    });

  }


  onReplicarTrampa(){
  
    if(this.ID)
    {
      this.store.dispatch(new fromList.ReplicarTemporadaMonitor(this.ID));

      this.success$ = this.store.pipe(select(fromList.getSuccess));

      this.success$.subscribe((success) => { 
        if(success) {

          this.verNuevo = false;
          this.OnloadGrid();
         
       }
     })
      
    }

  }

  OnFinalizarDatosGenerales() 
  {
    this.store.dispatch(new fromMenu.MenuExpanded(true));
    this._Route.navigate(['/dashboard/monitor/list']);

  }

}