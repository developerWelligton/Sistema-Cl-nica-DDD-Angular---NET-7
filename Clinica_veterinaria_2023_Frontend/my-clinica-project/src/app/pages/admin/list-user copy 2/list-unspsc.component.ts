import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Unspsc } from 'src/app/models/unspsc.model';
import { PaddingService } from 'src/app/services/Padding.service';
import { DataService } from './../../../services/data.service';

@Component({
  selector: 'app-list-unspsc',
  templateUrl: './list-unspsc.component.html',
  styleUrls: ['./list-unspsc.component.scss']
})
export class ListUnspscComponent implements OnInit, OnDestroy {
  unspscList: Unspsc[] = [];
  public containerPadding: string;
  private paddingSubscription: Subscription;

  constructor(
    private paddingService: PaddingService,
    private dataService: DataService
  ) { }

  ngOnInit() {
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

    this.dataService.getUnspsc().subscribe(data => {
      this.unspscList = data;
      console.log(JSON.stringify(this.unspscList))
    });
  }

  handleUnspscDeleted(itemId: any): void {
    // Lógica para lidar com a exclusão de um item unspsc
  }

  handleUnspscEdited(item: any): void {
    // Lógica para lidar com a edição de um item unspsc
  }

  ngOnDestroy() {
    if (this.paddingSubscription) {
      this.paddingSubscription.unsubscribe();
    }
  }
}
