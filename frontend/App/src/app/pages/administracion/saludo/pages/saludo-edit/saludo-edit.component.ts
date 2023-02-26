import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Store, select } from '@ngrx/store';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { SaludosResponse, SaludoResponse } from '../../store/save';

@Component({
  selector: 'app-saludo-edit',
  templateUrl: './saludo-edit.component.html',
  styleUrls: ['./saludo-edit.component.scss']
})
export class SaludoEditComponent implements OnInit {

  saludoModel$ !: Observable<SaludoResponse | null>;
  loading$ !: Observable<boolean | null>;
  public saludoForm: FormGroup;
  SaludoID: string | null;

  saludo :  SaludoResponse  = {
    per02llave: 0,
    per02titulo: '',
    per02orden: 0,
    per02activo: 0
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    private router: Router,)
  {

  }

  ngOnInit(): void {

    this.saludoForm = this.fb.group({
      titulo: ['', Validators.required ],
      orden: ['', Validators.required ],
    });

    this._routeParams.paramMap.subscribe(params => {
      this.SaludoID = (params.get('id'));

      if(this.SaludoID) {
        this.store.dispatch(new fromList.Getbyid(this.SaludoID));

      } else {
        this.router.navigate((['/dashboard/saludos/list/']));
      }
    })

    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.store.pipe(select(fromList.getSaludobyid))
              .subscribe(data => {
                if(data){
                 this.saludoForm.setValue({
                    titulo: data.per02titulo,
                    orden: data.per02orden
                  })
                } else {
                  this.router.navigate((['/dashboard/saludos/list/']));
                }
              })




  }


  onguardarNuevo(): void {

    console.log('dentro del onguardar');

    const { titulo, orden } = this.saludoForm.value;

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const saludoResponse : fromList.SaludoResponse = {
          per02llave : Number(this.SaludoID),
          per02titulo : titulo,
          per02orden: Number(orden),
          per02activo : 0
        }

        console.log(`create onguardar ${saludoResponse}`);

        this.store.dispatch(new fromList.Update(saludoResponse));

  }

}
