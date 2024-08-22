using MiniProject5Company.Application.Dto;
using MiniProject5Company.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<PaginatedList<EmployeeSortedDto>> GetFilteredSortedEmployeesAsync(EmployeeFilterSortRequest request);
        Task<EmployeeDetailDto> GetEmployeeDetailsByIdAsync(int empNo);
    }
}
