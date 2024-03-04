using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly MyDbContext context;

        public EmployeeRepository(MyDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var data = await context.Employees.ToListAsync();
            return data;
        }

    }
}
