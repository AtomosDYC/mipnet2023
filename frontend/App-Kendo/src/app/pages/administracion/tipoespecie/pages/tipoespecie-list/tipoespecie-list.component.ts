import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from '../../store/save';
import { TipoEspecieResponse as Response } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import {DataStateChangeEvent } from "@progress/kendo-angular-grid";

@Component({
  selector: 'app-tipoespecie-list',
  templateUrl: './tipoespecie-list.component.html',
  styleUrls: ['./tipoespecie-list.component.scss']
})
export class TipoespecieListComponent implements OnInit {

  data$! : Observable<Response[] | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';

  public customMsgService: CustomMessagesService;

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
    }

  public onFilter(e:DataStateChangeEvent): void {
    this.filtro = e.toString();
    this.loadData();
  }

  public loadData(): Observable<Response[] | null> {

    const datafull =  this.store.pipe(select(fromList.getTipoEspecies));

    if(this.filtro ){    
      const datafullfilter = datafull.pipe(
        map((data : Response[] | null) => data!.filter(valor => valor.esp08nombre.toLowerCase().includes(this.filtro.toLowerCase())))
        )
      return datafullfilter;

    } else {
      return datafull;
    }


  }

  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.loadData();
  }

  OnNuevo(){
    this._Route.navigate(['/dashboard/especies/tipoespecie/nuevo/']);
  }

  OnEditar(id: number){
    this._Route.navigate(['/dashboard/especies/tipoespecie/edit/', id.toString()]);
  }

  OnEliminar(id: number, estado : number){
    if(estado == 0){
      if (confirm("Esta seguro de eliminar este tipo de Especie?"))
      {
        this.store.dispatch(new fromList.Delete(id.toString()));
      }
    } else {
      this.store.dispatch(new fromList.Delete(id.toString()));
    }
  }

  OndisableRegion():void {

    
    const request: Response[] =  this.mySelection.map((item) => {
      const data:Response = {
        esp08llave: Number(item),
        esp08activo: 1,
        esp08nombre:'',
        esp08descripcion:''
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.Desactivate(request!));
      this.mySelection = [];
    }

  }

  onactivateRegion():void {

    const request: Response[] =  this.mySelection.map((item) => {

      const data:Response = {
        esp08llave: Number(item),
        esp08activo: 1,
        esp08nombre:'',
        esp08descripcion:''
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.Activate(request!));
      this.mySelection = [];
    }

  }

}
