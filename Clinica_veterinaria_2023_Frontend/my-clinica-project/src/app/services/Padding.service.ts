// src/app/services/Padding.service.ts

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaddingService {

  private _globalPadding = new BehaviorSubject<string>('88px 16px 0px 124px'); // valor inicial

  // Observable que os componentes podem assinar
  public globalPadding$ = this._globalPadding.asObservable();

  constructor() { }

  setGlobalPadding(padding: string) {
    this._globalPadding.next(padding);
  }
}
