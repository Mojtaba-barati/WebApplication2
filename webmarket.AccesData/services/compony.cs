using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webmarket.Models;

namespace webmarket.AccesData.services
{
	public class compony : icompany
	{
		private readonly applicationDBcontext db;

		public compony(applicationDBcontext db)
		{
			this.db = db;
		}


		public void Add(company entity)
		{
			db.companys.Add(entity);
			db.SaveChanges();
		}

		public IEnumerable<company> GetAll()
		{
			IEnumerable<company> quray = db.companys;
			return quray;
		}

		public company getFirstOrDefault(Expression<Func<company, bool>> filter)
		{
			IQueryable<company> query = db.companys;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public void remove(company entity)
		{
			db.companys.Remove(entity);
			db.SaveChanges();
		}

		public void removerange(IEnumerable<company> entities)
		{
			db.companys.RemoveRange(entities);
			db.SaveChanges();
		}

		public void update(company company)
		{
			db.companys.Update(company);
			db.SaveChanges();
		}
	}
}
