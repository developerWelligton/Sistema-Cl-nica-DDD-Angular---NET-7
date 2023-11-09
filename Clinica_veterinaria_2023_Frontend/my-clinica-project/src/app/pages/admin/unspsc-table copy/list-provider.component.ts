import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Unspsc } from 'src/app/models/unspsc.model';
import { PaddingService } from 'src/app/services/Padding.service';
import { DataService } from './../../../services/data.service';
import { UnspscService } from 'src/app/services/unspsc.service';
import Swal from 'sweetalert2';
import { ProviderService } from 'src/app/services/provider.service';
import { Provider } from './provider-table/provider-table.component';

@Component({
  selector: 'app-list-provider',
  templateUrl: './list-provider.component.html',
  styleUrls: ['./list-provider.component.scss']
})
export class ListProviderComponent implements OnInit, OnDestroy {

  public providerList: Provider[] = []; // Use the correct Provider model
  public containerPadding: string;
  private paddingSubscription: Subscription;;

  constructor(
    private paddingService: PaddingService,
    private unspscService: UnspscService,
    private providerService: ProviderService
  ) { }

  ngOnInit() {
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

    this.providerService.getAllProviders().subscribe((data: Provider[]) => {
      this.providerList = data;
    });
  }

  handleProviderDeleted(providerId: number): void {
    // Confirm before deletion
    const confirmation = confirm('Tem certeza de que deseja excluir este fornecedor?');
    if (confirmation) {
      this.providerService.deleteProvider(providerId).subscribe(
        (response) => {
          // Handle the successful deletion
          alert('Fornecedor excluído com sucesso.');
          // Refresh the provider list or remove the deleted provider from the view
          this.providerList = this.providerList.filter(provider => provider.idFornecedor !== providerId);
        },
        (error) => {
          // Handle any errors here
          alert('Ocorreu um erro ao tentar excluir o fornecedor.');
          console.error('Erro ao excluir fornecedor:', error);
        }
      );
    }
  }


  handleProviderEdited(provider: Provider): void {
    // Existing logic for editing
    alert(provider)
  }

  ngOnDestroy() {
    if (this.paddingSubscription) {
      this.paddingSubscription.unsubscribe();
    }
  }
}
