import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { TemporadaResponse as Response } from '../../store/save';
import { TemporadaCreaterequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';


import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

@Component({
  selector: 'app-temporada-nuevo',
  templateUrl: './temporada-nuevo.component.html',
  styleUrls: ['./temporada-nuevo.component.scss']
})
export class TemporadaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  private _fillcomboservices;

  public selecteBase;
  public selectedSegmentacion;

  errorMessage: any;

  public customMsgService: CustomMessagesService;

  Baselist :any;
  Segmentacionlist :any;
  
  setBase: SetSelect = {
    tablename : 'Temporada_Base'
  }
  setSegmentacion: SetSelect = {
    tablename : 'Segmentacion_temporada',
  }
  
  listdata :  Response  = {
    temp01llave: 0,
    temp01nombre: '',
    temp01descripcion: '',
    temp01activo: 0,
    temp01minfecha: new Date(),
    temp01maxfecha: new Date(),
    temp01minmes:0,
    temp01maxmes:0,
    temp01periodo:0,
    temp02llave:0,
    temp02nombre:'',
    temp03llave:0,
    temp03nombre:''
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
    this._fillcomboservices = FillComboService;
  }

  ngOnInit(): void {

    this.Form = new FormGroup({
                  txtNombre: new FormControl(null , [Validators.required]),
                  txtDescripcion: new FormControl(null, [Validators.required]),
                  cbxBaseTemporada: new FormControl(null , [Validators.required]),
                  cbxSegmentacion: new FormControl(null , [Validators.required]),
                  dtpMinfecha: new FormControl(new Date(), [Validators.required]),
                  dtpMaxfecha: new FormControl(new Date(), [Validators.required]),
                  txtperiodos: new FormControl(null, [Validators.required])
                });

    this.onLoadcbx();

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getTemporadabyid))
          .subscribe(data => {
            if(data){

              const [dateStr, timeStr] = data.temp01maxfecha!.toString().split('T');
              
              //console.log(dateStr);

              const [dateStrmin, timeStrmin] = data.temp01minfecha!.toString().split('T');

              
              
                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.temp01nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.temp01descripcion, [Validators.required]),
                  cbxBaseTemporada: new FormControl({value: String(data.temp02llave), description: String(data.temp02nombre)}, [Validators.required]),
                  cbxSegmentacion: new FormControl({value: String(data.temp03llave), description: String(data.temp03nombre)}, [Validators.required]),
                  dtpMinfecha: new FormControl( new Date(dateStrmin), [Validators.required]),
                  dtpMaxfecha: new FormControl( new Date(dateStr) , [Validators.required]),
                  txtperiodos: new FormControl( data.temp01periodo , [Validators.required]),
                });0

            } else {
              
            }
          })
      }
 
    });
    
  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setBase).subscribe(
      allrecords => {0
        this.Baselist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setSegmentacion).subscribe(
      allrecords => {0
        this.Segmentacionlist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

  }

  onguardarNuevo(): void {
    

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion, cbxBaseTemporada, cbxSegmentacion,dtpMinfecha,dtpMaxfecha, txtperiodos  } = this.Form.value;

        const DataResponse : Response = {
          temp01llave : Number(this.ID),
          temp01nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          temp01descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          temp02llave: cbxBaseTemporada.value,
          temp03llave: cbxSegmentacion.value,
          temp01minfecha: dtpMinfecha,
          temp01maxfecha: dtpMaxfecha,
          temp01periodo: txtperiodos,
          temp01minmes:1,
          temp01maxmes:12,
          temp01activo : 0
        }

        //console.log('DataResponse', DataResponse);

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion, cbxBaseTemporada, cbxSegmentacion,dtpMinfecha,dtpMaxfecha, txtperiodos  } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            temp01nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            temp01descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            temp02llave: cbxBaseTemporada.value,
            temp03llave: cbxSegmentacion.value,
            temp01minfecha: dtpMinfecha,
            temp01maxfecha: dtpMaxfecha,
            temp01periodo: txtperiodos,
            temp01minmes:1,
            temp01maxmes:12,

          }
        
          //console.log('temporada', CreateRequest );
          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
    
  }
  

}
