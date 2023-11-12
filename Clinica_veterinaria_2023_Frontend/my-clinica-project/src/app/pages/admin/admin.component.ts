import { Component } from '@angular/core';
import { PaddingService } from 'src/app/services/Padding.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {

  public containerPadding: string;
  constructor(public menuService:MenuService,private paddingService: PaddingService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 5;
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  }

  cards = [
    {
      title: 'Painel Venda',
      subtitle: 'Aqui você pode fazer compras',
      image: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
      content: 'Descrição do card de Compras',
      link1Url: '/admin/panel-pdv',
      link1Text: 'Iniciar Venda',
      link2Url: '/mais-info',
      link2Text: 'Mais Informações'
    },
    {
      title: 'Painel Compra',
      subtitle: 'Gerencie seus produtos',
      image: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
      content: 'Descrição do card de Gerenciamento de Produto',
      link1Url: '/admin/panel-buy',
      link1Text: 'Iniciar Compra',
      link2Url: '/produtos-info',
      link2Text: 'Informações do Produto'
    },
    {
      title: 'Painel Produto',
      subtitle: 'Gerencie seus produtos',
      image: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
      content: 'Descrição do card de Gerenciamento de Produto',
      link1Url: '/gerenciar-produtos',
      link1Text: 'Gerenciar',
      link2Url: '/produtos-info',
      link2Text: 'Informações do Produto'
    },
    {
      title: 'Painel Estoque',
      subtitle: 'Gerencie seus produtos',
      image: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
      content: 'Descrição do card de Gerenciamento de Produto',
      link1Url: '/gerenciar-produtos',
      link1Text: 'Gerenciar',
      link2Url: '/produtos-info',
      link2Text: 'Informações do Produto'
    },
    // ... mais cards ...
  ];


  get cardRows() {
    let rows = [];
    for (let i = 0; i < this.cards.length; i += 3) {
      rows.push(this.cards.slice(i, i + 3));
    }
    return rows;
  }
}
