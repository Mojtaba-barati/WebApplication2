using System.Linq.Expressions;
using webmarket.Models;

namespace webmarket.AccesData.services
{

	public interface ishopingcard
	{

		public void Add(shopingcard entity);

		public IEnumerable<shopingcard> GetAll(string? id);

		shopingcard getFirstOrDefault(Expression<Func<shopingcard, bool>> filter);

		 public void remove(shopingcard entity);

		public  void removerange(IEnumerable<shopingcard> entities);

		public void update(shopingcard company);

		public int IncrementCount(shopingcard shopingcard, int count);

		 public int DecrementCount(shopingcard shopingcard, int count);

        public IEnumerable<shopingcard> getAll();
    }
}
