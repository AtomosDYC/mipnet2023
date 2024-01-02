import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromList from './store/save';
import { EspecieUmbralResponse as Response, EspecieUmbralRequest as Request } from './store/save';


import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

@Component({
  selector: 'app-umbrales',
  templateUrl: './umbrales.component.html',
  styleUrls: ['./umbrales.component.scss']
})
export class UmbralesComponent implements OnInit {

  data$! : Observable<Response[] | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  listadatos : any;
  loading$! : Observable<boolean | null>;

  Especielist: any;
  DanioEspecielist: any;
  BaseUmbrallist: any;

  public verNuevo: boolean = false;
  public ID: string | null;
  private _fillcomboservices;

  public FormUmbral: FormGroup = new FormGroup({
    cbxDanioEspecie: new FormControl( null , [Validators.required]),
    cbxBaseUmbral: new FormControl( null , [Validators.required]),
    txtUmbralminimo: new FormControl( null , [Validators.required]),
    txtUmbralmaximo: new FormControl( null , [Validators.required]),
    txtColor: new FormControl( null , [Validators.required])
  });

  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';
  errorMessage: any;

  setEspecieDanio: SetSelect = {
    tablename : 'DanioEspecie_inespcie',
    prm1 : ''
  }

  setBaseUmbral: SetSelect = {
    tablename : 'tipobaseumbral_notinespecie',
    prm1 : ''
  }

  public customMsgService: CustomMessagesService;

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

    this.setEspecieDanio.prm1 = String(this.ID);

    this._fillcomboservices.GetAllSelect(this.setEspecieDanio).subscribe(
      allrecords => {
        this.DanioEspecielist = allrecords
      },
      error => this.errorMessage = <any>error
    );

    this.setBaseUmbral.prm1 = String(this.ID);

    this._fillcomboservices.GetAllSelect(this.setBaseUmbral).subscribe(
      allrecords => {
        this.BaseUmbrallist = allrecords
        //console.log('this.BaseUmbrallist ',this.BaseUmbrallist );
      },
      error => this.errorMessage = <any>error
    );

  }


  ngOnInit(): void {

    

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.onLoadcbx();



        this.store.dispatch(new fromList.Getbyid(this.ID));
        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.data$ =  this.store.pipe(select(fromList.getEspecieUmbrals));
  

        this.FormUmbral = new FormGroup({
          cbxDanioEspecie: new FormControl( null , [Validators.required]),
          cbxBaseUmbral: new FormControl( null , [Validators.required]),
          txtUmbralminimo: new FormControl( null , [Validators.required]),
          txtUmbralmaximo: new FormControl( null , [Validators.required]),
          txtColor: new FormControl( null , [Validators.required])
        });

      }
    });
  }

  OnNuevoDanio(){

    this.verNuevo = true;

  }

  onContinuar(){
    if(this.ID) {
      this._Route.navigate(['/dashboard/especies/especies/tiposdatos', this.ID]);
    }

  }

  OnCancelar(){

    this.verNuevo = false;
    
  }

  onguardarUmbralEspecie(){

    this.FormUmbral.markAllAsTouched();

    if(this.FormUmbral.valid){

      if(this.ID){

        const { cbxDanioEspecie, cbxBaseUmbral, txtUmbralminimo, txtUmbralmaximo, txtColor } = this.FormUmbral.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));
        
          const UpdateRequest : Request = {
            esp01llave: cbxDanioEspecie.value,
            esp09llave: cbxBaseUmbral.value,
            esp05minumbral: txtUmbralminimo,
            esp05maxumbral:txtUmbralmaximo,
            esp05color: txtColor
          };

          this.store.dispatch(new fromList.Create(UpdateRequest));

          this.success$ = this.store.pipe(select(fromList.getSuccess));

          this.success$.subscribe((success) => { 
            if(success) {

              this.verNuevo = false;
              this.onLoadcbx();

            }
          })

          
      }
    }
  }
  
  OnEliminarUmbral(id: number){

    this.loading$ = this.store.pipe(select(fromList.getLoading));
      
    this.store.dispatch(new fromList.DeleteEspecieUmbral(id.toString()));
    
    this.success$ = this.store.pipe(select(fromList.getSuccess));

    this.success$.subscribe((success) => { 
      if(success) {

        this.verNuevo = false;
        this.onLoadcbx();

      }
    })
        
    
  }
}
