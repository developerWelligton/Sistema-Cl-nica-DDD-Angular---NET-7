import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';


const CLOUD = 'http://localhost:3000/imgs/';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {
  private _url = '';

  @Input() description='';

  @Input() set url(url: string)  {
      if(!url.startsWith('data')) {
          this._url = CLOUD + url;
      } else {
          this._url = url;
      }
  }

  get url() {
      return this._url;
  }

}
