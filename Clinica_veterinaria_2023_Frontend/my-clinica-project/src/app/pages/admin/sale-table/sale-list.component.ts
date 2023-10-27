import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { PaddingService } from 'src/app/services/Padding.service';
import { DataService } from 'src/app/services/data.service';
import { SaleServicePaymentService } from 'src/app/services/saleServicePayment.service';
import { UnspscService } from 'src/app/services/unspsc.service';

@Component({
  selector: 'app-sale-list',
  templateUrl: './sale-list.component.html',
  styleUrls: ['./sale-list.component.scss']
})
export class ListSaleComponent {
  public saleList: any[] = [];

  public containerPadding: string;
  private paddingSubscription: Subscription;

  constructor(
    private paddingService: PaddingService,
    private dataService: DataService,
    private unspscService: UnspscService,
    private saleServicePayment: SaleServicePaymentService
  ) { }

  ngOnInit() {
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
    this.saleServicePayment.getAllPayments().subscribe((data: any[]) => {
      console.log(data)
      this.saleList = data;
    });

  }

  ngOnDestroy() {
    if (this.paddingSubscription) {
      this.paddingSubscription.unsubscribe();
    }
  }
}
