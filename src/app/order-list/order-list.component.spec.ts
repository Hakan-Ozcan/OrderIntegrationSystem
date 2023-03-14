import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderListComponent } from './order-list.component';

editStatus(order: Order) {
  const dialogRef = this.dialog.open(EditStatusDialogComponent, {
    data: {order}
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      this.orderService.updateOrderStatus(order.id, result).subscribe(updatedOrder => {
        const index = this.orders.findIndex(o => o.id === updatedOrder.id);
        this.orders[index] = updatedOrder;
      });
    }
  });
}
describe('OrderListComponent', () => {
  let component: OrderListComponent;
  let fixture: ComponentFixture<OrderListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

