import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/core/user/user.service';
import { PaddingService } from 'src/app/services/Padding.service';

@Component({
  selector: 'app-tree-view-unspsc',
  templateUrl: './tree-view-unspsc.component.html',
  styleUrls: ['./tree-view-unspsc.component.scss']
})
export class TreeViewUnspscComponent {

  private paddingSubscription: Subscription;
  public containerPadding: string;


  constructor(
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService
  ) {}


  ngOnInit() {
    //padding
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

  }

}
