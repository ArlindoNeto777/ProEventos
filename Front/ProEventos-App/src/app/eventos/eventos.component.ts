import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor() { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos() : void {
      this.eventos = [
      {
        Tema: "Angular",
        Local: "Belo Horizonte"
      },
      {
        Tema: ".Net 5",
        Local: "São Paulo"
      },
      {
        Tema: "HTML 5 e CSS 3",
        Local: "Salvador"
      }
    ];
  }

}
