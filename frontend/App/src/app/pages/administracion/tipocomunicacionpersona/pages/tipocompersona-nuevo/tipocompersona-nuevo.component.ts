import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

@Component({
  selector: 'app-tipocompersona-nuevo',
  templateUrl: './tipocompersona-nuevo.component.html',
  styleUrls: ['./tipocompersona-nuevo.component.scss']
})
export class TipocompersonaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  public tipocompersonaForm: FormGroup;

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>)
  {

  }

  ngOnInit(): void {
    this.tipocompersonaForm = this.fb.group({
      nombre: ['', Validators.required ],
      descripcion: ['', Validators.required ]
    });
  }

  onguardarNuevo(): void {

    const { nombre, descripcion } = this.tipocompersonaForm.value;
    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const tipocompersonaCreateRequest : fromList.TipoComPersonaCreateRequest = {
          per04nombre : nombre,
          per04descripcion : descripcion
        }

        this.store.dispatch(new fromList.Create(tipocompersonaCreateRequest));

  }

}
