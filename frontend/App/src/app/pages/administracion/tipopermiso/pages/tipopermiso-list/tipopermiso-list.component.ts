import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { TipoPermisoResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tipopermiso-list',
  templateUrl: './tipopermiso-list.component.html',
  styleUrls: ['./tipopermiso-list.component.scss']
})
export class TipopermisoListComponent implements OnInit {

  tipopermisos$! : Observable<TipoPermisoResponse[] | null>;
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
      key: 'wkf05nombre',
      label: 'Nombre',
      _style: { width: '40%' }
    },
    {
      key: 'wkf05descripcion',
      label: 'descripción',
      _style: { width: '40%' }
    },
    {
      key: 'wkf05sigla',
      label: 'Sigla',
      _style: { width: '10%' }
    },
    {
      key: 'wkf05activo',
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
    this.tipopermisos$ = this.store.pipe(select(fromList.getTipoPermisos));
  }

  checkSelected = (selectedItems: any) => {
    this.selectedItems = [].concat(selectedItems);
  };

  onEditar(id: number): void {
    this._Route.navigate(['/dashboard/tipopermiso/edit/', id.toString()]);
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


  OndisableTipoPermiso():void {

    if(this.selectedItems){

      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateTipoPermiso():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }

  }

}
