
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sale-table',
  templateUrl: './sale-table.component.html',
  styleUrls: ['./sale-table.component.scss']
})
export class SaleTableComponent {


  @Input() saleList: any[] = [];

  constructor(
    private router:Router) { }

    ngOnInit() {
      console.log('Componente SaleTable iniciado');
    }
}
