import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';
import { Cliente } from 'src/app/models/cliente.model';
import { ClienteService } from 'src/app/services/cliente.service';
import Swal from 'sweetalert2';
import { AnimalService } from 'src/app/services/animal.service';
import { DataService } from 'src/app/services/data.service';
import { Segmento } from 'src/app/models/segmento.model';
import { Familia } from 'src/app/models/familia.model';
import { Classe } from 'src/app/models/classe.model';
import { Mercadoria } from 'src/app/models/mercadoria.model';
import { HttpClient } from '@angular/common/http';
import { UnspscService } from 'src/app/services/unspsc.service';
import { ModalUnspscComponent } from 'src/app/components/modal-unspsc/modal-unspsc.component';



export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}



@Component({
  selector: 'app-create-cliente',
  templateUrl: './create-cliente.component.html',
  styleUrls: ['./create-cliente.component.scss']
})
export class CreateClienteComponent {

  @ViewChild('modalComponent') modalComponent: ModalUnspscComponent;

  createUnspscForm: FormGroup;

  //fazer os tipos
  segmentos: Segmento[] = [];
  familias: Familia[] = [];
  classes: Classe[] = [];
  mercadorias: Mercadoria[] = [];
  unspscCode = '';

  exists = false;




  //
  nomeFormGroup = this.fb.group({
    nomeCtrl: ['', Validators.required],
  });

  cnpjCpfFormGroup = this.fb.group({
    cnpjCpfCtrl: ['', Validators.required],
  });

  telefoneFormGroup = this.fb.group({
    telefoneCtrl: ['', Validators.required],
  });
  emailFormGroup = this.fb.group({
    emailCtrl: ['', Validators.required],
  });
 //

  isLinear = false;
  constructor(
    private fb: FormBuilder,
    private dataService: DataService,
    private unspscService: UnspscService,
    private router: Router,
    private clienteService: ClienteService
  ) {}

  ngOnInit() {

    this.loadSegmentos();
    this.loadFamilias();
    this.loadClasses();
    this.loadMercadorias();

    this.createUnspscForm = this.fb.group({
      segmento: [''],
      familia: [''],
      classe: [''],
      mercadoria: [''],
    });
      //RECARREGAR QUANDO MODAL FOR ADICIONADO
      this.modalComponent.onSubmitted.subscribe(() => {
        // Recarregar segmentos quando um novo segmento é adicionado
        this.loadSegmentos();
        this.loadFamilias();
        this.loadClasses();
        this.loadMercadorias();
      });
  }

    ngAfterViewInit() {
    // Assegure-se de que a visualização do modal foi inicializada
    this.modalComponent.onSubmitted.subscribe(() => {
      // Recarregar segmentos quando um novo segmento é adicionado
      this.loadSegmentos();
      this.loadFamilias();
      this.loadClasses();
      this.loadMercadorias();
    });
  }


  loadSegmentos(): void {
    this.dataService.getSegmentos().subscribe(
      (data: Segmento[]) => {
        console.log('Data received:', data);
        this.segmentos = data; // Atualiza a lista de segmentos
      },
      error => {
        console.error('Error:', error);
      }
    );
  }


