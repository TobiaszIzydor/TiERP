﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Domain.Entities;

namespace TiWms.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task Commit();
        Task Create(Employee employee);
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int employeeId);
        Task<IEnumerable<Employee>> GetLiders();
        Task DeleteById(int id);
    }
}
