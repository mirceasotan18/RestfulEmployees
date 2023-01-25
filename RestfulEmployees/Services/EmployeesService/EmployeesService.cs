using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestfulEmployees.Data;
using RestfulEmployees.Dtos;
using RestfulEmployees.Models;
using RestfulEmployees.Utils;
using System.Collections;

namespace RestfulEmployees.Services.EmployeesService
{
    public class EmployeesService : IEmployeesService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeesService(DataContext context, IMapper mapper)
        {
            _context= context;
            _mapper = mapper;
        }
        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FirstAsync(x => x.Id == id);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            return employee;
        }
        public async Task AddEmployee(EmployeeDto employeeRequest)
        {
            await _context.Employees.AddAsync(_mapper.Map<EmployeeModel>(employeeRequest));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(int id, EmployeeDto employeeRequest)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            _mapper.Map(employeeRequest, employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable> GroupByDepartment()
        {
            var allEmployees = await GetAllEmployees();
            var allDepartments = await _context.Departments.ToListAsync();
            var groupByDepartment = allDepartments.GroupJoin(allEmployees,
                    dep => dep.Id,
                    emp => emp.DepartmentId,
                    (dep, EmployeeGroup) => new
                    {
                        dep.Name,
                        Count = EmployeeGroup.Count()
                    });

            return groupByDepartment.ToList();
        }

        public void ExportEmployees()
        {
            ExportData.ExportCsv(_context.Employees.ToList(), "exportEmployee.csv");
        }

    }
}
