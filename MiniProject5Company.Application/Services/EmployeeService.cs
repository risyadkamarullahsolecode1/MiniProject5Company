using MiniProject5Company.Application.Dto;
using MiniProject5Company.Application.Helpers;
using MiniProject5Company.Application.Interfaces;
using MiniProject5Company.Domain.Entities;
using MiniProject5Company.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Application.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository) 
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task<PaginatedList<EmployeeSortedDto>> GetFilteredSortedEmployeesAsync(EmployeeFilterSortRequest request)
        {
            var employees = _employeeRepository.GetAllEmployee(); // Assuming you have a method like this

            // Apply filtering
            if (!string.IsNullOrEmpty(request.Fname))
                employees = employees.Where(e => e.Fname.ToLower().Contains(request.Fname.ToLower()));

            if (request.Deptno > 0)
                employees = employees.Where(e => e.Deptno == request.Deptno);

            if (!string.IsNullOrEmpty(request.Position))
                employees = employees.Where(e => e.Position.ToLower().Contains(request.Position.ToLower()));

            if (request.Level > 0)
                employees = employees.Where(e => e.Level == request.Level);

            if (!string.IsNullOrEmpty(request.Employeetype))
                employees = employees.Where(e => e.Employeetype.ToLower().Equals(request.Employeetype.ToLower()));

            var employeeDtos = employees.Select(e => new EmployeeSortedDto
            {
                Fname = e.Fname + " " + e.Lname,
                Deptno = e.Deptno,
                Position = e.Position,
                Level = e.Level,
                Employeetype = e.Employeetype,
                Lastupdateddate = e.Lastupdateddate
            });

            employeeDtos = request.SortBy switch
            {
                "Name" => request.SortDescending ? employeeDtos.OrderByDescending(e => e.Fname) : employeeDtos.OrderBy(e => e.Fname),
                "Department" => request.SortDescending ? employeeDtos.OrderByDescending(e => e.Deptno) : employeeDtos.OrderBy(e => e.Deptno),
                "JobPosition" => request.SortDescending ? employeeDtos.OrderByDescending(e => e.Position) : employeeDtos.OrderBy(e => e.Position),
                "Level" => request.SortDescending ? employeeDtos.OrderByDescending(e => e.Level) : employeeDtos.OrderBy(e => e.Level),
                "EmploymentType" => request.SortDescending ? employeeDtos.OrderByDescending(e => e.Employeetype) : employeeDtos.OrderBy(e => e.Employeetype),
                "LastUpdatedDate" => request.SortDescending ? employeeDtos.OrderByDescending(e => e.Lastupdateddate) : employeeDtos.OrderBy(e => e.Lastupdateddate),
                _ => employeeDtos.OrderBy(e => e.Fname), // Default sorting
            };
            var filteredEmployeeDtos = employeeDtos.Select(e => DtoFilterHelper.RemoveNullProperties(e)).ToList();

            var paginatedEmployees = await PaginatedList<EmployeeSortedDto>.CreateAsync(employeeDtos.AsQueryable(), request.PageNumber, request.PageSize);

            return paginatedEmployees;
        }

        public async Task<EmployeeDetailDto> GetEmployeeDetailsByIdAsync(int empNo)
        {
            var employee = await _employeeRepository.GetEmployeeById(empNo);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with No {empNo} not found.");
            }
            var department = await _departmentRepository.GetDepartmentById(employee.Deptno.Value);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with No {employee.Deptno} not found.");
            }

            // Retrieve the manager's name using the employee's department and manager ID (mgrempno)
            Employee manager = null;
            if (department.Mgrempno.HasValue)
            {
                manager = await _employeeRepository.GetEmployeeById(department.Mgrempno.Value);
            }
            var managerName = manager != null ? manager.Fname + " " + manager.Lname : "No Manager";

            // Map the employee data to the EmployeeDetailDto
            var employeeDetail = new EmployeeDetailDto
            {
                EmployeeName = employee.Fname + " " + employee.Lname,
                Address = employee.Address,
                PhoneNumber = employee.Phonenumber.HasValue ? employee.Phonenumber.Value.ToString() : "Not Available",
                Email = employee.Email,
                Position = employee.Position,
                ManagerName = managerName,
                EmployeeType = employee.Employeetype,
            };

            return employeeDetail;
        }
    }
}
