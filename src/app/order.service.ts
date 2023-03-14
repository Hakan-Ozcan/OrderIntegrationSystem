import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'http://localhost:3000/orders';

  constructor(private http: HttpClient) {}

  // ...

  updateOrderStatus(orderId: number, newStatus: string): Observable<any> {
    const url = `${this.apiUrl}/${orderId}`;
    const body = { status: newStatus };
    return this.http.put(url, body);
  }
}