  loadFamilias(): void {
    this.dataService.getFamilias().subscribe(
      (data: Familia[]) => {
        console.log('Data received:', data);
        this.familias = data;  // Atualiza a lista de clientes
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  loadClasses(): void {
    this.dataService.getClasses().subscribe(
      (data: Classe[]) => {
        console.log('Data received:', data);
        this.classes = data;  // Atualiza a lista de clientes
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  loadMercadorias(): void {
    this.dataService.getMercadorias().subscribe(
      (data: Mercadoria[]) => {
        console.log('Data received:', data);
        this.mercadorias = data;  // Atualiza a lista de clientes
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  checkIfUnspscCodeExists(): void {
    this.unspscService.checkIfUnspscCodeExists(this.unspscCode).subscribe(
      exists => {
        this.exists = exists;
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  onValueChange(): void {
    const formValues = this.createUnspscForm.value;

    const segmentoCodigo = formValues.segmento?.codigo ?? 'XX';
    const familiaCodigo = formValues.familia?.codigo ?? 'XX';
    const classeCodigo = formValues.classe?.codigo ?? 'XX';
    const mercadoriaCodigo = formValues.mercadoria?.codigo ?? 'XX';

    this.unspscCode =
      `${segmentoCodigo}-` +
      `${familiaCodigo}-` +
      `${classeCodigo}-` +
      `${mercadoriaCodigo}`;
  }

  submitForm(): void {
    if (this.createUnspscForm.valid) {
        this.onValueChange();

        const formData = this.createUnspscForm.value;
        const payload = {
            codigoSfcm: this.unspscCode,
            iD_Usuario: 1,  // Ajuste conforme necessário
            idSegmento: formData.segmento.idSegmento,
            idFamilia: formData.familia.idFamilia,
            idClasse: formData.classe.idClasse,
            idMercadoria: formData.mercadoria.idMercadoria
        };

        // Verificar se o código UNSPSC já existe
        this.unspscService.checkIfUnspscCodeExists(this.unspscCode).subscribe(
            exists => {
                if (exists) {
                    // Mostrar alerta se o código UNSPSC já existe
                    Swal.fire({
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'The UNSPSC Code already exists. Please choose a different code.',
                    });
                } else {
                    // Se não existir, criar o novo código UNSPSC
                    this.unspscService.createUnspscCode(payload).subscribe(
                        response => {
                            console.log('API response:', response);
                            // Informe o usuário sobre o sucesso
                            Swal.fire({
                                icon: 'success',
                                title: 'Success',
                                text: 'Data sent successfully!',
                            });
                            // Resetar o formulário após o envio bem-sucedido
                            this.createUnspscForm.reset();
                            this.unspscCode=''

                        },
                        error => {
                            console.error('API error:', error);
                            // Informe o usuário sobre o erro
                            Swal.fire({
                                icon: 'error',
                                title: 'Error',
                                text: 'Failed to send data!',
                            });
                        }
                    );
                }
            },
            error => {
                console.error('API error:', error);
                // Informe o usuário sobre o erro
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Failed to check UNSPSC Code existence!',
                });
            }
        );
    } else {
        console.error('Form is invalid');
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'The form is invalid. Please check your input and try again.',
        });
    }
}


  openModal(type: number) {
    this.modalComponent.open(type); // Call a method 'open' on the child component
  }

  handleSubmittedData(data) {
    console.log('Submitted data:', data);
    // Handle the data based on the type
    switch (data.type) {
      case 1:
        // Handle Segment data
        break;
      case 2:
        // Handle Family data
        break;
      case 3:
        // Handle Class data
        break;
      case 4:
        // Handle Commodity data
        break;
      default:
        // Handle unknown type
        break;
    }
  }

  deleteSegmento(index: number, event: Event) {
    event.stopPropagation(); // Impede que o ng-select altere seu valor ao clicar no botão de excluir

   alert(index)

    // Talvez você queira emitir algum evento ou fazer uma chamada de serviço aqui para persistir a exclusão no backend
  }

  deleteFamilia(index: number, event: Event) {
    event.stopPropagation(); // Impede que o ng-select altere seu valor ao clicar no botão de excluir

    alert(index)
  }

  deleteClasse(index: number, event: Event) {
    event.stopPropagation();

  }

  deleteMercadoria(index: number, event: Event) {
    event.stopPropagation(); // Previne que o ng-select altere seu valor ao clicar no botão de excluir

  }


  finalizarCadastro() {
    // Verificando se todos os formulários estão válidos
    if (this.nomeFormGroup.valid &&
        this.cnpjCpfFormGroup.valid &&
        this.telefoneFormGroup.valid && this.emailFormGroup.valid ) {

        // Coletando os valores dos formulários, já que todos estão válidos
        const nome = this.nomeFormGroup.get('nomeCtrl').value;
        const cnpjCpf = this.cnpjCpfFormGroup.get('cnpjCpfCtrl').value;
        const telefone = this.telefoneFormGroup.get('telefoneCtrl').value;
        const email = this.emailFormGroup.get('emailCtrl').value;


        const payload = {
          nome: nome, // Assuming 'nome' is a variable containing the client's name
          cpF_CNPJ: cnpjCpf, // Assuming 'cnpjCpf' is a variable containing the CPF or CNPJ number
          endereco: "", // Replace with actual address or keep as a variable
          email: email, // Assuming 'email' is a variable containing the client's email
          telefoneFixo: "", // Replace with actual fixed telephone number or keep as a variable
          telefoneMovel: telefone, // Assuming 'telefone' is a variable containing the mobile phone number
          cep: "", // Replace with actual CEP or keep as a variable
          bairro: "", // Replace with actual neighborhood or keep as a variable
          cidade: "", // Replace with actual city or keep as a variable
          uf: "", // Replace with actual UF or keep as a variable
          complemento: "", // Replace with actual complement or keep as a variable
          inscricaoMunicipal: "", // Replace with actual municipal registration or keep as a variable
          inscricaoEstadual: "", // Replace with actual state registration or keep as a variable
          iD_Usuario: 1, // Replace with actual user ID or keep as a variable
          observacoes: "", // Replace with actual observations or keep as a variable
          grupo: "", // Replace with actual group or keep as a variable
          empresa: "", // Replace with actual company name or keep as a variable
          notificacaoDesabilitada: true, // Replace with actual notification status or keep as a variable
          emailsAdicionais: "" // Replace with actual additional emails or keep as a variable
        };

        this.clienteService.addCliente(payload).subscribe({
          next: (res) => {
            // Display a success message using SweetAlert2
            Swal.fire({
              title: 'Success!',
              text: 'Cadastro realizado com sucesso!',
              icon: 'success',
              confirmButtonText: 'Ok'
            });
        this.nomeFormGroup.reset();
        this.cnpjCpfFormGroup.reset();
        this.telefoneFormGroup.reset() ;
        this.emailFormGroup.reset();
          },
          error: (err) => {
            // Handle any errors here, maybe show a SweetAlert2 error message
            Swal.fire({
              title: 'Error!',
              text: 'Houve um erro no cadastro.',
              icon: 'error',
              confirmButtonText: 'Ok'
            });
            console.error(err);
          }
        });
    } else {
      Swal.fire({
        title: 'Atenção!',
        text: 'Por favor, preencha todos os campos corretamente.',
        icon: 'warning',
        confirmButtonText: 'Ok'
      });
    }
  }



}
