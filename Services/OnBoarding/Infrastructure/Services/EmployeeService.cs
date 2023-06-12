using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
	{
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task< List<EmployeeResponseModel>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();
            
            var employeeResponseModel = new List<EmployeeResponseModel>();
            foreach (var employee in employees)
            {
                employeeResponseModel.Add(new EmployeeResponseModel
                {
                    Id = employee.Id, 
                    Address = employee.Address, 
                    Email = employee.Email, 
                    EmployeeIdentityId = employee.EmployeeIdentityId, 
                    EmployeeStatusId = employee.EmployeeStatusId, 
                    EndDate = employee.EndDate,
                    FirstName = employee.FirstName,
                    HireDate = employee.HireDate,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    SSN = employee.SSN
                });
            }
            return employeeResponseModel;
        }
        
        public async Task<List<EmployeeResponseModel>> GetEmployeesByPagination(int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;
            var employees = await _employeeRepository.GetEmployeesByPagination(skipCount, pageSize);
            
            var employeeResponseModel = new List<EmployeeResponseModel>();
            foreach (var employee in employees)
            {
                employeeResponseModel.Add(new EmployeeResponseModel
                {
                    Id = employee.Id, 
                    Address = employee.Address, 
                    Email = employee.Email, 
                    EmployeeIdentityId = employee.EmployeeIdentityId, 
                    EmployeeStatusId = employee.EmployeeStatusId, 
                    EndDate = employee.EndDate,
                    FirstName = employee.FirstName,
                    HireDate = employee.HireDate,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    SSN = employee.SSN
                });
            }
            return employeeResponseModel;
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            var employeeResponseModel = new EmployeeResponseModel
            {
                Id = employee.Id, 
                Address = employee.Address, 
                Email = employee.Email, 
                EmployeeIdentityId = employee.EmployeeIdentityId, 
                EmployeeStatusId = employee.EmployeeStatusId, 
                EndDate = employee.EndDate,
                FirstName = employee.FirstName,
                HireDate = employee.HireDate,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN
            };
            return employeeResponseModel;
        }

        public async Task<Employee> AddEmployee(EmployeeRequestModel model)
        {
            var employeeEntity = new Employee
            {
                Address = model.Address, 
                Email = model.Email, 
                EmployeeIdentityId = Guid.NewGuid(), 
                EmployeeStatusId = model.EmployeeStatusId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SSN = model.SSN,
                EndDate = model.EndDate,
                HireDate = model.HireDate,
                MiddleName = model.MiddleName,
            };

            var employee = await _employeeRepository.AddSync(employeeEntity);
            return employee;
        }
        
        public async Task<Employee> UpdateEmployee(int id, EmployeeUpdateModel model)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);

            // Update employee properties only if the corresponding values are not null or empty
            employee.FirstName = !string.IsNullOrEmpty(model.FirstName) ? model.FirstName : employee.FirstName;
            employee.LastName = !string.IsNullOrEmpty(model.LastName) ? model.LastName : employee.LastName;
            employee.Email = !string.IsNullOrEmpty(model.Email) ? model.Email : employee.Email;
            employee.Address = !string.IsNullOrEmpty(model.Address) ? model.Address : employee.Address;
            employee.EmployeeStatusId = model.EmployeeStatusId ?? employee.EmployeeStatusId;
            employee.EndDate = model.EndDate ?? employee.EndDate;
            employee.HireDate = model.HireDate ?? employee.HireDate;
            employee.MiddleName = !string.IsNullOrEmpty(model.MiddleName) ? model.MiddleName : employee.MiddleName;
            employee.SSN = !string.IsNullOrEmpty(model.SSN) ? model.SSN : employee.SSN;
            
            return await _employeeRepository.UpdateEmployee(employee);
        }
        
        public async Task<Employee> TerminateEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);

            employee.EmployeeStatusId = 3; // Set EmployeeStatusCode to 3 (termination)
            employee.EndDate = DateTime.Now; // Set EndDate to the current date

            return await _employeeRepository.UpdateEmployee(employee);
        }

    }
}

