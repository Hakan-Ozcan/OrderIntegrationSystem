import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../orders.service';
constructor(private orderService: OrderService) {}

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})

export class OrderListComponent implements OnInit {
  orders: Order[] = [];

  constructor(private orderService: OrdersService) {}

  ngOnInit(): void {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders;
    });
  }
}
