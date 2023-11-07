import { UserService } from '../../core/user/user.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { PaddingService } from 'src/app/services/Padding.service';
import { GlobalSidebarService } from 'src/app/services/globalSidebar.service';
import { User } from 'src/app/core/user/user';
import { SegmentService } from 'src/app/services/segment.service';
import { FamilyService } from 'src/app/services/family.service';
import { CommodityService } from 'src/app/services/commodity.service';
import { ClassService } from 'src/app/services/classe.service';

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
  @Output() onSubmitted = new EventEmitter<any>();


  constructor(
    private segmentService: SegmentService, // These are hypothetical service names
    private familyService: FamilyService,   // Replace with your actual services
    private classService: ClassService,
    private commodityService: CommodityService
  ) {}

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }


  open(type: number) {

    this.modalType = type;
    this.showModal = true;

    // 1 - Segmento
    // 2 - Família
    // 3 - Classe
    // 4 - Mercadoria
  }

  onCloseModal() {
    this.showModal = false;
  }


  onSubmit() {
    const data = {
      codigo: this.segmentName,
      description: this.segmentDescription
    };

    switch (this.modalType) {
      case 1:
        // Make the request to the segment service
        this.segmentService.addSegment(data).subscribe(
          response => {
            console.log('Segment added:', response);
            this.onSubmitted.emit();
          },
          error => {
            console.error('Error adding segment:', error);
          }
        );
        break;
      case 2:
        // Make the request to the family service
        this.familyService.addFamily(data).subscribe(
          response => {
            console.log('Family added:', response);
            this.onSubmitted.emit();
          },
          error => {
            console.error('Error adding family:', error);
          }
        );
        break;
      case 3:
        // Make the request to the class service
        this.classService.addClass(data).subscribe(
          response => {
            console.log('Class added:', response);
            this.onSubmitted.emit();
          },
          error => {
            console.error('Error adding class:', error);
          }
        );
        break;
      case 4:
        // Make the request to the commodity service
        this.commodityService.addCommodity(data).subscribe(
          response => {
            console.log('Commodity added:', response);
            this.onSubmitted.emit();
          },
          error => {
            console.error('Error adding commodity:', error);
          }
        );
        break;
      default:
        console.error('Invalid modal type:', this.modalType);
        break;
    }

    // Emit the data to the parent component (if needed)
    // this.onSubmitted.emit(data);

    // Close the modal
    this.showModal = false;
  }


  getModalTitle(type: number): string {
    switch (type) {
      case 1: return 'Adicionar Segmento';
      case 2: return 'Adicionar Família';
      case 3: return 'Adicionar Classe';
      case 4: return 'Adicionar Mercadoria';
      default: return 'Adicionar Novo item';
    }
  }

  getModalFieldName(type: number): string {
    switch (type) {
      case 1: return 'Código Segmento';
      case 2: return 'Código Família';
      case 3: return 'Código Classe';
      case 4: return 'Código Mercadoria';
      default: return 'Item';
    }
  }
}
