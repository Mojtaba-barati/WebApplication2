using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webmarket.Models;

namespace webmarket.AccesData.services
{

	public  interface icompany
	{
		public void Add(company entity);

		public IEnumerable<company> GetAll();

		company getFirstOrDefault(Expression<Func<company, bool>> filter);

		void remove(company entity);

		void removerange(IEnumerable<company> entities);

		void update(company company);
	}
}
