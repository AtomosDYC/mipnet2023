import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from '../../store/save';
import { UsuarioResponse as Response } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import {DataStateChangeEvent } from "@progress/kendo-angular-grid";
import { HttpParams } from '@angular/common/http';
import { CustomEncoder } from 'src/app/_helpers/custom-encoder';


@Component({
  selector: 'app-usuario-list',
  templateUrl: './usuario-list.component.html',
  styleUrls: ['./usuario-list.component.scss']
})
export class UsuarioListComponent implements OnInit {

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

    const datafull =  this.store.pipe(select(fromList.getUsuarioregistros));

    if(this.filtro ){    
      const datafullfilter = datafull.pipe(
        map((data : Response[] | null) => data!.filter(valor => valor.username.toLowerCase().includes(this.filtro.toLowerCase())))
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

  OnSendConfirmation(userid: string):void {
    
    //console.log('confiirmation', userid);

    this.store.dispatch(new fromList.Send(userid));
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    

  }

  OnNuevo(){
    this._Route.navigate(['/dashboard/usuarios/nuevo/']);
  }

  OnEditar(id: string){
  
    this._Route.navigate(['/dashboard/usuarios/edit/',  id]);
  }

  OnEliminar(id: number){
   
  }

  OnConfirmado(estado: boolean):string{

    return estado ? 'confirmado' : 'sin conrfirmar';
  }

  OndisableRegion():void {

    /*
    const request: Response[] =  this.mySelection.map((item) => {
      const data:Response = {
        per03llave: Number(item),
        per03activo: 1,
        per03nombre:'',
        per03descripcion:''
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.Desactivate(request!));
      this.mySelection = [];
    }
    */

  }

  onactivateRegion():void {

    /*
    const request: Response[] =  this.mySelection.map((item) => {

      const data:Response = {
        per03llave: Number(item),
        per03activo: 1,
        per03nombre:'',
        per03descripcion:''
      };
      return data;
    });

    if(request){
      this.store.dispatch(new fromList.Activate(request!));
      this.mySelection = [];
    }
    */

  }

}

