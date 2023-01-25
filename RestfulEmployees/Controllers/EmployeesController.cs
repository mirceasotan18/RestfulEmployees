using Microsoft.AspNetCore.Mvc;
using RestfulEmployees.Dtos;
using RestfulEmployees.Models;
using RestfulEmployees.Services.EmployeesService;
using System.Collections;

namespace RestfulEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        
        private readonly IEmployeesService _employeesService;
        public EmployeesController(IEmployeesService employeesService,ILogger<EmployeesController> logger)
        {
            _employeesService = employeesService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employees = await _employeesService.GetAllEmployees();
            _logger.LogInformation("Success getting all employess");

            return Ok(employees);
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeById(int id)
        {
            var employee = await _employeesService.GetEmployeeById(id);
            _logger.LogInformation("Success getting employee by Id");

            return Ok(employee);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult> AddEmployee(EmployeeDto employeeRequest)
        {
            await _employeesService.AddEmployee(employeeRequest);
            _logger.LogInformation("Success adding employee");

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeesService.DeleteEmployee(id);
            _logger.LogInformation("Success deleting employee");

            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeDto employeeRequest)
        {
            await _employeesService.UpdateEmployee(id, employeeRequest);
            _logger.LogInformation("Success updating employee");

            return Ok();
        }

        [HttpGet]
        [Route("GroupByDepartment")]
        public async Task<ActionResult<IEnumerable>> GroupByDepartment()
        {
            var employees = await _employeesService.GroupByDepartment();
            _logger.LogInformation("Success group by employees");

            return Ok(employees);
        }

        [HttpGet]
        [Route("ExportEmployees")]
        public ActionResult ExportEmployees()
        {
            _employeesService.ExportEmployees();
            _logger.LogInformation("Success export employess");

            return Ok();
        }
    }
}
