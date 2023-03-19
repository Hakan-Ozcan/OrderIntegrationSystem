import { Component, OnInit } from '@angular/core';
import { DataService } from './data-service.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { OrderUpdateModalComponent } from './order-update-modal/order-update-modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  modalRef!: BsModalRef;
  modalTitle: string = "Modal Başlığı";
  data: any;
  selectedOrder: number = 0;

  constructor(private dataService: DataService, private modalService: BsModalService) {
  }

  ngOnInit() {
    this.dataService.getData().subscribe((data: any) => {
      this.data = data;
      console.log('data', data);
    });
  }
  onOrderSelected(event: any) {
    this.selectedOrder = event.target.value;
    console.log('this.selectedOrder ', this.selectedOrder)
  }

  saveData() {
    const modalData = (this.modalRef?.content as OrderUpdateModalComponent)!.getData();
    console.log('modalData', modalData);
    this.modalRef?.hide();
  }
  
  openModal() {
    const modalOptions = {
      initialState: {
        title: this.modalTitle
      },
      class: 'modal-dialog-centered'
    };
    const modal = this.modalService.show(OrderUpdateModalComponent, modalOptions);
    this.modalRef = modal;
    this.modalRef.content.saveModal.subscribe(() => {
      this.saveData();
    });
  }
}