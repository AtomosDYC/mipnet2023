import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { PlantillaResponse as Response } from '../../store/save';
import { PlantillaCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { getPlantillabyid } from '../../store/save/save.selectors';

@Component({
  selector: 'app-plantilla-datosgenerales',
  templateUrl: './plantilla-datosgenerales.component.html',
  styleUrls: ['./plantilla-datosgenerales.component.scss']
})
export class PlantillaDatosgeneralesComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    prf03llave: 0,
    prf03nombre: '',
    prf03descripcion: '',
    prf03activo: 0,
    prf03orden: 0,
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
  }

  ngOnInit(): void {

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getPlantillabyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.prf03nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.prf03descripcion, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.prf03nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.prf03descripcion, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    
  }
}