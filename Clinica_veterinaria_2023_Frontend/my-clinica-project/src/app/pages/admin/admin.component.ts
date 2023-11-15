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
      title: 'Meus Clientes',
      subtitle: 'Aqui você gerenciar seus Clientes',
      image: 'assets/images/estoque.jpg',
      content: '',
      link1Url: '',
      link1Text: '',
      link2Url: '/admin/list-unspsc',
      link2Text: 'Ver Clientes',
      link3Url:  '',
      link3Text: ''
    },
    {
      title: 'Painel Venda',
      subtitle: 'Aqui você pode fazer suas vendas',
      image: 'assets/images/venda.jpg',
      content: '',
      link1Url: '/admin/panel-pdv',
      link1Text: 'Iniciar Venda'
    },
    {
      title: 'Painel Compra',
      subtitle: 'Aqui você pode gerenciar suas compras',
      image: 'assets/images/compra2.png',
      content: '',
      link1Url: '/admin/panel-buy',
      link1Text: 'Iniciar Compra'
    },
    {
      title: 'Painel Produto',
      subtitle: 'Gerencie seus produtos com praticidade',
      image: 'assets/images/produto.png',
      content: '',
      link1Url: '',
      link1Text: '',
      link2Url: '/admin/list-product',
      link2Text: 'Ver Produtos'
    },
    {
      title: 'Painel Estoque',
      subtitle: 'Aqui você pode gerenciar seus estoques',
      image: 'assets/images/estoque.jpg',
      content: '',
      link1Url: '',
      link1Text: '',
      link2Url: '/admin/list-stock',
      link2Text: 'Ver Estoques',
      link3Url:  '',
      link3Text: ''}
      ,
      {
        title: 'Painel Unspsc',
        subtitle: 'Aqui você gerenciar a categorização de produtos e serviços',
        image: 'assets/images/estoque.jpg',
        content: '',
        link1Url: '',
        link1Text: '',
        link2Url: '/admin/list-unspsc',
        link2Text: 'Ver Unspsc',
        link3Url:  '',
        link3Text: ''
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
