using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webmarket.Models;
using webmarket.Models.viewModel;

namespace webmarket.AccesData.services
{
	public interface iproductsservices
	{
		public void Add(productvm entity);

		public void remove(product entity);
		public void update(productvm entity);

		public void removerange(IEnumerable<product> entities);

		public product getFirstOrDefault(Expression<Func<product, bool>> predicate);


		public IEnumerable<product> GetAll();


	}
}
