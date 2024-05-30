import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromList from './store/save';
import * as fromMenu from '../../../../store/menu';

import * as fromListmonitor from '../../store/save';
import { ClienteestacioncomunicacionResponse as Response, ClienteestacioncomunicacionRequest as Request, ClienteestacioncomunicacionbyidRequest as requestsearch } from './store/save';
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
  selector: 'app-clienteestacion-comunicacion',
  templateUrl: './clienteestacion-comunicacion.component.html',
  styleUrls: ['./clienteestacion-comunicacion.component.scss']
})
export class ClienteestacionComunicacionComponent implements OnInit {

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
  public comunicacionID: string | null;
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
    tablename : 'Tipo_Comunicacion_cliente_cargadas',
    prm1 : '',
    prm2 : '1',
  }

  setTipoComunicacioneditar: SetSelect = {
    tablename : 'Tipo_Comunicacion_cliente',
    prm1 : '1'
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
        field: 'cnt01llave',
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
    this.setTipoComunicacion.prm2 = '1';

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
          field: 'cnt01llave',
          operator: "contains",
          value: this.ID
        },
      ],
    };

    this.requeststate = {
      filter: this.filter,
    }

    this.store.dispatch(new fromList.ReadClienteestacioncomunicacion(this.requeststate));

    this.loading$ = this.store.pipe(select(fromList.getLoadingComunicacion));

    this.data$ =  this.store.pipe(select(fromList.getClienteestacioncomunicaciones));

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

  onLoadcbxtipocomunicacionupdate():void {

    this.setTipoComunicacion.prm1 = '1';
    this._fillcomboservices.GetAllSelect(this.setTipoComunicacioneditar).subscribe(
      allrecords => {
        this.Tipocomunicacionlist = allrecords
      },
      error => this.errorMessage = <any>error
    );
  }


  OnNuevo(){

    this.verNuevo = true;
    this.comunicacionID = '0';

  }

  onContinuar(){
    if(this.ID) {
      this._Route.navigate(['/dashboard/clienteestacion/datoscontacto', this.ID]);
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

          this.loading$ = this.store.pipe(select(fromList.getLoadingComunicacion));
 
          const UpdateRequest : Request = {
             cnt06llave: Number(this.comunicacionID),
             cnt01llave : Number(this.ID),
             cnt10llave : cbxtipocomunicacion.value,
             cnt06direccion : String(txtdireccion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
             sist03llave : cbxcomuna ? cbxcomuna.value : null,
             sist04llave : cbxregion ? cbxregion.value : null,
             cnt06casilla : txtcasilla,
             cnt06tienecasilla : 0,
             cnt06codigopostal : txtcodigopostal,
             cnt06tipomail: 0,
             cnt06email :  String(txtemail).toLowerCase(),
             cnt06telefono1 : txttelefono1,
             cnt06telefono2 : txttelefono2,
             cnt06celular1 : txtcelular1,
             cnt06celular2 : txtcelular2,
             cnt06fax : '',
             cnt06sitioweb : String(txtsitioweb).toLowerCase(),
 
           }
 
           //console.log('UpdateRequest', UpdateRequest);
 
           this.store.dispatch(new fromList.CreateClienteestacioncomunicacion(UpdateRequest));
 
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

  OnEditarcomunicacion(id_cliente: number, id_comunicacion: number){
    
    if(this.ID){

      this.loading$ = this.store.pipe(select(fromList.getLoadingComunicacion));

        const findRequest : requestsearch = {
          cnt01llave: Number(this.ID),
          cnt06llave : Number(id_comunicacion)
        }

        //console.log('editar buscar datos por los ides', findRequest)

        this.store.dispatch(new fromList.GetClienteestacionCommunicacionbyid(findRequest));

        this.store.pipe(select(fromList.getClienteestacioncomunicacionbyidselector))
        .subscribe(data => {
          if(data){
            
            this.comunicacionID = data.cnt06llave.toString();
            this.onLoadcbx();

            this.onLoadcbxcomunna(data.sist04llave);
            this.onLoadcbxtipocomunicacionupdate();

            this.Formcomunicacion = new FormGroup({

              cbxtipocomunicacion: new FormControl( {value: String(data.cnt10llave), description: String(data.cnt10nombre)} , [Validators.required]),
              cbxregion: new FormControl( {value: String(data.sist04llave), description: String(data.sist04nombre)} ),
              cbxcomuna: new FormControl( {value: String(data.sist03llave), description: String(data.sist03nombre)} ),
              txtdireccion: new FormControl( data.cnt06direccion ),
              txtcasilla: new FormControl( data.cnt06casilla ),
              txtcodigopostal: new FormControl( data.cnt06codigopostal ),
              txtemail: new FormControl( data.cnt06email ),
              txttelefono1: new FormControl( data.cnt06telefono1 ),
              txttelefono2: new FormControl( data.cnt06telefono2 ),
              txtcelular1: new FormControl( data.cnt06celular1 ),
              txtcelular2: new FormControl( data.cnt06celular2 ),
              txtfax: new FormControl( data.cnt06fax ),
              txtsitioweb: new FormControl( data.cnt06sitioweb ) 
            });
          
            this.verNuevo = true;
          } 
        });
    }
  
  }
  
  OnEliminarcomunicacion(id_cliente: number, id_comunicacion: number){
    if(this.ID){

      this.loading$ = this.store.pipe(select(fromList.getLoadingComunicacion));

        const DeleteRequest : requestsearch = {
          cnt01llave: Number(this.ID),
          cnt06llave : Number(id_comunicacion)
        }

        this.store.dispatch(new fromList.DeleteClienteestacioncomunicacion(DeleteRequest));

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

  }

  OnFinalizarDatosGenerales() 
  {
    this.store.dispatch(new fromMenu.MenuExpanded(true));
    this._Route.navigate(['/dashboard/clienteestacion/list']);

  }

}
