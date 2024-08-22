using MiniProject5Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department> GetDepartmentById(int deptNo);
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<bool> DeleteDepartment(int deptNo);
        Task<Employee> GetManagerByDeptNoAsync(int deptNo);
    }
}
