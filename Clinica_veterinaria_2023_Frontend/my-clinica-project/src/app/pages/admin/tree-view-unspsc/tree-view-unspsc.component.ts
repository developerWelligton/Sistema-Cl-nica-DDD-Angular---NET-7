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


    this.unspscService.listWithDescription().subscribe(data => {

      this.treeSource = this.transformToTreeData(data); // assuming data needs some transformation
      console.log(this.treeSource)
    });

  }
   // Transform the fetched data to match the tree data structure (if necessary)
   transformToTreeData(data) {
    // Helper function to add a node to the map or return an existing one
    const addOrGetNode = (map, key, label) => {
      if (!map[key]) {
        map[key] = { label, items: [] };
      }
      return map[key];
    };

    // Maps to store nodes at each level
    const segmentMap = {};
    const familyMap = {};
    const classMap = {};

    // Iterate over each item to build the tree structure
    data.forEach(item => {
      // Get or create segment node
      const segmentKey = item.segmento.codigo;
      const segmentNode = addOrGetNode(segmentMap, segmentKey, `${item.segmento.descricao} (${item.segmento.codigo})`);

      // Get or create family node within the segment
      const familyKey = `${segmentKey}-${item.familia.codigo}`;
      const familyNode = addOrGetNode(familyMap, familyKey, `${item.familia.descricao} (${item.familia.codigo})`);
      if (!segmentNode.items.includes(familyNode)) {
        segmentNode.items.push(familyNode);
      }

      // Get or create class node within the family
      const classKey = `${familyKey}-${item.classe.codigo}`;
      const classNode = addOrGetNode(classMap, classKey, `${item.classe.descricao} (${item.classe.codigo})`);
      if (!familyNode.items.includes(classNode)) {
        familyNode.items.push(classNode);
      }

      // Create and add commodity node within the class
      const commodityLabel = `<strong> ${item.mercadoria.descricao} (${item.mercadoria.codigo})</strong>  `;
      classNode.items.push({ label: commodityLabel });
    });

    // Convert the segment map to an array to get the final tree structure
    return Object.values(segmentMap);
  }







  ngAfterViewInit(): void {
    setTimeout(() => {
        this.tree.selectItem(null);
    });
}


 treeSource = [
  ];


}
