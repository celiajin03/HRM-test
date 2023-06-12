using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IEmployeeService
	{
		Task<List<EmployeeResponseModel>> GetAllEmployees();

		Task<List<EmployeeResponseModel>> GetEmployeesByPagination(int page, int pageSize);
		
		Task<EmployeeResponseModel> GetEmployeeById(int id);

		Task<Employee> AddEmployee(EmployeeRequestModel model);

		Task<Employee> UpdateEmployee(int id, EmployeeUpdateModel model);

		Task<Employee> TerminateEmployee(int id);
	}
}

