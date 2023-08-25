// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { UserService } from 'src/app/core/user/user.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { AnimalService } from 'src/app/services/animal.service';
import { ConsultService } from 'src/app/services/consult.service';
import { VeterinarioService } from 'src/app/services/veterinario.service';
interface Veterinario {
  iD_Veterinario: number;
  nome: string;
}
@Component({
  selector: 'app-create-consult',
  templateUrl: './create-consult.component.html',
  styleUrls: ['./create-consult.component.scss']
})
export class CreateConsultComponent {
  consultaForm: FormGroup;

  // Assume you have a listStatus array like this:


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

  constructor(
    private fb: FormBuilder,
    private consultService: ConsultService,
    private animalService: AnimalService,
    private vetService: VeterinarioService  // Inject VeterinarioService
    ,private paddingService: PaddingService,
    private userService:UserService
  ) {}

  ngOnInit() {
    //padding sidebar
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
      //alert(this.containerPadding)
    });

    const currentUser = this.userService.getUserId();
    if (currentUser) {
      console.log('User ID:', currentUser)
    } else {
      console.log('User not logged in');
    }

    this.consultaForm = this.fb.group({
      descricao: [''],
      veterinario: [''],
      animal: [''],
      dataConsulta: [''],  // This field is now optional
      dataMarcacao: [''],
      inicioConsulta: [''],
      fimConsulta: [''],
      status: [''],
      id_Usuario:[currentUser.iD_Usuario]
    });

    this.animalService.getAllAnimals().subscribe(
      (animals: any[]) => {
        this.listAnimals = animals.map(animal => ({
          id: animal.iD_Animal,
          name: animal.nome
        }));
      },
      error => {
        console.error('Error fetching animals:', error);
      }
    );

    // Fetch list of veterinarians
    this.vetService.getAllVets().subscribe(
      (vets: any[]) => {
        this.listVeterinarios = vets.map(vet => ({
          id: vet.iD_Veterinario,
          name: vet.nome
        }));
      },
      error => {
        console.error('Error fetching veterinarians:', error);
      }
    );
  }


//SELECT ANIMAL
onSearchAni(term: string) {
  if (term) {
      this.animalService.searchAnimals(term).subscribe(
          (animals: any[]) => {
              this.listAnimals = animals.map(animal => ({
                  id: animal.iD_Animal,
                  name: animal.nome
              }));
          },
          error => {
              console.error('Error fetching animals:', error);
          }
      );
  }
}


//SELECT VETERIONÁRIO
onSearchVet(term: string) {
  if (term) {
      this.vetService.searchVeterinarios(term).subscribe(
          (vetz: any[]) => {
              this.listVeterinarios = vetz.map(vet => ({
                  id: vet.iD_Veterinario,
                  name: vet.nome
              }));
          },
          error => {
              console.error('Error fetching vetz:', error);
          }
      );
  }
}


submitForm() {
  debugger
  const formData = this.consultaForm.value;

  const payload = {
    dataMarcacao: formData.dataMarcacao,
    inicioConsulta: formData.inicioConsulta,
    fimConsulta: formData.fimConsulta,
    descricao: formData.descricao,
    iD_Veterinario: formData.veterinario.id,
    iD_Animal: formData.animal.id,
    status: 0,
    id_Usuario:formData.id_Usuario
  };

  this.consultService.createConsulta(payload).subscribe(
    response => {
      console.log('Consulta created:', response);
      alert('Consulta successfully created!');

      // Reset the form after successful submission
      this.consultaForm.reset();
    },
    error => {
      console.error('There was an error:', error);
      alert('Error creating consulta!');
    }
  );
}



public containerPadding: string;
}
