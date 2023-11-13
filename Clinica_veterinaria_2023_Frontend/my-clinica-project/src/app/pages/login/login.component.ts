import { AuthService } from '../../core/auth/auth.service';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/user/user.service';
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
    private cdr: ChangeDetectorRef,
    private userService: UserService
    ){
  }

  loginForm: FormGroup;
  //
  showAlert = false; // indica se o alerta deve ser exibido ou não
alertMessage = ''; // a mensagem do alerta
alertType = 'primary'; // 'primary' para sucesso, 'danger' para erro


user:any
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

    this.authService.authenticate(this.dadosForm["email"].value, this.dadosForm["senha"].value).subscribe(
      ()=> {
        this.router.navigate(['/dashboard'])
        console.log("Authenticed")
        this.isLoading = false;
        this.loginForm.reset();
      } ,
      err => {
        console.log(err)
        this.isLoading = false;
      }
    )

  }

  email = new FormControl('', [Validators.required, Validators.email]);

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  hide = true;
}
