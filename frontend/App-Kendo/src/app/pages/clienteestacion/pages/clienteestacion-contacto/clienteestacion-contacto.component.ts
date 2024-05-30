
import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromList from './store/save';
import * as fromMenu from '../../../../store/menu';


import { ClienteestacioncontactoResponse as Response, ClienteestacioncontactoRequest as Request, ClienteestacioncontactobyidRequest as requestsearch } from './store/save';
import { PersonaResponse as personaResponse, PersonaBuscarRutRequest as PersonaRequest } from './store/save';

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

import { RutService } from 'rut-chileno';
import { getLoading } from '../../../administracion/comuna/store/save/save.selectors';


@Component({
  selector: 'app-clienteestacion-contacto',
  templateUrl: './clienteestacion-contacto.component.html',
  styleUrls: ['./clienteestacion-contacto.component.scss']
})
export class ClienteestacionContactoComponent implements OnInit {

  data$! : Observable<GridDataResult | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  listadatos : any;
  loading$! : Observable<boolean | null>;
  tipocontactolist: any;
  tipopersonalist: any;
  titulolist: any;
  tipodocumentolist: any;
  Regionlist: any;
  Comunalist: any;

  VisibleRut: number = 4;
  rutnovalido:boolean =  false;

  public verNuevo: boolean = false;
  public ID: string | null;
  public contactoID: string | null;
  public personaID: string | null;
  private _fillcomboservices;

