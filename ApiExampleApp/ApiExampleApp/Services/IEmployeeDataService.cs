using ApiExampleShared;

namespace ApiExampleApp.Services
{
    public interface IEmployeeDataService
    {
        Task<Employee> GetEmployeeDetails(int employeeId);

        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> AddEmployee(Employee employee);

        Task DeleteEmployee(int employeeId);

        Task UpdateEmployee(Employee employee);
    }
}
