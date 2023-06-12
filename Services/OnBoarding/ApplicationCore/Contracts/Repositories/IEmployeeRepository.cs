using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface  IEmployeeRepository:IBaseRepository<Employee>
	{
		Task<List<Employee>> GetAllEmployees();

		Task<List<Employee>> GetEmployeesByPagination(int skipCount, int pageSize);

		Task<Employee> GetEmployeeById(int id);

		Task<Employee> UpdateEmployee(Employee employee);
	}
}

