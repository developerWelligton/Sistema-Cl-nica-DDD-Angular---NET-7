import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/core/user/user.service';
import { PaddingService } from 'src/app/services/Padding.service';

import { jqxTreeComponent } from 'jqwidgets-ng/jqxtree';
import { UnspscService } from 'src/app/services/unspsc.service';



@Component({
  selector: 'app-tree-view-unspsc',
  templateUrl: './tree-view-unspsc.component.html',
  styleUrls: ['./tree-view-unspsc.component.scss']
})
export class TreeViewUnspscComponent {
  @ViewChild('treeReference', { static: false }) tree: jqxTreeComponent;
  private paddingSubscription: Subscription;
  public containerPadding: string;


  constructor(
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService,
    private unspscService: UnspscService

  ) {
  }


  ngOnInit() {
    //padding
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

    this.unspscService.listWithDescription().subscribe(data => {
      this.treeSource = this.transformToTreeData(data); // assuming data needs some transformation
      console.log(this.treeSource)
    });

  }
   // Transform the fetched data to match the tree data structure (if necessary)
   transformToTreeData(data: any[]): any[] {
    let segmentoMap = {};
    let familiaMap = {};
    let classeMap = {};

    data.forEach(item => {
        if (!segmentoMap[item.segmento.descricao]) {
            segmentoMap[item.segmento.descricao] = {
                label: item.segmento.descricao + ""+"("+item.segmento.codigo+")",
                items: []
            };
        }

        if (!familiaMap[item.familia.descricao]) {
            familiaMap[item.familia.descricao] = {
                label: item.familia.descricao + ""+"("+item.familia.codigo+")",
                items: []
            };
            segmentoMap[item.segmento.descricao].items.push(familiaMap[item.familia.descricao]);
        }

        if (!classeMap[item.classe.descricao]) {
            classeMap[item.classe.descricao] = {
                label: item.classe.descricao + ""+"("+item.classe.codigo+")",
                items: []
            };
            familiaMap[item.familia.descricao].items.push(classeMap[item.classe.descricao]);
        }

        classeMap[item.classe.descricao].items.push({
            label: item.mercadoria.descricao + ""+"("+item.mercadoria.codigo+")",
            UNSPSC: item.codigoSfcm
        });
    });

    return Object.values(segmentoMap);
}





  ngAfterViewInit(): void {
    setTimeout(() => {
        this.tree.selectItem(null);
    });
}


 treeSource = [
  ];


}
