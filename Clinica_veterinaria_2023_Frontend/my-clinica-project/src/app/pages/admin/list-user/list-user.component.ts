// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';


export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.scss']
})
export class ListUserComponent {

  usersList = new MatTableDataSource<any>();
  displayedColumns: string[] = ['id', 'name', 'email', 'role'];
  listUserGroup: { id: string, name: string }[] = [];

  // Mocked Data
  MOCK_DATA = [
    {iD_Usuario: 1, nome: 'John Doe', email: 'john@example.com', role: 'admin'},
    {iD_Usuario: 2, nome: 'Jane Smith', email: 'jane@example.com', role: 'cliente'},
    {iD_Usuario: 3, nome: 'Robert Brown', email: 'robert@example.com', role: 'veterinario'},
    {iD_Usuario: 4, nome: 'Emily Davis', email: 'emily@example.com', role: 'secretaria'},
    {iD_Usuario: 5, nome: 'Michael Johnson', email: 'michael@example.com', role: 'cliente'},
    {iD_Usuario: 6, nome: 'Sarah Wilson', email: 'sarah@example.com', role: 'admin'},
    {iD_Usuario: 7, nome: 'James Lee', email: 'james@example.com', role: 'veterinario'},
    {iD_Usuario: 8, nome: 'Jessica Turner', email: 'jessica@example.com', role: 'cliente'},
    {iD_Usuario: 9, nome: 'William Taylor', email: 'william@example.com', role: 'admin'},
    {iD_Usuario: 10, nome: 'Emma Hall', email: 'emma@example.com', role: 'secretaria'},
    {iD_Usuario: 11, nome: 'David Clark', email: 'david@example.com', role: 'veterinario'},
    {iD_Usuario: 12, nome: 'Sophia Wright', email: 'sophia@example.com', role: 'cliente'},
    {iD_Usuario: 13, nome: 'Lucas Evans', email: 'lucas@example.com', role: 'admin'},
    {iD_Usuario: 14, nome: 'Mia Thomas', email: 'mia@example.com', role: 'secretaria'},
    {iD_Usuario: 15, nome: 'Benjamin Green', email: 'benjamin@example.com', role: 'veterinario'},
    {iD_Usuario: 16, nome: 'Olivia King', email: 'olivia@example.com', role: 'cliente'},
    {iD_Usuario: 17, nome: 'Henry Adams', email: 'henry@example.com', role: 'admin'},
    {iD_Usuario: 18, nome: 'Chloe Baker', email: 'chloe@example.com', role: 'secretaria'},
    {iD_Usuario: 19, nome: 'Liam Nelson', email: 'liam@example.com', role: 'veterinario'},
    {iD_Usuario: 20, nome: 'Isabella Lewis', email: 'isabella@example.com', role: 'cliente'}
  ];

  ngOnInit() {
    this.usersList.data = this.MOCK_DATA;
    this.populateUserGroups();
  }

  private populateUserGroups(): void {
    this.listUserGroup = Object.values(UserGroup).map(group => ({
        id: group,
        name: group
    }));
    console.log(this.listUserGroup); // Check the output
 }

  // Original user list
  originalUserList: any[] = this.MOCK_DATA;


  applyFilter(name: string, email: string, role: string): void {
    const nameFilterValue = name.trim().toLowerCase();
    const emailFilterValue = email.trim().toLowerCase();
    const roleFilterValue = role.trim().toLowerCase();


  }
}
