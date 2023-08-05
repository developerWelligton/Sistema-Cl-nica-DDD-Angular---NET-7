import { Component } from '@angular/core';

@Component({
  selector: 'app-create-consult',
  templateUrl: './create-consult.component.html',
  styleUrls: ['./create-consult.component.scss']
})
export class CreateConsultComponent {
  selectedVeterinario: any;
  listVeterinarios = [
    { id: 1, name: 'Dr. Smith' },
    { id: 2, name: 'Dr. Johnson' },
    // ... you can add more veterinarios here
  ];

  selectedAnimal: any;
  listAnimals = [
    { id: 1, name: 'Tiger' },
    { id: 2, name: 'Lion' },
    // ... you can add more animals here
  ];
}
