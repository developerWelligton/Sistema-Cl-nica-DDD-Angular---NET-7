// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { AnimalService } from 'src/app/services/animal.service';
import { ConsultService } from 'src/app/services/consult.service';
import { VeterinarioService } from 'src/app/services/veterinario.service';
interface Veterinario {
  iD_Veterinario: number;
  nome: string;
}
@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.scss']
})
export class CreateUserComponent {

  constructor(
    private fb: FormBuilder,
  ) {}

  ngOnInit() {

  }

}
