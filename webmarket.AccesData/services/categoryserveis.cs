using webmarket.Models;
using System.Linq.Expressions;
using webmarket.AccesData.services;
using Microsoft.EntityFrameworkCore;





namespace webmarket.AccesData.services
{
    public class categoryserveis  : ipcategory
	{
        public readonly applicationDBcontext _db;

        public categoryserveis(applicationDBcontext db)
        {
            _db = db;
        }

        public void Add(catigory entity)
        {
            _db.categories.Add(entity);
            _db.SaveChanges();
        }
        public IEnumerable<catigory> GetAll()
        {
            IEnumerable<catigory> quray = _db.categories;
            return quray;

        }
        public catigory getFirstOrDefault(Expression<Func<catigory, bool>> filter)
        {
           IQueryable<catigory> query = _db.categories;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public void remove(catigory entity)
        {
            _db.categories.Remove(entity);
            _db.SaveChanges();
        }
        public void removerange(IEnumerable<catigory> entities)
        {
            _db.categories.RemoveRange(entities);
            _db.SaveChanges();
        }
       
        public void update(catigory catigory)
        {
            _db.categories.Update(catigory);
			_db.SaveChanges();
		}
        
    }
}
