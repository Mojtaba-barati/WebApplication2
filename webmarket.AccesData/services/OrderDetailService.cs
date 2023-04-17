using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webmarket.Models;

namespace webmarket.AccesData.services
{
    public class OrderDetailService:IOrderDetailService
    {
        private readonly applicationDBcontext _db;
        public OrderDetailService(applicationDBcontext db)
        {
            _db = db;
        }

        public void Add(OrderDetails entity)
        {
            _db.orderDetails.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            IEnumerable<OrderDetails> query = _db.orderDetails;
            return query;
        }

        public OrderDetails GetFirstOrDefault(Expression<Func<OrderDetails, bool>> filter)
        {
            IQueryable<OrderDetails> query = _db.orderDetails;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(OrderDetails entity)
        {
            _db.orderDetails.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<OrderDetails> entities)
        {
            _db.orderDetails.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(OrderDetails orderDetails)
        {
            _db.orderDetails.Update(orderDetails);
            _db.SaveChanges();
        }
    }
}
