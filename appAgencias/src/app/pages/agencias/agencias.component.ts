import { Component, OnInit } from '@angular/core';
import { AgenciasService } from 'src/app/services/agencias.service';
import { Agencias } from '../models/agencias';

@Component({
  selector: 'app-agencias',
  templateUrl: './agencias.component.html',
  styleUrls: ['./agencias.component.css']
})
export class AgenciasComponent implements OnInit {

  agencias: Agencias[] = [];
  constructor(private dataservice: AgenciasService) { }

  ngOnInit() {
    this.getAgencias();
  }
  getAgencias(){
    this.dataservice.getAgencias().subscribe(data => {
      this.agencias = data.resResult;
    });
  }
}
