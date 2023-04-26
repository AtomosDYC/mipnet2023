import { Component, OnInit, Input } from '@angular/core';


import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { ActivatedRoute, Router } from '@angular/router';

import { TipoComPersonaResponse as Response } from '../../store/save';
import { TipoComPersonaCreateRequest as Request } from '../../store/save';


@Component({
  selector: 'app-contenedor',
  templateUrl: './contenedor.component.html',
  styleUrls: ['./contenedor.component.scss']
})
export class ContenedorComponent implements OnInit {

  @Input() selectedItem: string;

  public Form: FormGroup;
  public ID: string | null;
  loading$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    per04llave: 0,
    per04nombre: '',
    per04descripcion: '',
    per04activo: 0
  }

  constructor(
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    private _Route: Router,
  ) {
    this.customMsgService = this.messages as CustomMessagesService;
   }

  ngOnInit(): void {
    
    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) 
      {
        
        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getTipoComPersonabyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.per04nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.per04descripcion, [Validators.required])
                });

            } else {
              
            }
          })

      } else {
        
        this.Form = new FormGroup({
          txtNombre: new FormControl( '' , [Validators.required]),
          txtDescripcion: new FormControl('', [Validators.required])
        });
        
      }

    });

    this.Form = new FormGroup({
      txtNombre: new FormControl( this.listdata.per04nombre , [Validators.required]),
      txtDescripcion: new FormControl(this.listdata.per04descripcion, [Validators.required])
    });

  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion } = this.Form.value;

        const DataResponse : Response = {
          per04llave : Number(this.ID),
          per04nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          per04descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          per04activo : 0
        }

        this.store.dispatch(new fromList.Update(DataResponse));
        this.Error$  = this.store.pipe(select(fromList.getError));
        


        this.selectedItem = 'Asociar con Persona';
        

      } else {
      
        const { txtNombre, txtDescripcion } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            per04nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per04descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));
          this.selectedItem = 'Asociar con Persona';
      }
    }

  }

  onFinalizar():void {
    this._Route.navigate(['/dashboard/tipocomunicacionpersona/list/']);
  }

}
