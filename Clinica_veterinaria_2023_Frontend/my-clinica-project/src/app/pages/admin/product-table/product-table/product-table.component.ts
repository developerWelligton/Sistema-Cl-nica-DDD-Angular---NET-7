import { userServiceAPI } from 'src/app/services/userAPI.service';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { DomSanitizer } from '@angular/platform-browser';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-user-product',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.scss']
})
export class UserProductComponent {
  displayedColumns: string[] = ['idProduto', 'nome', 'precoCompra', 'precoVenda', 'status', 'actions'];

  @Input() productList: any[] = [];
  @Output() productDeleted: EventEmitter<void> = new EventEmitter<void>();
  @Output() deleteRequest = new EventEmitter<number>();
  unspscId:any
  constructor(
    private adminService: AdminService,
    private router:Router,
    private sanitizer: DomSanitizer,
    private productService: ProductService,
    private route: ActivatedRoute ) {
      this.unspscId = this.route.snapshot.paramMap.get('idUnspsc');
      alert(this.unspscId)
    }

  editProduct(user: any) {
    // Implemente a lógica para editar o usuário aqui
    console.log('Editar usuário:', user);
  }



  deleteProduct(idProduct: any) {
    this.deleteRequest.emit(idProduct);
  }

  getSanitizedImage(imageBase64: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl('data:image/jpg;base64,' + imageBase64);
  }

  viewProduct(id: string): void {
    this.router.navigate(['admin/detail-product', id]);
  }

}
