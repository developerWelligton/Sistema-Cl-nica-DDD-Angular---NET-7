import { AuthService } from './../../services/auth.service';
import { Component } from '@angular/core';
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

  constructor(
    public formBuilder: FormBuilder,
    private router:Router,
    private loginService:LoginService,
    public authService:AuthService
    ){
  }

  loginForm: FormGroup;

  ngOnInit():void{
    this.loginForm = this.formBuilder.group({
      email:['',[Validators.required, Validators.email]],
      senha:['',[Validators.required]]
    })
  }

  get dadosForm(){
    return this, this.loginForm.controls;
  }

  loginUser() {
    this.isLoading = true;  // Mostrar spinner
  
    this.loginService.login(this.dadosForm["email"].value, this.dadosForm["senha"].value).subscribe(
      token => {
        debugger
        this.authService.setToken(token);
        this.authService.UsuarioAutenticado(true);
        this.router.navigate(['/dashboard']);
        this.isLoading = false;  // Esconder spinner
      },
      err => {
        debugger
        //alert("Ocorreu um erro");
        this.router.navigate(['/login']);
        this.isLoading = false;  // Esconder spinner
      }
    );
  }
  

  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'determinate';
  value = 50;

  isLoading = false; 
}
