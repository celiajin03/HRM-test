using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
	{
		private OnBoardingDbContext _dbContext;
		public EmployeeRepository(OnBoardingDbContext dbContext): base(dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<List<Employee>> GetAllEmployees()
		{
			var employees = await _dbContext.Employees.ToListAsync();
			return employees;
		}
		
		public async Task<List<Employee>> GetEmployeesByPagination(int skipCount, int pageSize)
		{
			return await _dbContext.Employees
				.Skip(skipCount)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<Employee> GetEmployeeById(int id)
		{
			var employee = await _dbContext.Employees.FindAsync(id);
			return employee;
		}
		
		public async Task<Employee> UpdateEmployee(Employee employee)
		{
			_dbContext.Employees.Update(employee);
			await _dbContext.SaveChangesAsync();
			return employee;
		}
	}
}

