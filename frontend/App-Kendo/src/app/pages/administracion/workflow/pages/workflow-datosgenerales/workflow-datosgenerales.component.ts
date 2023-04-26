import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { empty, Observable, tap } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';

import { ActivatedRoute, Router } from '@angular/router';

import { WorkflowResponse as Response } from '../../store/save';
import { WorkflowDatosgeneralesRequest as Request } from '../../store/save';
import { WorkflowDatosgeneralesUpdateRequest as RequestUpdate } from '../../store/save';


import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';

@Component({
  selector: 'app-workflow-datosgenerales',
  templateUrl: './workflow-datosgenerales.component.html',
  styleUrls: ['./workflow-datosgenerales.component.scss']
})
export class WorkflowDatosgeneralesComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup = new FormGroup(
    {
      cbxTipoflujo: new FormControl(null, Validators.required),
      cbxNivelflujo: new FormControl(null, Validators.required),
      txtNombre: new FormControl( null , [Validators.required]),
      txtDescripcion: new FormControl(null, [Validators.required]),
      chxEsinicio: new FormControl(null),
      txtOrden: new FormControl(null, [Validators.required]),
      txtPrioridad: new FormControl(null, [Validators.required])
    }
  );
  public ID: string | null;
  private _fillcomboservices;

  public isDisabledNivelflujo = true;
 
  public selectedTipoFLujo;

  errorMessage: any;

  public customMsgService: CustomMessagesService;

  Tipoflujolist :any;
  Nivelflujolist :any;

  setTipoFlujo: SetSelect = {
    tablename : 'tipo_flujo'
  }
  setNivelFlujo: SetSelect = {
    tablename : 'nivel_flujo',
    prm1 : ''
  }


  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
  ) {
    this.customMsgService = this.messages as CustomMessagesService;
    this._fillcomboservices = FillComboService;
   }

  ngOnInit(): void {
    
    this.onLoadcbx();

    this.Form = new FormGroup({
      cbxTipoflujo: new FormControl(null, Validators.required),
      cbxNivelflujo: new FormControl(null, Validators.required),
      txtNombre: new FormControl( '' , [Validators.required]),
      txtDescripcion: new FormControl('', [Validators.required]),
      chxEsinicio: new FormControl(false),
      txtOrden: new FormControl(0, [Validators.required]),
      txtPrioridad: new FormControl(0, [Validators.required])
    });

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      console.log('dentro del init()');

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getWorkflowbyid))
          .subscribe(data => {
            if(data){

              const esinicio = data.wkf01esinicio ? true : false;
              this.onLoadcbxNivelflujo(data.wkf02llave);
                
                this.Form = new FormGroup({
                  cbxTipoflujo: new FormControl({value: String(data.wkf02llave), description: String(data.wkf02nombre)}, Validators.required),
                  cbxNivelflujo: new FormControl({value: String(data.wkf03llave), description: String(data.wkf03nombre)}, Validators.required),
                  txtNombre: new FormControl( data.wkf01nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.wkf01descripcion, [Validators.required]),
                  chxEsinicio: new FormControl(esinicio),
                  txtOrden: new FormControl(data.wkf01orden, [Validators.required]),
                  txtPrioridad: new FormControl(data.wkf01prioridad, [Validators.required])
                });

               
                
               
            } else {
              
            }
          })
      } else {

         this.Form = new FormGroup({
          cbxTipoflujo: new FormControl(null, Validators.required),
          cbxNivelflujo: new FormControl(null, Validators.required),
          txtNombre: new FormControl( null , [Validators.required]),
          txtDescripcion: new FormControl(null, [Validators.required]),
          chxEsinicio: new FormControl(null),
          txtOrden: new FormControl(null, [Validators.required]),
          txtPrioridad: new FormControl(null, [Validators.required])
        });
      }
    });
    


  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipoFlujo).subscribe(
      allrecords => {
        this.Tipoflujolist = allrecords
        console.log('this.Tipoflujolist',this.Tipoflujolist);
        
      },
      error => this.errorMessage = <any>error
    );
  }

  onLoadcbxNivelflujo(id: number):void {

    this.setNivelFlujo.prm1 = String(id);

      this._fillcomboservices.GetAllSelect(this.setNivelFlujo).subscribe(
        allrecords => {
          this.Nivelflujolist = allrecords
        },
        error => this.errorMessage = <any>error
      );

  }

  handleTipoFlujoChange(value) {

    if (value === undefined) {

      this.Form.patchValue({ 'cbxNivelflujo': null});
      this.Nivelflujolist = [];
    
    } else {
    
      this.onLoadcbxNivelflujo(value.value);
      
    }

  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { cbxNivelflujo, txtNombre , txtDescripcion,  chxEsinicio, txtOrden, txtPrioridad  } = this.Form.value;

        const inicio = chxEsinicio ? 1 : 0

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const UpdateRequest : RequestUpdate = {
            
            wkf01llave : Number(this.ID),
            wkf01nombre: String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf01descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf01llavepadre: 0,
            wkf03llave: cbxNivelflujo.value,
            wkf01esinicio: inicio, 
            wkf01orden: txtOrden,
            wkf01prioridad: txtPrioridad,
            wkf01activo:1
          }

          this.store.dispatch(new fromList.Update(UpdateRequest));

      } else {
      
        const { cbxNivelflujo, txtNombre , txtDescripcion,  chxEsinicio, txtOrden, txtPrioridad  } = this.Form.value;

        const inicio = chxEsinicio ? 1 : 0

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            
            wkf01nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf01descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf01llavepadre: 0,
            wkf03llave: cbxNivelflujo.value,
            wkf01esinicio: inicio, 
            wkf01orden: txtOrden,
            wkf01prioridad: txtPrioridad,
            wkf01activo:1
          }

          console.log(CreateRequest);

          
          this.store.dispatch(new fromList.Create(CreateRequest));
        
      }
    }
  }

}
