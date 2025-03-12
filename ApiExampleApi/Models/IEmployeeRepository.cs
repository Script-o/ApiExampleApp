using ApiExampleShared;

namespace ApiExampleApi.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int employeeId);

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(int employeeId);

        Employee UpdateEmployee(Employee employee);
    }
}
