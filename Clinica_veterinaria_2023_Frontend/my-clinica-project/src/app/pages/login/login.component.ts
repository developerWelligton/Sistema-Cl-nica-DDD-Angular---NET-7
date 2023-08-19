import { AuthService } from './../../services/auth.service';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  isLoading = false;
  constructor(
    public formBuilder: FormBuilder,
    private router:Router,
    private loginService:LoginService,
    public authService:AuthService,
    private cdr: ChangeDetectorRef
    ){
  }

  loginForm: FormGroup;
  //
  showAlert = false; // indica se o alerta deve ser exibido ou não
alertMessage = ''; // a mensagem do alerta
alertType = 'primary'; // 'primary' para sucesso, 'danger' para erro

  ngOnInit():void{
    this.loginForm = this.formBuilder.group({
      email:['',[Validators.required, Validators.email]],
      senha:['',[Validators.required]]
    })
    this.cdr.detectChanges(); // força a detecção de mudança
  }

  get dadosForm(){
    return this, this.loginForm.controls;
  }

  loginUser() {
    this.isLoading = true;

    this.loginService.login(this.dadosForm["email"].value, this.dadosForm["senha"].value).subscribe(
        token => {
            this.authService.setToken(token);
            this.authService.UsuarioAutenticado(true);
            this.router.navigate(['/dashboard']);
            this.isLoading = false;

            // Mostrar alerta de sucesso
            // this.showAlert = true;
            // this.alertType = 'success';
            // this.alertMessage = 'Login realizado com sucesso!';

            // Esconder alerta após 3 segundos
            setTimeout(() => {
                this.showAlert = false;
            }, 3000);
        },
        err => {
            this.router.navigate(['/login']);
            this.isLoading = false;

            // Mostrar alerta de erro
            this.showAlert = true;
            this.alertType = 'danger';
            this.alertMessage = 'Erro ao fazer login, verifique suas credenciais.';

            // Esconder alerta após 3 segundos
            setTimeout(() => {
                this.showAlert = false;
            }, 3000);
        }
    );
  }


  

  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'determinate';
  value = 50;

  
}
