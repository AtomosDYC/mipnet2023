import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import * as fromRoot from '../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromList from './store/save';
import { DanioEspecieResponse as Response, DanioEspecieRequest as Request } from './store/save';


import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

@Component({
  selector: 'app-tipodatos',
  templateUrl: './tipodatos.component.html',
  styleUrls: ['./tipodatos.component.scss']
})
export class TipodatosComponent implements OnInit {

  data$! : Observable<Response[] | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  listadatos : any;
  loading$! : Observable<boolean | null>;
  DanioEspecielist: any;

  public verNuevo: boolean = false;
  public ID: string | null;
  private _fillcomboservices;

  public FormDanio: FormGroup = new FormGroup({
    cbxDanioEspecie: new FormControl( null , [Validators.required])
  });

  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';
  errorMessage: any;

  setDanioEspecie: SetSelect = {
    tablename : 'DanioEspecie_notinespcie',
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

    this.setDanioEspecie.prm1 = String(this.ID);

    this._fillcomboservices.GetAllSelect(this.setDanioEspecie).subscribe(
      allrecords => {
        this.DanioEspecielist = allrecords
      },
      error => this.errorMessage = <any>error
    );
  }


  ngOnInit(): void {

    

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.onLoadcbx();



        this.store.dispatch(new fromList.GetDanioespeciebyid(this.ID));
        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.data$ =  this.store.pipe(select(fromList.getDanioEspecies));
  

        this.FormDanio = new FormGroup({
          cbxDanioEspecie: new FormControl( null , [Validators.required])
        });

      }
    });
  }

  OnNuevoDanio(){

    this.verNuevo = true;

  }

  onContinuar(){
    if(this.ID) {
      this._Route.navigate(['/dashboard/especies/especies/umbrales', this.ID]);

    }

  }

  OnCancelar(){

    this.verNuevo = false;
    
  }

  onguardarDanioEspecie(){

    this.FormDanio.markAllAsTouched();

    if(this.FormDanio.valid){

      if(this.ID){

        const { cbxDanioEspecie } = this.FormDanio.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const UpdateRequest : Request = {
            
            esp03llave: Number(this.ID),
            esp04llave: cbxDanioEspecie.value

          }

          //console.log(UpdateRequest);

          this.store.dispatch(new fromList.CreateDanioespecie(UpdateRequest));

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
  
  OnEliminar(id: number){
        this.store.dispatch(new fromList.DeleteDanioEspecie(id.toString()));
    
  }
}