  public Formcontacto: FormGroup = new FormGroup({
    cbxtipocontacto: new FormControl( null , [Validators.required]),
    cbxtipodocumento: new FormControl (null , Validators.required),
    txtrut: new FormControl( '' ),
    txtdni: new FormControl( '' ),
    txtpasaporte: new FormControl( '' ),
    cbxtipopersona: new FormControl (null , Validators.required),
    cbxtitulo: new FormControl (null , Validators.required),
    txtNombre: new FormControl (null , Validators.required),

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


  setTipocontacto: SetSelect = {
    tablename : 'tipo_contacto_libre_cliente',
    prm1 : '',
    prm2 : '1',
  }

  setTipoContactoeditar: SetSelect = {
    tablename : 'tipo_contacto',
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

  setTipomonitor: SetSelect = {
    tablename : 'tipo_monitor'
  }

  setTipodocumento: SetSelect = {
    tablename : 'tipo_documento_x_personabuscar'
  }
  
  setTipoPersona: SetSelect = {
    tablename : 'Tipo_persona'
  }

  setSaludo: SetSelect = {
    tablename : 'saludos'
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
    private rutService: RutService,
    FillComboService: FillComboService,
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
      this._fillcomboservices = FillComboService;
    }

  onLoadcbx():void {

    this.setTipocontacto.prm1 = String(this.ID);
    this.setTipocontacto.prm2 = '1';

    this._fillcomboservices.GetAllSelect(this.setTipocontacto).subscribe(
      allrecords => {
        this.tipocontactolist = allrecords
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setRegion).subscribe(
      allrecords => {
        this.Regionlist = allrecords
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setTipodocumento).subscribe(
      allrecords => {
        this.tipodocumentolist = allrecords    
      },
      error => this.errorMessage = <any>error
    );
  
    this._fillcomboservices.GetAllSelect(this.setTipoPersona).subscribe(
      allrecords => {
        this.tipopersonalist = allrecords    
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setSaludo).subscribe(
      allrecords => {
        this.titulolist = allrecords    
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

    this.store.dispatch(new fromList.ReadClienteestacioncontacto(this.requeststate));

    this.loading$ = this.store.pipe(select(fromList.getLoadingContacto));

    this.data$ =  this.store.pipe(select(fromList.getClienteestacioncontactoes));

    this.loading$.subscribe((load) => { 
      this.loadGrid = load!;
    });
    
  }

  handleTipodocumentoChange(value) {

    this.VisibleRut = value.value;

  }

  handleRegionChange(value) {

    if (value === undefined) {

      this.Formcontacto.patchValue({ 'cbxcomuna': null});
      this.Comunalist = [];
    
    } else {
    
      this.onLoadcbxcomunna(value.value);
      
    }

  }


  inputBlur(): void {

    const { cbxtipodocumento } = this.Formcontacto.value;

    this.rutnovalido = false;
    const { txtrut } = this.Formcontacto.value;
    let out4_rut = this.rutService.validaRUT(txtrut);
    if(out4_rut){
      this.rutnovalido = true;
      return;
    }

    let rut = this.rutService.getRutChileForm(1, txtrut)
    this.Formcontacto.patchValue({
      txtrut: rut
    });

    let rutiformat: string | undefined ;
    let ruti: string | undefined ;

    if(cbxtipodocumento.value == 1) {
      rutiformat = this.rutService.rutClean(txtrut)!;
      ruti = rutiformat.substring(0, rutiformat.length -1)

      const buscador: PersonaRequest = {
        per01rut: Number(ruti),
        per08llave: 1
      }

      
      this.store.dispatch(new fromList.GetPersonabyrut(buscador));
      this.loading$ = this.store.pipe(select(fromList.getLoadingContacto))!;

      this.store.pipe(select(fromList.getPersonabyrutselector))
        .subscribe(data => {
          if(data){

            this.Formcontacto.patchValue({
              txtNombre: data.per01nombrerazon,
              cbxtipopersona: {value: String(data.per03llave), description: String(data.per03nombre)},
              cbxtitulo: {value: String(data.per02llave), description: String(data.per02nombre)}
              
            });

          }
        })
        
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

  onLoadcbxtipocontactoupdate():void {

    this.setTipocontacto.prm1 = '1';
    this._fillcomboservices.GetAllSelect(this.setTipocontacto).subscribe(
      allrecords => {
        this.tipocontactolist = allrecords
      },
      error => this.errorMessage = <any>error
    );
  }


  OnNuevo(){

    this.verNuevo = true;
    this.contactoID = '0';

  }

  onContinuar(){
    if(this.ID) {
      this._Route.navigate(['/dashboard/clienteestacion/datoscontacto', this.ID]);
    }

  }

  OnCancelarcontacto(){

    this.verNuevo = false;
    
  }

  onguardarcontacto(){

  
    this.Formcontacto.markAllAsTouched();

    if(this.Formcontacto.valid){

      if(this.ID){

        const { cbxtipocontacto,
          cbxtipodocumento,
          txtrut,
          txtdni,
          txtpasaporte,
          cbxtipopersona,
          cbxtitulo,
          txtNombre,
          cbxregion,
          cbxcomuna,
          txtdireccion,
          txtcasilla,
          txtcodigopostal,
          txtemail,
          txttelefono1,
          txttelefono2,
          txtcelular1,
          txtcelular2,
          txtfax,
          txtsitioweb } = this.Formcontacto.value;

          let rutiformat: string | undefined ;
          let ruti: string | undefined ;

          if(cbxtipodocumento.value == 1) {
            rutiformat = this.rutService.rutClean(txtrut)!;
            //console.log(rutiformat)
            ruti = rutiformat.substring(0, rutiformat.length -1)
            //console.log('rut formateado',ruti);

          } else if(cbxtipodocumento.value == 2){
            ruti = txtdni;
          } else if(cbxtipodocumento.value == 3) {
            ruti = txtpasaporte;
          } else {
      
          } 
0
          let comuna = cbxcomuna ? cbxcomuna.value : null;

          this.loading$ = this.store.pipe(select(fromList.getLoadingContacto));
 
          const UpdateRequest : Request = {
             
            cnt01llave : Number(this.ID),
            cnt04llave : Number(this.contactoID),
            cnt05llave : cbxtipocontacto.value,
            per01llave : Number(this.personaID),
            per02llave : cbxtitulo.value,
            per03llave : cbxtipopersona.value,
            per08llave : cbxtipodocumento.value,
            per01rut : Number(ruti),
            per01nombrerazon : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01activo: 1,
            per05direccion : String(txtdireccion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            sist03llave : comuna,
            sist04llave : cbxregion ? cbxregion.value : null,
            per05casilla : txtcasilla,
            per05tienecasilla : 0,
            per05codigopostal : txtcodigopostal,
            per05email :  String(txtemail).toLowerCase(),
            per05telefono1 : txttelefono1,
            per05telefono2 : txttelefono2,
            per05celular1 : txtcelular1,
            per05celular2 : txtcelular2,
            per05fax : '',
            per05sitioWeb: String(txtsitioweb).toLowerCase().replace(/^\w/, (c) => c.toUpperCase())
 
           }
 
           console.log(UpdateRequest,'UpdateRequest');

           this.store.dispatch(new fromList.CreateClienteestacioncontacto(UpdateRequest));
 
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

  OnEditarcontacto(id_cliente: number, id_contacto: number){
    
    if(this.ID){

      this.loading$ = this.store.pipe(select(fromList.getLoadingContacto));

      /*

        const findRequest : requestsearch = {
          cnt01llave: Number(this.ID),
          cnt06llave : Number(id_contacto)
        }

        //console.log('editar buscar datos por los ides', findRequest)

        this.store.dispatch(new fromList.GetClienteestacionCommunicacionbyid(findRequest));

        this.store.pipe(select(fromList.getClienteestacioncontactobyidselector))
        .subscribe(data => {
          if(data){
            
            this.contactoID = data.cnt06llave.toString();
            this.onLoadcbx();

            this.onLoadcbxcomunna(data.sist04llave);
            this.onLoadcbxtipocontactoupdate();

            this.Formcontacto = new FormGroup({

              cbxtipocontacto: new FormControl( {value: String(data.cnt10llave), description: String(data.cnt10nombre)} , [Validators.required]),
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
        */
    }
  
  }
  
  OnEliminarcontacto(id_cliente: number, id_contacto: number){
    if(this.ID){

      this.loading$ = this.store.pipe(select(fromList.getLoadingContacto));

      /*
        const DeleteRequest : requestsearch = {
          cnt01llave: Number(this.ID),
          cnt06llave : Number(id_contacto)
        }

        this.store.dispatch(new fromList.DeleteClienteestacioncontacto(DeleteRequest));

        this.success$ = this.store.pipe(select(fromList.getSuccess));

        this.success$.subscribe((success) => { 
          if(success) {

            //console.log('success');

            this.OnLimpiarFormulario();
            this.onLoadcbx();
            this.OnloadGrid();

          }
        })

      */
    }
    
    
  }

  OnLimpiarFormulario(){

    this.verNuevo  = false;  

    this.Formcontacto = new FormGroup({
      cbxtipocontacto: new FormControl( null , [Validators.required]),
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
