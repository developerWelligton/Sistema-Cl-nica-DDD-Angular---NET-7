import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalSidebarService {
  private isExpanded = false;

  constructor() { }

  toggle(): boolean {
    this.isExpanded = !this.isExpanded;
    return this.isExpanded;
  }

  getState(): boolean {
    return this.isExpanded;
  }

  setState(state: boolean): void {
    this.isExpanded = state;
  }
}
