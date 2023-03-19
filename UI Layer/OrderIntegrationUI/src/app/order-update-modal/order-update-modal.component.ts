import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-order-update-modal',
  templateUrl: './order-update-modal.component.html',
  styleUrls: ['./order-update-modal.component.scss']
})
export class OrderUpdateModalComponent implements OnInit {
  @Output() saveModal = new EventEmitter();

  orderData: any;

  constructor() {}

  ngOnInit() {}

  onSave() {
    // save the data
    this.saveModal.emit();
  }

  getData() {
    return this.orderData;
  }
}