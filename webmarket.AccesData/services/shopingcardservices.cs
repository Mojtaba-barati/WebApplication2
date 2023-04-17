using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using webmarket.Models;
using webmarket.Models.viewModel;

namespace webmarket.AccesData.services
{
	public class shopingcardservices : ishopingcard
	{
		private readonly applicationDBcontext _db;
		public shopingcardservices(applicationDBcontext db)
		{
			_db = db;
		}

		public void Add(shopingcard entity)
		{
			_db.shopingcards.Add(entity);
			_db.SaveChanges();

		}



		public IEnumerable<shopingcard> GetAll(string? id)
		{
			IEnumerable<shopingcard> query = _db.shopingcards
				.Where(x => x.applicationuserid == id)
				.Include(p => p.product);
			return query;
		}

		public shopingcard getFirstOrDefault(Expression<Func<shopingcard, bool>> filter)
		{
			IQueryable<shopingcard> query = _db.shopingcards;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public int IncrementCount(shopingcard shopingcard, int count)
		{
			shopingcard.count += count;
			_db.SaveChanges();
			return shopingcard.count;
		}

		public int DecrementCount(shopingcard shopingcard, int count)
		{
			shopingcard.count -= count;
			_db.SaveChanges();
			return shopingcard.count;
		}

		public void remove(shopingcard entity)
		{
			_db.shopingcards.Remove(entity);
			_db.SaveChanges();
		}

		public void removerange(IEnumerable<shopingcard> entities)
		{
			_db.shopingcards.RemoveRange(entities);
			_db.SaveChanges();
		}

		public void update(shopingcard entity)
		{
			_db.shopingcards.Update(entity);
			_db.SaveChanges();
		}

        public IEnumerable<shopingcard> getAll()
        {
			IEnumerable<shopingcard> query = _db.shopingcards.Include(c=>c.product);
			return query;
        }
    }
}
