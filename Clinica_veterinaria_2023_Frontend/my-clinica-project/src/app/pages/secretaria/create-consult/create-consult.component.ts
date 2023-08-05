// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { ConsultService } from 'src/app/services/consult.service';

@Component({
  selector: 'app-create-consult',
  templateUrl: './create-consult.component.html',
  styleUrls: ['./create-consult.component.scss']
})
export class CreateConsultComponent {
  consultaForm: FormGroup;
  listVeterinarios = [
    { id: 1, name: 'Dr. Smith' },
    { id: 2, name: 'Dr. Jane' },
    { id: 3, name: 'Dr. Doe' }
    // ... add as many as you want
  ];
  listAnimals = [
    { id: 1, name: 'Buddy' },
    { id: 2, name: 'Milo' },
    { id: 3, name: 'Tiger' }
    // ... add as many as you want
  ];

  constructor(private fb: FormBuilder, private consultService: ConsultService) {}

  ngOnInit() {
    this.consultaForm = this.fb.group({
      descricao: [''],
      veterinario: [''],
      animal: [''],
      dataConsulta: ['']
    });
  }

  submitForm() {
    const formData = this.consultaForm.value;

    const payload = {
      dataConsulta: formData.dataConsulta,
      descricao: formData.descricao,
      iD_Veterinario: formData.veterinario.id,  // Assuming the veterinarian object has 'id' property
      iD_Animal: formData.animal.id  // Assuming the animal object has 'id' property
    };

    this.consultService.createConsulta(payload).subscribe(
      response => {
        console.log('Consulta created:', response);
        alert('Consulta successfully created!');
      },
      error => {
        console.error('There was an error:', error);
        alert('Error creating consulta!');
      }
    );
  }
}
