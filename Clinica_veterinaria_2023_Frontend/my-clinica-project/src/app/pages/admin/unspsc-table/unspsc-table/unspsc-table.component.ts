
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Unspsc } from 'src/app/models/unspsc.model';

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

}
