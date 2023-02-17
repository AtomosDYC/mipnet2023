import { Component, OnInit } from '@angular/core';
import { FillComboService } from '../../../../../services/fill-combo.service';
import { GetSelect, SetSelect } from '../../../../../models/backend/getselect'
import { Observable } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Store, select } from '@ngrx/store';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

@Component({
  selector: 'app-comuna-nuevo',
  templateUrl: './comuna-nuevo.component.html',
  styleUrls: ['./comuna-nuevo.component.scss']
})
export class ComunaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  public comunaForm: FormGroup;

  private _fillcomboservices;
  regionList :GetSelect[];
  setRegion: SetSelect = {
    tablename : 'region'
  }
  errorMessage: any;

  constructor
  (
    FillComboService: FillComboService,
    private fb: FormBuilder,
    private store: Store<fromRoot.State>
  )
   {
    this._fillcomboservices = FillComboService;
   }

  ngOnInit(): void {

    this.comunaForm = this.fb.group({
      nombre: ['', Validators.required ],
      descripcion: ['', Validators.required ],
      escapital: [''],
      region: ['Seleccione Región', Validators.required ],
    });


    this._fillcomboservices.GetAllSelect(this.setRegion).subscribe(
      allrecords => {
        this.regionList = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }

  onguardarNuevo(): void {


    console.log('dentro del onguardar');

    const { nombre, descripcion, escapital, region } = this.comunaForm.value;
    console.log('primero', escapital);

    const capital = escapital ? 1 : 0

    console.log('segundo', escapital);

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const comunaCreateRequest : fromList.ComunaCreateRequest = {
          sist03nombre : nombre,
          sist03descripcion : descripcion,
          sist03capital: capital,
          sist04llave: region
        }

        console.log(comunaCreateRequest);

        this.store.dispatch(new fromList.Create(comunaCreateRequest));

  }

}
