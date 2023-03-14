using BusinessLayer.Orders;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class OrderDataRepository : IOrderDataDal
    {
        private readonly Context _context;
        public OrderDataRepository(Context context)
        {
            _context=context;
        }



        public OrderData GetByID(int id)  //id ye göre bir sipariş verisi getir
        {
            return _context.Set<OrderData>().Where(x => x.SiparisID == id).SingleOrDefault();
        }

        public IEnumerable<OrderData> GetAll() //tüm sipariş verisini getir listele
        {
            return _context.Set<OrderData>().ToList();
            
        }

        public void Add(OrderData entity) // yeni siparişverisi ekle
        {
            _context.Set<OrderData>().Add(entity);
            _context.SaveChanges();
        }
        public void DeleteByID(int id)  //gelen parametreye göre sipariş verisini sil
        {
           var order= _context.Set<OrderData>().SingleOrDefault(x=>x.SiparisID==id);
            if (order!=null)
            {
                _context.Set<OrderData>().Remove(order);
                _context.SaveChanges();
            }
           
        }
        public void Update(OrderData entity)//gelen parametreye göre sipariş verisini güncelle
        {
            _context.Set<OrderData>().Update(entity);
            _context.SaveChanges();
        }

       
    }
}
