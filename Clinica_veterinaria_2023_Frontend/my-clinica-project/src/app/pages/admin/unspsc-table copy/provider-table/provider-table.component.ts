
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Unspsc } from 'src/app/models/unspsc.model';


export interface Provider {
  idFornecedor: number;
  nome: string;
  email: string;
  endereco: string;
  cnpj: string;
  iD_Usuario: number;
}
@Component({
  selector: 'app-provider-table',
  templateUrl: './provider-table.component.html',
  styleUrls: ['./provider-table.component.scss']
})
export class ProviderTableComponent {


  @Input() providerList: Provider[] = [];
  @Output() providerDeleted: EventEmitter<number> = new EventEmitter<number>();
  @Output() providerEdited: EventEmitter<Provider> = new EventEmitter<Provider>();

  constructor(
    private router:Router) { }

    editProvider(item: Provider): void {
      this.providerEdited.emit(item);
    }

    deleteProvider(providerId: number): void {
      this.providerDeleted.emit(providerId); // Make sure to emit a number, not void
    }

}
