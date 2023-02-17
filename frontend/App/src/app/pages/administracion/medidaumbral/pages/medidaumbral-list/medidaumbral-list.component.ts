import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { MedidaUmbralResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-medidaumbral-list',
  templateUrl: './medidaumbral-list.component.html',
  styleUrls: ['./medidaumbral-list.component.scss']
})
export class MedidaumbralListComponent implements OnInit {

  medidaumbrales$! : Observable<MedidaUmbralResponse[] | null>;
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
      key: 'esp06nombre',
      label: 'Nombre',
      _style: { width: '40%' }
    },
    {
      key: 'esp06descripcion',
      label: 'descripción',
      _style: { width: '40%' }
    },
    {
      key: 'esp06activo',
      label:'',
      _style: { width: '80px' },
      filter: false,
      sorter: false
    },

  ];

  constructor(
    private store: Store<fromRoot.State>,
    private sanitizer: DomSanitizer,
    private _Route: Router,
    private route: ActivatedRoute,
    ) {

    }

  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    console.log('primero',this.medidaumbrales$);
    this.medidaumbrales$ = this.store.pipe(select(fromList.getMedidaUmbrales));
    console.log('segundo',this.medidaumbrales$);
  }

  checkSelected = (selectedItems: any) => {

    this.selectedItems = [].concat(selectedItems);

  };

  onEditar(id: number): void {
    this._Route.navigate(['/dashboard/medidaumbrales/edit/', id.toString()]);
  }

  onEliminar(id: number, estado : number): void {

    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta medida de umbral?"))
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


  OndisableMedidaUmbral():void {
    if(this.selectedItems){
      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateMedidaUmbral():void {
    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }

  }

}
