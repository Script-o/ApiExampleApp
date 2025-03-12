using ApiExampleApi.Data;
using ApiExampleShared;
using System;

namespace ApiExampleApi.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDataContext _employeeDataContext;

        public EmployeeRepository(EmployeeDataContext appDbContext)
        {
            _employeeDataContext = appDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeDataContext.Employees;
        }

        /* This is the final piece of the database call. It actually calls the Data Context and asks for
         * the requested information from the database */
        public Employee GetEmployeeById(int employeeId)
        {
            return _employeeDataContext.Employees.FirstOrDefault(c => c.Id == employeeId);
        }

        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _employeeDataContext.Employees.Add(employee);
            _employeeDataContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _employeeDataContext.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (foundEmployee == null) return;

            _employeeDataContext.Employees.Remove(foundEmployee);
            _employeeDataContext.SaveChanges();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var foundEmployee = _employeeDataContext.Employees.FirstOrDefault(e => e.Id == employee.Id);

            if (foundEmployee != null)
            {
                foundEmployee.Id = employee.Id;
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.Email = employee.Email;
                foundEmployee.Department = employee.Department;

                _employeeDataContext.SaveChanges();

                return foundEmployee;
            }

            return null;
        }

    }
}
