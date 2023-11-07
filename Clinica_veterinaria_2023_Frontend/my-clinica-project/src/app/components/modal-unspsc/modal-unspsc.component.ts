import { UserService } from '../../core/user/user.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { MenuService } from '../../services/menu.service';
import { Component, OnInit } from '@angular/core';
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


  ngOnInit(): void {
    throw new Error('Method not implemented.');
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
}
