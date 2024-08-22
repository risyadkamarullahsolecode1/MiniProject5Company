using MiniProject5Company.Application.Dto;
using MiniProject5Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Application.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Fname = employee.Fname,
                Lname = employee.Lname,
                Dob = employee.Dob,
                Address = employee.Address,
                Phonenumber = employee.Phonenumber,
                Salary = employee.Salary,
                Email = employee.Email,
                Deptno = employee.Deptno,
                Position = employee.Position,
                Employeetype = employee.Employeetype,
                Level = employee.Level,
                Lastupdateddate = employee.Lastupdateddate
            };
        }
    }
}
