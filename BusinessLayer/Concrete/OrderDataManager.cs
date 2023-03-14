using BusinessLayer.Abstract;
using BusinessLayer.Orders;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderDataManager : IOrderDataService
    {
        IOrderDataDal _orderDataDal;
        public OrderDataManager(IOrderDataDal orderDataDal)
        {
            _orderDataDal = orderDataDal;
        }

        public OrderData GetOrderData(int id)
        {
            return _orderDataDal.GetByID(id);
        }

        public OrderData GetOrderDataByCustomerOrderId(int customerOrderId)
        {
            return _orderDataDal.GetAll().FirstOrDefault(o => o.MusteriSiparisNo == customerOrderId);
        }

        public List<OrderData> GetOrderDatas()
        {
            return (List<OrderData>)_orderDataDal.GetAll();
        }

        public void OrderDataAdd(OrderData orderData)
        {
           
            _orderDataDal.Add(orderData);

        }

        public void OrderDataRemove(int id)
        {
            _orderDataDal.DeleteByID(id);
        }

        public void OrderDataUpdate(OrderData orderData)
        {
            _orderDataDal.Update(orderData);
        }
    }
}
