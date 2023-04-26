import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from '../../store/save';
import { ComunaResponse as Response } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import {DataStateChangeEvent } from "@progress/kendo-angular-grid";

@Component({
  selector: 'app-comuna-list',
  templateUrl: './comuna-list.component.html',
  styleUrls: ['./comuna-list.component.scss']
})
export class ComunaListComponent implements OnInit {

  data$! : Observable<Response[] | null>;
  listadatos : any;
  loading$ : Observable<boolean | null> ;
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

    const datafull =  this.store.pipe(select(fromList.getComunas));

    if(this.filtro ){    
      const datafullfilter = datafull.pipe(
        map((data : Response[] | null) => data!.filter(valor => valor.sist03nombre!.toLowerCase().includes(this.filtro.toLowerCase())))
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
    this._Route.navigate(['/dashboard/comuna/nuevo/']);
  }

  OnEditar(id: number){
    this._Route.navigate(['/dashboard/comuna/edit/', id.toString()]);
  }

  OnEliminar(id: number, estado : number){
    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta Comuna?"))
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
        sist03llave: Number(item),
        sist03activo: 1,
        sist03nombre: '',
        sist03descripcion: '',
        sist03capital: 0,
        sist04llave: 0,

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
        sist03llave: Number(item),
        sist03activo: 1,
        sist03nombre: '',
        sist03descripcion: '',
        sist03capital: 0,
        sist04llave: 0,
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.Activate(request!));
      this.mySelection = [];
    }

  }

}
