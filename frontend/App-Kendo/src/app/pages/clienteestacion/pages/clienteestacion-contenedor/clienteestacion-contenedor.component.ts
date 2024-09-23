import { Component, OnInit } from '@angular/core';
import {  ActivatedRoute, UrlSegment } from '@angular/router';


@Component({
  selector: 'app-clienteestacion-contenedor',
  templateUrl: './clienteestacion-contenedor.component.html',
  styleUrls: ['./clienteestacion-contenedor.component.scss']
})
export class ClienteestacionContenedorComponent implements OnInit {

  public selectedItem: any;

  constructor(
    private router: ActivatedRoute
  ) { }

  ngOnInit(): void {

    this.router.parent?.url.subscribe(path =>{
      const url: UrlSegment[] = path.map(path =>{ return path })

      console.log('this.router',this.router);
      console.log('this.router.parent?.url',this.router.parent?.url);
      console.log('url',url);

      

      this.selectedItem = url[0]!.path;
    });

    //console.log('contenedor',this.selectedItem);
  }
}
