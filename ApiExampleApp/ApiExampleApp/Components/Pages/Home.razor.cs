using ApiExampleApi.Data;
using ApiExampleApp.Services;
using ApiExampleShared;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace ApiExampleApp.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public Employee Employee { get; set; } = new Employee();





        public bool ShowCreate { get; set; }
        public bool EditRecord { get; set; }
        public int EditingId { get; set; }

        private EmployeeDataContext? _context;

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await ShowEmployees();
        }

        public Employee? NewEmployee { get; set; }

        public void ShowCreateForm()
        {
            NewEmployee = new Employee();
            ShowCreate = true;
        }

        public async Task CreateNewEmployee()
        {
            if (NewEmployee is not null)
            {
                EmployeeDataService.AddEmployee(NewEmployee);
            }
            ShowCreate = false;
            await ShowEmployees();
        }

        public List<Employee>? OurEmployees { get; set; }

        public async Task ShowAnEmployee(int employeeId)
        {
            if (employeeId == 0)
            {
                Employee = new Employee { Id = 1, FirstName = "Nonie", LastName = "Norgue", Email = "nnorgue0@disqus.com", Department = "Research and Development" };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(employeeId);
            }

            /* This is the beginning of the chain to call the database. OurEmployees is embedded into the HTML.
             *  The above code calls the EmployeeDataSercive GetEmployeeDetails function. */
            OurEmployees = [Employee];
        }

        public async Task ShowEmployees()
        {
            OurEmployees = (List<Employee>)await EmployeeDataService.GetAllEmployees();
        }

        public Employee? EmployeeToUpdate { get; set; }

        public async Task ShowEditForm(Employee ourEmployee)
        {
            EmployeeToUpdate = await EmployeeDataService.GetEmployeeDetails(ourEmployee.Id);
            if (EmployeeToUpdate is not null)
            {
                EditRecord = true;
                EditingId = ourEmployee.Id;
            }
        }

        public async Task UpdateEmployee()
        {
            EditRecord = false;

            Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeToUpdate.Id);

            if (Employee is not null)
            {
                await EmployeeDataService.UpdateEmployee(EmployeeToUpdate);
            }
            await ShowEmployees();
        }

        public async Task DeleteEmployee(Employee ourEmployee)
        {
            await EmployeeDataService.DeleteEmployee(ourEmployee.Id);
        }
    }
}
