export interface Order {
    id: number;
    customerName: string;
    orderDate: string;
    paymentType: string;
    status: string;
    editable?: boolean;
  }