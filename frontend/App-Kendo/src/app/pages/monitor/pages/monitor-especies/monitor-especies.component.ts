import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../store';
import * as fromMenu from '../../../../store/menu';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from './store/save';
import * as fromListmonitor from '../../store/save';
import { MonitorespecieResponse as Response, MonitorespecieRequest as Request } from './store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';
import { CompositeFilterDescriptor } from '@progress/kendo-data-query';

import { State as RequestState } from "@progress/kendo-data-query";
import { GridDataResult } from '@progress/kendo-angular-grid';


@Component({
  selector: 'app-monitor-especies',
  templateUrl: './monitor-especies.component.html',
  styleUrls: ['./monitor-especies.component.scss']
})
export class MonitorEspeciesComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  listadatos : any;
  loading$! : Observable<boolean | null>;
  temporadaactivalist: any;
  tipoespecielist: any;
  especielist: any;
  danioespecielist: any;

  public verNuevo: boolean = false;
  public ID: string | null;
  public personaID: string | null;
  private _fillcomboservices;

  public Formasignarespecie: FormGroup = new FormGroup({
    cbxtemporadaactiva: new FormControl( null , [Validators.required]),
    cbxtipoespecie: new FormControl( null , [Validators.required] ),
    cbxespecie: new FormControl( null , [Validators.required] ),
    cbxdanioespecie: new FormControl( null , [Validators.required] )
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
    tablename : 'Tipo_Especie_por_temporada_asignar_especie',
    prm1 : '',
    prm2 : ''
  }
  setEspecieXtipoespecie: SetSelect = {
    tablename : 'especie_por_temporada_asignar_especie',
    prm1 : '',
    prm2 : ''
  }

  setDanioxEspecie: SetSelect = {
    tablename : 'tipo_danio_asignar_especie',
    prm1 : '',
    prm2 : ''
  }

  public customMsgService: CustomMessagesService;

  public filter: CompositeFilterDescriptor = {
    logic: 'and',
    filters: [
      {
        field: 'per01llave',
        operator: 'contains',
        value: '',
      },
    ],
  };

  public requeststate: RequestState = {
    skip: 0,
    take: 0,
    filter: this.filter,
    sort: []
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

    this._fillcomboservices.GetAllSelect(this.setTemporada).subscribe(
      allrecords => {
        this.temporadaactivalist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }


  ngOnInit(): void {

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

    this.filter = {
      logic: 'and',
      filters: [
        {
          field: 'mnt01llave',
          operator: "contains",
          value: this.ID
        },
      ],
    };

    this.requeststate = {
      filter: this.filter,
    }


    //console.log('this.requeststate',this.requeststate);

    this.store.dispatch(new fromList.ReadMonitorespecie(this.requeststate));

    this.loading$ = this.store.pipe(select(fromList.getLoadingMonitorEspecie));

    this.data$ =  this.store.pipe(select(fromList.getMonitorespecies));

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });
    
  }

  handleTemporadaChange(value) {

    
    if (value === undefined) {

      this.Formasignarespecie.patchValue({ 'cbxtemporadaactiva': null});
      this.temporadaactivalist = [];

    } else {

      this.onLoadcbxTipoEspecie(value.value);

    }
  }

  onLoadcbxTipoEspecie(id: number):void {


    this.setTipoespecie.prm1 = String(id);
    this.setTipoespecie.prm2 = String(this.ID);

    this._fillcomboservices.GetAllSelect(this.setTipoespecie).subscribe(
      allrecords => {
        this.tipoespecielist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }


  handleTipoespecieChange(value) {

    
    if (value === undefined) {

      this.Formasignarespecie.patchValue({ 'cbxtipoespecie': null});
      this.tipoespecielist = [];

    } else {

      this.onLoadcbxEspecie(value.value);

    }
  }

  onLoadcbxEspecie(id: number):void {


    const { cbxtemporadaactiva } = this.Formasignarespecie.value;

    this.setEspecieXtipoespecie.prm2 = String(cbxtemporadaactiva.value);
    this.setEspecieXtipoespecie.prm1 = String(id);

    //console.log(this.setEspecieXtipoespecie);

    this._fillcomboservices.GetAllSelect(this.setEspecieXtipoespecie).subscribe(
      allrecords => {
        this.especielist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }

  handleEspecieChange(value) {

    if (value === undefined) {

      this.Formasignarespecie.patchValue({ 'cbxdanioespecie': null});
      this.danioespecielist = [];

    } else {

      var valor = value;
      //console.log('valor', valor);

      this.onLoadcbxDanioespecie(value.value);

    }
  }

  onLoadcbxDanioespecie(id: number):void {

    

    this.setDanioxEspecie.prm1 = String(id);
    const { cbxtemporadaactiva } = this.Formasignarespecie.value;

    this.setDanioxEspecie.prm2 = String(cbxtemporadaactiva.value);

    this._fillcomboservices.GetAllSelect(this.setDanioxEspecie).subscribe(
      allrecords => {
        this.danioespecielist = allrecords
      },
      error => this.errorMessage = <any>error
    );
    //console.log(this.errorMessage);
  }

  
  OnNuevo(){

    this.verNuevo = true;

  }

  onContinuar(){
    if(this.ID) {
      this._Route.navigate(['/dashboard/monitor/trampasasignadas', this.ID]);
    }

  }

  OnCancelarcomunicacion(){

    this.verNuevo = false;
    
  }

  onguardarcomunicacion(){

  
    this.Formasignarespecie.markAllAsTouched();

    if(this.Formasignarespecie.valid){

      if(this.ID){

        if(this.personaID)
        {
          const { cbxdanioespecie } = this.Formasignarespecie.value;
 
          this.loading$ = this.store.pipe(select(fromList.getLoadingMonitorEspecie));
 
           const UpdateRequest : Request = {
             mnt01llave : Number(this.ID),
             esp02llave: Number(cbxdanioespecie.value)
           }
 
           //console.log('UpdateRequest', UpdateRequest);
 
           this.store.dispatch(new fromList.CreateMonitorespecie(UpdateRequest));
 
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
    
  }

  OnEliminarespecie(mon01llave: number, esp02llave: number){

    
    if(this.ID){

      this.loading$ = this.store.pipe(select(fromList.getLoadingMonitorEspecie));

      const UpdateRequest : Request = {
        mnt01llave : Number(this.ID),
        esp02llave: Number(esp02llave)
      }

       this.store.dispatch(new fromList.DeleteMonitorespecie(UpdateRequest));

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

    /*
    this.verNuevo  = false;  

    this.Formasignarespecie = new FormGroup({
      cbxtipocomunicacion: new FormControl( null , [Validators.required]),
      cbxregion: new FormControl( null ),
      cbxcomuna: new FormControl( null ),
      txtdireccion: new FormControl('' ),
      txtcasilla: new FormControl( '' ),
      txtcodigopostal: new FormControl('' ),
      txtemail: new FormControl( '' ),
      txttelefono1: new FormControl( '' ),
      txttelefono2: new FormControl( '' ),
      txtcelular1: new FormControl( '' ),
      txtcelular2: new FormControl( '' ),
      txtfax: new FormControl( '' ),
      txtsitioweb: new FormControl( '' )
    });
*/
  }

  OnFinalizarDatosGenerales() 
  {
    this.store.dispatch(new fromMenu.MenuExpanded(true));
    this._Route.navigate(['/dashboard/monitor/list']);

  }
  
}