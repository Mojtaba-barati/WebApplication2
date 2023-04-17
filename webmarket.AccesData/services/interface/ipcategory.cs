using System.Linq.Expressions;
using webmarket.Models;

namespace webmarket.AccesData.services
{

	public interface ipcategory
	{
		public void Add(catigory entity);

		public IEnumerable<catigory> GetAll();

		catigory getFirstOrDefault(Expression<Func<catigory, bool>> filter);

	    void remove(catigory entity);

		 void removerange(IEnumerable<catigory> entities);

		void update(catigory catigory);


	}
}
