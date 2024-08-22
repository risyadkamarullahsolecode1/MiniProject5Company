using MiniProject5Company.Application.Dto;
using MiniProject5Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Application.Mappers
{
    public static class EmployeeSortedMapper
    {
        public static EmployeeSortedDto ToEmployeeSortedDto(this Employee employee)
        {
            return new EmployeeSortedDto
            {
                Fname = employee.Fname,
                Deptno = employee.Deptno,
                Position = employee.Position,
                Employeetype = employee.Employeetype,
                Level = employee.Level,
                Lastupdateddate = employee.Lastupdateddate
            };
        }
    }
}
