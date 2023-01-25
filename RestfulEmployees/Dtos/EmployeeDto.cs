namespace RestfulEmployees.Dtos
{
    public class EmployeeDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; }

    }
}
