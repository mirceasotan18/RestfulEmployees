using RestfulEmployees.Models;

namespace RestfulEmployees.models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
}
