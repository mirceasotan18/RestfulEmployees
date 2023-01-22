using RestfulEmployees.models;

namespace RestfulEmployees.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DepartmentModel Department { get; set;}
        public int DepartmentId { get; set; }
    }
}
