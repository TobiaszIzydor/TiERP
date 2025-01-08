using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Domain.Entities;

namespace TiErp.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task Create(Customer customer);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task Commit();
        Task DeleteById(int id);
    }
}
