
import { Component, EventEmitter, Input, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Unspsc } from 'src/app/models/unspsc.model';

//  const ELEMENT_DATA: PeriodicElement[] = [
//   { idUnspsc: 1, codigoSfcm: '10101501', segmento: 'Live animals', familia: 'Livestock', classe: 'Cattle', mercadoria: 'Dairy cattle' },
//   { idUnspsc: 2, codigoSfcm: '10101502', segmento: 'Live animals', familia: 'Livestock', classe: 'Cattle', mercadoria: 'Beef cattle' },
//   { idUnspsc: 3, codigoSfcm: '10101503', segmento: 'Live animals', familia: 'Livestock', classe: 'Cattle', mercadoria: 'Feeder cattle' },
//   { idUnspsc: 4, codigoSfcm: '10101601', segmento: 'Live animals', familia: 'Livestock', classe: 'Swine', mercadoria: 'Pigs' },
//   { idUnspsc: 5, codigoSfcm: '10101602', segmento: 'Live animals', familia: 'Livestock', classe: 'Swine', mercadoria: 'Hogs' }
// ];

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

    displayedColumns: string[] = ['idUnspsc', 'codigoSfcm', 'descricaoSegmento', 'descricaoFamilia', 'descricaoClasse', 'descricaoMercadoria','edit','produto', 'delete'];

    dataSource = new MatTableDataSource<Unspsc>(this.unspscList);

    @ViewChild(MatPaginator) paginator: MatPaginator;

    ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
    }


    ngOnChanges(changes: SimpleChanges) {
      if (changes['unspscList']) {
        this.dataSource = new MatTableDataSource<Unspsc>(this.unspscList);
        this.dataSource.paginator = this.paginator;
      }
    }

    viewProductsByUnspsc(itemId: any){
      this.router.navigate([`/admin/list-product/${itemId}`])
    }


    addProductsByUnspsc(unspscId:any){
      this.router.navigate([`/admin/create-product/${unspscId}`])
    }
}
