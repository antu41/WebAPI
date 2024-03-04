using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly MyDbContext context;
        private readonly IEmployee employee;

        public EmployeeAPIController(MyDbContext context)
        {
            this.context = context;
        }

        public EmployeeAPIController(IEmployee employee)
        {
            this.employee = employee;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var data = await context.Employees.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee emp)
        {
            await context.Employees.AddAsync(emp);
            await context.SaveChangesAsync();
            return Ok(emp);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }
            context.Entry(emp).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(emp);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            context.Employees.Remove(emp);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
