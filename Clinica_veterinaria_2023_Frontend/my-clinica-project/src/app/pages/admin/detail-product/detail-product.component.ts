
import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';   // Replace with the actual path to your service
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';
import { UnspscService } from 'src/app/services/unspsc.service';
import { Unspsc } from 'src/app/models/unspsc.model';
import { ProductService } from 'src/app/services/product.service';
import { StockService } from 'src/app/services/stock.service';
import { ItemProductStockService } from 'src/app/services/itemProductStock.service';

interface Estoque {
  nome: string;
  habilitado: boolean;
}

export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-detail-user',
  templateUrl: './detail-product.component.html',
  styleUrls: ['./detail-product.component.scss']
})
export class DetailProductComponent {
  listUserGroup: { id: string, name: string }[] = [];
  userRole: any;
  //padding
  private paddingSubscription: Subscription;
  public containerPadding: string;


  createProductForm: FormGroup;
  file: File;
  preview: string;
  unspscCode:any
  productId: any;


  //DESCRIÇÃO UNSPSC

  estoques: any[] = [
    // ... outros estoques
  ];

  estoqueHabilitado: boolean = false;
  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService,
    private unspscService : UnspscService,
    private productService: ProductService,
    private route: ActivatedRoute,
    private stokeService: StockService,
    private itemProductStockService: ItemProductStockService
  ) {}

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get('id');

    this.productService.getProductByCode(this.productId).subscribe(res => {
      this.unspscService.getUnspscCodeById(res.idUnspsc).subscribe(data => {
          this.unspscCode = data;
          console.log(this.unspscCode)


          // Move the patchValue inside this inner subscription
          this.createProductForm.patchValue({
              productName: res.nome,
              purchasePrice: res.precoCompra,
              sellingPrice: res.precoVenda,
              productDescription: res.descricao,
              file: res.imagemBase64,
              unspsc: this.unspscCode.codigoSfcm // Now this should be populated
          });

          this.preview = 'data:image/jpeg;base64,' + res.imagemBase64; // Adjust as needed.
      }, error => {
          console.error('Error fetching UNSPSC code:', error);
          // Handle error as needed.
      });
  }, error => {
      console.error('Error fetching product:', error);
      // Handle error as needed.
  });

    this.createProductForm = this.fb.group({
      file: ['', Validators.required],
      productName: ['', Validators.required],
      purchasePrice: ['', [Validators.required, Validators.min(0)]],
      sellingPrice: ['', [Validators.required, Validators.min(0.01)]],
      productDescription: ['', Validators.required],
      unspsc:['',Validators.required]
      // Add similar form controls for all other form fields
      // ...
    });
    //padding
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
    //ROLE
    this.userRole = this.userService.getCurrentUser()
    //alert(this.userRole)


    this.loadEstoques();
  }


  handleFile(event: any): void {
    this.file = event.target.files[0] ?? null;

    const reader = new FileReader();
    reader.onload = (e: any) => {
        this.preview = e.target.result;
        const base64File = e.target.result.split(',')[1];
        this.createProductForm.patchValue({file: base64File});
    };
    reader.readAsDataURL(this.file);
  }
    loadUnspsc(idUnspsc:any): void {


}



submitForm(event?: Event): void {
  debugger
  const unspscControl = this.createProductForm.get('unspsc');
  console.log("TESTE" + unspscControl)
  event?.preventDefault();

  if (this.createProductForm.valid) {
    console.log('Formulário Enviado', this.createProductForm.value);
    console.log(this.file)

    this.productService.createOrUpdateStockItem(this.createProductForm.value).subscribe(
      (response) => {
        console.log('Product created!', response);

        // Alerta de sucesso
        Swal.fire({
          icon: 'success',
          title: 'Produto Criado',
          text: 'O produto foi criado com sucesso!',
          confirmButtonText: 'OK'
        });

        // Resetar o formulário
        this.createProductForm.reset();
        this.preview = null; // ou this.preview = '';
      },
      (error) => {
        console.log('Error creating product', error);

        // Alerta de erro
        Swal.fire({
          icon: 'error',
          title: 'Erro',
          text: 'Houve um erro ao criar o produto. Por favor, tente novamente.',
          confirmButtonText: 'OK'
        });
      }
    );
  } else {
    console.log('Formulário inválido');

    // Alerta de validação
    Swal.fire({
      icon: 'warning',
      title: 'Formulário Inválido',
      text: 'Por favor, corrija os erros no formulário antes de submeter.',
      confirmButtonText: 'OK'
    });
  }

}


// toggleEstoque(nomeEstoque: string): void {
//   this.estoques.forEach(estoque => {
//     estoque.habilitado = estoque.nome === nomeEstoque;
//   });

//   this.estoqueHabilitado = nomeEstoque;
// }

loadEstoques() {
  this.itemProductStockService.getEstoqueByProductId(this.productId).subscribe(
    data => {
      this.estoques = data;

      // Find the estoque with status = 1 and set it as selected
      const selectedEstoque = this.estoques.find(e => e.status === '1');
      this.estoqueSelecionado = selectedEstoque ? selectedEstoque.idEstoque : null;

      console.log(JSON.stringify(data));
    },
    error => {
      console.error('Erro ao carregar estoques:', error);
    }
  );
}

estoqueSelecionado: number;

atualizarPrioridadeDeEstoque(estoque: any): void {
  if (estoque) {
    console.log(JSON.stringify(estoque));

    debugger
    // Call your service to update the status
    this.itemProductStockService.updateEstoqueStatus(estoque.idEstoque, estoque.idProduto).subscribe(
      response => {
        // Handle the response
        console.log('Status updated successfully');
      },
      error => {
        // Handle the error
        console.error('Error updating status', error);
      }
    );
  }
}

  // Método para atualizar o produto
  atualizarProduto(produto: any): void {
    // Implemente a atualização do produto aqui, pode ser uma chamada de API ou atualização local
  }
}



