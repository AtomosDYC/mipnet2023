import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { empty, Observable, tap } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromList from '../store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';

import { ActivatedRoute, Router } from '@angular/router';

import { EspecieResponse as Response } from '../store/save';
import { EspecieDatosgeneralesRequest as Request } from '../store/save';
import { EspecieDatosgeneralesUpdateRequest as RequestUpdate } from '../store/save';


import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

@Component({
  selector: 'app-especie-datosgenerales',
  templateUrl: './especie-datosgenerales.component.html',
  styleUrls: ['./especie-datosgenerales.component.scss']
})
export class EspecieDatosgeneralesComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup = new FormGroup(
    {
      cbxTipoespecie: new FormControl(null, Validators.required),
      txtNombre: new FormControl(null, Validators.required),
      txtDescripcion: new FormControl( null , [Validators.required]),
      chxUnirespecie: new FormControl(null),
    }
  );
  public ID: string | null;
  private _fillcomboservices;

  public isDisabledNivelflujo = true;
  public isDisabledContinuarDG = true;

  errorMessage: any;

  public customMsgService: CustomMessagesService;

  Tipoespecielist :any;

  setTipoespecie: SetSelect = {
    tablename : 'Tipo_Especie_Base'
  }

  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _Route: Router,
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
      cbxTipoespecie: new FormControl(null, Validators.required),
      txtNombre: new FormControl(null, Validators.required),
      txtDescripcion: new FormControl( null , [Validators.required]),
      chxUnirespecie: new FormControl(null),
    });

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.isDisabledContinuarDG = false;

        this.store.dispatch(new fromList.GetEspecieDatosGeneralesbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;

        //console.log('abtes de cargar el id');

        this.store.pipe(select(fromList.getEspeciebyid))
          .subscribe(data => {
            if(data){

              //console.log('data',data); 

              const esunion = data.esp03Union ? true : false;
                
                this.Form = new FormGroup({
                  cbxTipoespecie: new FormControl({value: String(data.esp08llave), description: String(data.esp08nombre)}, Validators.required),
                  txtNombre: new FormControl(data.esp03nombre, Validators.required),
                  txtDescripcion: new FormControl( data.esp03descripcion , [Validators.required]),
                  chxUnirespecie: new FormControl(esunion),
                });

            } else {
              
            }
          })
      } 
    });
    
  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipoespecie).subscribe(
      allrecords => {
        this.Tipoespecielist = allrecords
        //console.log('this.Tipoflujolist',this.Tipoespecielist );
        
      },
      error => this.errorMessage = <any>error
    );
  }

  onguardardatosgenerales(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { cbxTipoespecie, txtNombre , txtDescripcion,  chxUnirespecie  } = this.Form.value;

        const unirespecie = chxUnirespecie ? 1 : 0

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const UpdateRequest : RequestUpdate = {
            esp03llave : Number(this.ID),
            esp03nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            esp03descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            esp03Union : unirespecie,
            esp08llave : cbxTipoespecie.value
            
          }

          //console.log(UpdateRequest);

          
          this.store.dispatch(new fromList.UpdateEspecie(UpdateRequest));

      } else {


      
        const { cbxTipoespecie, txtNombre , txtDescripcion,  chxUnirespecie  } = this.Form.value;

        const unirespecie = chxUnirespecie ? 1 : 0

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            
            esp03nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            esp03descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            esp03Union : unirespecie,
            esp08llave : cbxTipoespecie.value
            
          }

          //console.log(CreateRequest);

          
          this.store.dispatch(new fromList.CreateEspecie(CreateRequest));
        
      }
    }
    
  }
  onContinuar() {
    if(this.ID){
      this._Route.navigate(['/dashboard/especies/especies/unirespecies/', this.ID]);
    }
  }

}
