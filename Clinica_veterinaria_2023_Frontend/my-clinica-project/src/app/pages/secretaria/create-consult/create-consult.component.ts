import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

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

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.consultaForm = this.fb.group({
      descricao: [''],
      veterinario: [''],
      animal: [''],
      dataConsulta: ['']
    });
  }

  submitForm() {
    alert(JSON.stringify(this.consultaForm.value));
    console.log(this.consultaForm.value);
  }
}
