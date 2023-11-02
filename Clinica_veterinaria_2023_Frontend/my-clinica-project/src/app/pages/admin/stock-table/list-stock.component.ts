import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/core/user/user.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { AdminService } from 'src/app/services/admin.service';
import { ProductService } from 'src/app/services/product.service';
import { StockService } from 'src/app/services/stock.service';
import { userServiceAPI } from 'src/app/services/userAPI.service';
import Swal from 'sweetalert2';

export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-list-stock',
  templateUrl: './list-stock.component.html',
  styleUrls: ['./list-stock.component.scss']
})
export class ListStockComponent {
  constructor(
    private adminService: AdminService,
    private paddingService: PaddingService,
    private productService: ProductService,
    private stockService : StockService

    ) { }

    stockList: any[] = [];

    public containerPadding: string;
    //padding
    private paddingSubscription: Subscription;



  ngOnInit() {
     //padding
     this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

    this.loadStocks();
  }

  loadStocks() {
    this.stockService.getAllStock().subscribe((data: any[]) => {
      console.log(data);
      this.stockList = data;
    });
  }
}
