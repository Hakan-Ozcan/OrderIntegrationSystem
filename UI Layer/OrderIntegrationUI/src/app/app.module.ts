import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { DataService } from './data-service.service';
import { OrderUpdateModalComponent } from './order-update-modal/order-update-modal.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// ngx-bootstrap
import { AlertModule } from 'ngx-bootstrap/alert';
import { BsModalRef, BsModalService, ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [
    AppComponent,
    OrderUpdateModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    // ngx-bootstrap
    AlertModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [
    DataService,
    BsModalService,
    // Burada BsModalRef sağlayıcısını da ekliyoruz
    {
      provide: BsModalRef,
      useValue: {}
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
