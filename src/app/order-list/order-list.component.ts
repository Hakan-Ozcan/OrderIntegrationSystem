import { Component, OnInit } from '@angular/core';
import { Order } from '../order';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders: Order[] = [];

  constructor(private orderService: OrderService) {}

  ngOnInit() {
    this.getOrders();
  }

  getOrders(): void {
    this.orderService.getOrders().subscribe((orders) => (this.orders = orders));
  }

  onEdit(order: Order): void {
    order.editable = true;
  }

  onCancelEdit(order: Order): void {
    order.editable = false;
  }

  onStatusChange(order: Order, newStatus: string): void {
    order.status = newStatus;
    order.editable = false;
    this.orderService.updateOrderStatus(order.id, order.status).subscribe();
  }
}