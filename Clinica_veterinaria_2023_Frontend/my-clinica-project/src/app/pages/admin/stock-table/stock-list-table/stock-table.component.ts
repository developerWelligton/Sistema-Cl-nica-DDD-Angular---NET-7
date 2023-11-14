import { userServiceAPI } from 'src/app/services/userAPI.service';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { DomSanitizer } from '@angular/platform-browser';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-list-table-stock',
  templateUrl: './stock-table.component.html',
  styleUrls: ['./stock-table.component.scss']
})
export class  StockListTableComponent {

  displayedColumns: string[] = ['codigoDoEstoque', 'sala', 'prateleira', 'acoes'];

  @Input() stockList: any[] = [];
  @Output() productDeleted: EventEmitter<void> = new EventEmitter<void>();
  @Output() deleteRequest = new EventEmitter<number>();

  constructor(
    private adminService: AdminService,
    private router:Router,
    private sanitizer: DomSanitizer,
    private productService: ProductService) {
      console.log(this.stockList)
    }

  editStock(user: any) {
    // Implemente a lógica para editar o usuário aqui
    console.log('Editar usuário:', user);
  }



  deleteStock(idProduct: any) {
    this.deleteRequest.emit(idProduct);
  }



  viewStock(id: string): void {
    this.router.navigate(['admin/list-stock/detail-stock-product', id]);
  }

}
