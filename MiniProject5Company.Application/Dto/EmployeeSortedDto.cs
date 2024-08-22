using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Application.Dto
{
    public class EmployeeSortedDto
    {
        public string Fname { get; set; } = null!;
        public string? Position { get; set; }
        public int? Deptno { get; set; }
        public string? Employeetype { get; set; }
        public int? Level { get; set; }
        public DateTime? Lastupdateddate { get; set; }
    }
}
