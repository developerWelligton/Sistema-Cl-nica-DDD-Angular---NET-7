import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaddingService {
  private globalPaddingSubject: BehaviorSubject<string> = new BehaviorSubject<string>('88px 16px 0px 128px');
  globalPadding$ = this.globalPaddingSubject.asObservable();

  setGlobalPadding(padding: string) {
    this.globalPaddingSubject.next(padding);
  }
}
