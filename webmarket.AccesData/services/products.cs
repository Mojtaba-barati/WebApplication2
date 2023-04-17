using webmarket.Models;
using System.Linq.Expressions;
using webmarket.AccesData.services;
using Microsoft.EntityFrameworkCore;
using webmarket.Models.viewModel;

namespace webmarket.AccesData.services
{
    public class products: iproductsservices
    {
        private readonly applicationDBcontext _db;

        public products(applicationDBcontext db)
        {
            _db = db;
        }

        public void Add(productvm entity)
        {
            _db.products.Add(entity.product);
            _db.SaveChanges();
        }
        public IEnumerable<product> GetAll()
        {
            IEnumerable<product> products = _db.products.Include(c => c.category);
            return products;

        }
        public product getFirstOrDefault(Expression<Func<product, bool>> filter)
        {
           IQueryable<product> query = _db.products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public void remove(product entity)
        {
            _db.products.Remove(entity);
            _db.SaveChanges();
        }
        public void removerange(IEnumerable<product>entities)
        {
            _db.products.RemoveRange(entities);
            _db.SaveChanges();
        }
        public void update(productvm obj)
        {
           var objproducts=_db.products.FirstOrDefault(x=>x.Id == obj.product.Id);
            if (objproducts != null)
            {
                objproducts.title = obj.product.title;
                objproducts.Description = obj.product.Description;
                objproducts.isbn = obj.product.isbn;
                objproducts.another = obj.product.another;
                objproducts.listprice = obj.product.listprice;
                objproducts.price = obj.product.price;
                objproducts.price50 = obj.product.price50;
                objproducts.price100 =  obj.product.price100;
                objproducts.imgurl = obj.product.imgurl;
                objproducts.categoryid = obj.product.categoryid;
                _db.SaveChanges();



            }
        }
        
    }
}
