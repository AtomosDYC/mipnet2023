import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { NivelFlujoResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-nivelflujo-list',
  templateUrl: './nivelflujo-list.component.html',
  styleUrls: ['./nivelflujo-list.component.scss']
})
export class NivelflujoListComponent implements OnInit {

  nivelflujos$! : Observable<NivelFlujoResponse[] | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  public selectedItems: any;

  loadingData = false;

  columns = [

    {
      key: 'show',
      label: '',
      _style: { width: '7%' },
      filter: false,
      sorter: false
    },
    {
      key: 'wkf02nombre',
      label: 'Tipo de Flujo',
      _style: { width: '25%' }
    },
    {
      key: 'wkf03nombre',
      label: 'Nivel de Flujo',
      _style: { width: '25%' }
    },
    {
      key: 'wkf03descripcion',
      label: 'descripción',
      _style: { width: '30%' }
    },
    {
      key: 'wkf03nivel1',
      label: 'Nivel de Flujo',
      _style: { width: '10%' }
    },
    {
      key: 'wkf03activo',
      label:'',
      _style: { width: '80px' },
      filter: false,
      sorter: false
    },

  ];

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    private route: ActivatedRoute,
    ) {

    }

  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.nivelflujos$ = this.store.pipe(select(fromList.getNivelFlujos));
  }

  checkSelected = (selectedItems: any) => {
    this.selectedItems = [].concat(selectedItems);
  };

  onEditar(id: number): void {
    this._Route.navigate(['/dashboard/nivelflujo/edit/', id.toString()]);
  }

  onEliminar(id: number, estado : number): void {

    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta región?"))
      {
        this.store.dispatch(new fromList.Delete(id.toString()));
      }
    } else {
      this.store.dispatch(new fromList.Delete(id.toString()));
    }

  }

  getBadge(status: number) : string {
    switch (status) {
      case 1:
        return 'success';
      case 0:
        return 'danger';
      default:
          return 'success';
    }
  }

  getBadgeestado(status: number) : string {
    switch (status) {
      case 1:
        return 'Activo';
      case 0:
        return 'Desactivado';
      default:
        return 'Activo';
    }
  }


  OndisableNivelFlujo():void {

    if(this.selectedItems){

      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateNivelFlujo():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }

  }

}

