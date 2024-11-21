using TiWms.Domain.Entities;

namespace TiWms.Application.Services
{
    public interface IEmployeeService
    {
        Task Create(Employee employee);
    }
}