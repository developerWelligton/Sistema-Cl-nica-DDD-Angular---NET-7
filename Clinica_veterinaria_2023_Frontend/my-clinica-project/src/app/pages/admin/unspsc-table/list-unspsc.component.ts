import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Unspsc } from 'src/app/models/unspsc.model';
import { PaddingService } from 'src/app/services/Padding.service';
import { DataService } from './../../../services/data.service';
import { UnspscService } from 'src/app/services/unspsc.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-list-unspsc',
  templateUrl: './list-unspsc.component.html',
  styleUrls: ['./list-unspsc.component.scss']
})
export class ListUnspscComponent implements OnInit, OnDestroy {
  public unspscList: any[] = [];
  public containerPadding: string;
  private paddingSubscription: Subscription;

  constructor(
    private paddingService: PaddingService,
    private dataService: DataService,
    private unspscService: UnspscService
  ) { }

  ngOnInit() {
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });


    this.unspscService.getAllUnspscCodeDetails().subscribe((data: any[]) => {
      this.unspscList = data;
    });

  }

  handleUnspscDeleted(itemId: any): void {
    Swal.fire({
      title: 'Você tem certeza?',
      text: "Você não poderá reverter isso!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim, delete isso!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.unspscService.deleteUnspscCode(itemId).subscribe(
          () => {
            // Caso de sucesso: você pode mostrar um alerta de sucesso ou atualizar a lista, por exemplo.
            Swal.fire({
              icon: 'success',
              title: 'Deletado!',
              text: 'O código UNSPSC foi deletado.',
            });
          },
          (error) => {
            // Caso de erro: mostrar um alerta com a mensagem de erro.
            console.error('Falha ao deletar:', error);
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Não foi possível deletar o código UNSPSC.',
            });
          }
        );
      }
    });
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
