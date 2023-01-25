using RestfulEmployees.Dtos;
using RestfulEmployees.Models;
using System.Collections;

namespace RestfulEmployees.Services.EmployeesService
{
    public interface IEmployeesService
    {
        Task<List<EmployeeModel>> GetAllEmployees();
        Task<EmployeeModel> GetEmployeeById(int id);
        Task AddEmployee(EmployeeDto employeeRequest);
        Task UpdateEmployee(int id, EmployeeDto employeeRequest);
        Task DeleteEmployee(int id);
        Task<IEnumerable> GroupByDepartment();

        void ExportEmployees();
    }
}
