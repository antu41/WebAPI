using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAll();
    }
}
