
import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Unspsc } from 'src/app/models/unspsc.model';

 const ELEMENT_DATA: PeriodicElement[] = [
  { idUnspsc: 1, codigoSfcm: '10101501', segmento: 'Live animals', familia: 'Livestock', classe: 'Cattle', mercadoria: 'Dairy cattle' },
  { idUnspsc: 2, codigoSfcm: '10101502', segmento: 'Live animals', familia: 'Livestock', classe: 'Cattle', mercadoria: 'Beef cattle' },
  { idUnspsc: 3, codigoSfcm: '10101503', segmento: 'Live animals', familia: 'Livestock', classe: 'Cattle', mercadoria: 'Feeder cattle' },
  { idUnspsc: 4, codigoSfcm: '10101601', segmento: 'Live animals', familia: 'Livestock', classe: 'Swine', mercadoria: 'Pigs' },
  { idUnspsc: 5, codigoSfcm: '10101602', segmento: 'Live animals', familia: 'Livestock', classe: 'Swine', mercadoria: 'Hogs' }
];

export interface PeriodicElement {
  idUnspsc: number;
  codigoSfcm: string;
  segmento: string;
  familia: string;
  classe: string;
  mercadoria: string;
}
@Component({
  selector: 'app-unspsc-table',
  templateUrl: './unspsc-table.component.html',
  styleUrls: ['./unspsc-table.component.scss']
})
export class UnspscTableComponent {


  @Input() unspscList: Unspsc[] = [];
  @Output() unspscDeleted: EventEmitter<void> = new EventEmitter<void>();
  @Output() unspscEdited: EventEmitter<any> = new EventEmitter<any>();

  constructor(
    private router:Router) { }
    editUnspsc(item: any): void {
      // Emita o item que você quer editar para o componente pai
      this.unspscEdited.emit(item);
    }

    deleteUnspsc(itemId: any): void {
      // Emita o ID do item que você quer excluir para o componente pai
      this.unspscDeleted.emit(itemId);
    }

    displayedColumns: string[] = ['id', 'unspscCode', 'segment', 'family', 'class', 'commodity'];

    dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);

    @ViewChild(MatPaginator) paginator: MatPaginator;

    ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
    }


}
