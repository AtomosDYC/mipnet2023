import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from './store/save';
import { PersonacomunicacionResponse as Response, PersonacomunicacionRequest as Request, PersonacomunicacionbyidRequest as requestsearch } from './store/save';
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
  selector: 'app-personas-datoscomunicacion',
  templateUrl: './personas-datoscomunicacion.component.html',
  styleUrls: ['./personas-datoscomunicacion.component.scss']
})
export class PersonasDatoscomunicacionComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  listadatos : any;
  loading$! : Observable<boolean | null>;
  Tipocomunicacionlist: any;
  Regionlist: any;
  Comunalist: any;

  public verNuevo: boolean = false;
  public ID: string | null;
  private _fillcomboservices;

  public Formcomunicacion: FormGroup = new FormGroup({
    cbxtipocomunicacion: new FormControl( null , [Validators.required]),
    cbxregion: new FormControl( null ),
    cbxcomuna: new FormControl( null ),
    txtdireccion: new FormControl( '' ),
    txtcasilla: new FormControl( '' ),
    txtcodigopostal: new FormControl( '' ),
    txtemail: new FormControl( '' ),
    txttelefono1: new FormControl( '' ),
    txttelefono2: new FormControl( '' ),
    txtcelular1: new FormControl( '' ),
    txtcelular2: new FormControl( '' ),
    txtfax: new FormControl( '' ),
    txtsitioweb: new FormControl( '' )
  });

  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';
  errorMessage: any;
  loadGrid: boolean = true;


  setTipoComunicacion: SetSelect = {
    tablename : 'Tipo_Comunicacion_x_persona',
    prm1 : ''
  }
  setRegion: SetSelect = {
    tablename : 'region',
    prm1 : ''
  }
  setComuna: SetSelect = {
    tablename : 'comuna',
    prm1 : ''
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

    this.setTipoComunicacion.prm1 = String(this.ID);

    this._fillcomboservices.GetAllSelect(this.setTipoComunicacion).subscribe(
      allrecords => {
        this.Tipocomunicacionlist = allrecords
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setRegion).subscribe(
      allrecords => {
        this.Regionlist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }


  ngOnInit(): void {

    

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

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
          field: 'per01llave',
          operator: "contains",
          value: this.ID
        },
      ],
    };

    this.requeststate = {
      filter: this.filter,
    }

    this.store.dispatch(new fromList.ReadPersonacomunicacion(this.requeststate));

    this.loading$ = this.store.pipe(select(fromList.getLoadingComunicacion));

    this.data$ =  this.store.pipe(select(fromList.getPersonacomunicaciones));

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });
    
  }

  handleRegionChange(value) {

    if (value === undefined) {

      this.Formcomunicacion.patchValue({ 'cbxcomuna': null});
      this.Comunalist = [];
    
    } else {
    
      this.onLoadcbxcomunna(value.value);
      
    }

  }

  onLoadcbxcomunna(id: number):void {

    this.setComuna.prm1 = String(id);

      this._fillcomboservices.GetAllSelect(this.setComuna).subscribe(
        allrecords => {
          this.Comunalist = allrecords
        },
        error => this.errorMessage = <any>error
      );

  }


  OnNuevo(){

    this.verNuevo = true;

  }

  onContinuar(){
    if(this.ID) {
      this._Route.navigate(['/dashboard/personas/datosacceso', this.ID]);
    }

  }

  OnCancelarcomunicacion(){

    this.verNuevo = false;
    
  }

  onguardarcomunicacion(){

  
    this.Formcomunicacion.markAllAsTouched();

    if(this.Formcomunicacion.valid){

      if(this.ID){

        const { cbxtipocomunicacion, cbxregion, cbxcomuna, txtdireccion, txtcasilla, txtcodigopostal, txtemail, txttelefono1,
           txttelefono2, txtcelular1, txtcelular2, txtfax, txtsitioweb } = this.Formcomunicacion.value;

        const region = cbxregion
        //console.log('region', region);

        this.loading$ = this.store.pipe(select(fromList.getLoadingComunicacion));

          const UpdateRequest : Request = {

            per01llave : Number(this.ID),
            per04llave : cbxtipocomunicacion.value,
            per03llave : 0,
            per05Direccion : String(txtdireccion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            sist03llave : cbxcomuna ? cbxcomuna.value : null,
            sist04llave : cbxregion ? cbxregion.value : null,
            per0Casilla : txtcasilla,
            per05TieneCasilla : 0,
            per05CodigoPostal : txtcodigopostal,
            per05Email :  String(txtemail).toLowerCase(),
            per05Telefono1 : txttelefono1,
            per05Telefono2 : txttelefono2,
            per05Celular1 : txtcelular1,
            per05Celular2 : txtcelular2,
            per05Fax : '',
            per05SitioWeb : String(txtsitioweb).toLowerCase(),

          }

          //console.log('UpdateRequest', UpdateRequest);

          this.store.dispatch(new fromList.CreatePersonacomunicacion(UpdateRequest));

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
  
  OnEliminarUnirEspecie(id_doc: number, id_tip: number){
    
    if(this.ID){

      this.loading$ = this.store.pipe(select(fromList.getLoadingComunicacion));

        const DeleteRequest : requestsearch = {

          per01llave : Number(this.ID),
          per04llave : id_doc,
          per03llave : id_tip
        }

        //console.log('dellete', DeleteRequest)

        this.store.dispatch(new fromList.DeletePersonacomunicacion(DeleteRequest));

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
    
  }

  OnLimpiarFormulario(){

    this.verNuevo  = false;  

    this.Formcomunicacion = new FormGroup({
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

  }
}
