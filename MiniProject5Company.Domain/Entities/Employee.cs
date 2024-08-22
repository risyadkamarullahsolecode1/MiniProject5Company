using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject5Company.Domain.Entities;

[Table("employees")]
public partial class Employee
{
    [Key]
    [Column("empno")]
    public int Empno { get; set; }

    [Column("fname")]
    [StringLength(50)]
    public string Fname { get; set; } = null!;

    [Column("lname")]
    [StringLength(50)]
    public string Lname { get; set; } = null!;

    [Column("address", TypeName = "character varying")]
    public string Address { get; set; } = null!;

    [Column("dob")]
    public DateOnly Dob { get; set; }

    [Column("salary")]
    public int? Salary { get; set; }

    [Column("sex", TypeName = "character varying")]
    public string? Sex { get; set; }

    [Column("phonenumber")]
    public int? Phonenumber { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("position")]
    [StringLength(50)]
    public string? Position { get; set; }

    [Column("deptno")]
    public int? Deptno { get; set; }

    [Column("employeetype")]
    [StringLength(50)]
    public string? Employeetype { get; set; }

    [Column("level")]
    public int? Level { get; set; }

    [Column("lastupdateddate", TypeName = "timestamp without time zone")]
    public DateTime? Lastupdateddate { get; set; }

    [Column("nik")]
    public int? Nik { get; set; }

    [InverseProperty("MgrempnoNavigation")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [InverseProperty("EmpnoNavigation")]
    public virtual ICollection<Dependant> Dependants { get; set; } = new List<Dependant>();

    [ForeignKey("Deptno")]
    [InverseProperty("Employees")]
    public virtual Department? DeptnoNavigation { get; set; }

    [InverseProperty("EmpnoNavigation")]
    public virtual ICollection<Workson> Worksons { get; set; } = new List<Workson>();
}
