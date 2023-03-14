using BusinessLayer.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderDataService
    {
        OrderData GetOrderDataByCustomerOrderId(int customerOrderId);
        OrderData GetOrderData(int id);
        List<OrderData> GetOrderDatas();
        void OrderDataAdd(OrderData orderData);
        void OrderDataRemove(int id);
        void OrderDataUpdate(OrderData orderData);
    }
}
