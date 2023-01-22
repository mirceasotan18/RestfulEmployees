using Microsoft.EntityFrameworkCore;
using RestfulEmployees.models;
using RestfulEmployees.Models;

namespace RestfulEmployees.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

    }
}
