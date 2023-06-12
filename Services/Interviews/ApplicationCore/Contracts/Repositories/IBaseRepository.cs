using System;
using System.Linq.Expressions;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IBaseRepository<T> where T:class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> AddSync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<int> DeleteAsync(int id);
	}
}

