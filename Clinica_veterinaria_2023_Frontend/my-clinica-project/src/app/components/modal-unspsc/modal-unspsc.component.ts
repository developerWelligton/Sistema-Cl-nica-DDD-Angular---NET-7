import { UserService } from '../../core/user/user.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { MenuService } from '../../services/menu.service';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PaddingService } from 'src/app/services/Padding.service';
import { GlobalSidebarService } from 'src/app/services/globalSidebar.service';
import { User } from 'src/app/core/user/user';

@Component({
  selector: 'modal-unspsc',
  templateUrl: './modal-unspsc.component.html',
  styleUrls: ['./modal-unspsc.component.scss']
})
export class ModalUnspscComponent implements OnInit {

  showModal = false;
  segmentName = '';
  segmentDescription = '';

  @Input() modalType: number; // You can use Input if you want to pass data directly via template

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }


  open(type: number) {

    this.modalType = type;
    this.showModal = true;
    alert(this.modalType)

    // 1 - Segmento
    // 2 - Família
    // 3 - Classe
    // 4 - Mercadoria
  }

  onCloseModal() {
    this.showModal = false;
  }

  onSubmit() {
    // Handle the form submission
    const segmentData = {
      name: this.segmentName,
      description: this.segmentDescription
    };
    console.log(segmentData);
    this.showModal = false;
    // You may also want to send this data to a service or emit an event
  }


  getModalTitle(type: number): string {
    switch (type) {
      case 1: return 'Add New Segment';
      case 2: return 'Add New Family';
      case 3: return 'Add New Class';
      case 4: return 'Add New Commodity';
      default: return 'Add New Item';
    }
  }

  getModalFieldName(type: number): string {
    switch (type) {
      case 1: return 'Segment';
      case 2: return 'Family';
      case 3: return 'Class';
      case 4: return 'Commodity';
      default: return 'Item';
    }
  }
}
