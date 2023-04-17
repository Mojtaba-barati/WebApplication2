using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webmarket.Models;

namespace webmarket.AccesData.services
{
    public class OrderHeaderService : IOrderHeaderService
    {
        private readonly applicationDBcontext _db;
        public OrderHeaderService(applicationDBcontext db)
        {
            _db = db;
        }

        public void Add(OrderHeader entity)
        {
            _db.orderHeaders.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            IEnumerable<OrderHeader> query = _db.orderHeaders;
            return query;
        }

        public OrderHeader GetFirstOrDefault(Expression<Func<OrderHeader, bool>> filter)
        {
            IQueryable<OrderHeader> query = _db.orderHeaders;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(OrderHeader entity)
        {
            _db.orderHeaders.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<OrderHeader> entities)
        {
            _db.orderHeaders.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(OrderHeader orderHeader)
        {
            _db.orderHeaders.Update(orderHeader);
            _db.SaveChanges();
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.Id == id);

            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (paymentStatus != null)
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }

        }

    }
}
