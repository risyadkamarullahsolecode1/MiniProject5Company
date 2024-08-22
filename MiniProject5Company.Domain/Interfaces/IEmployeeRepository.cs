using MiniProject5Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAllEmployee();
        Task<Employee> GetEmployeeById(int empNo);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int empNo);
    }
}
