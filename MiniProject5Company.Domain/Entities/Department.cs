﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject5Company.Domain.Entities;

[Table("departments")]
public partial class Department
{
    [Key]
    [Column("deptno")]
    public int Deptno { get; set; }

    [Column("deptname")]
    [StringLength(100)]
    public string Deptname { get; set; } = null!;

    [Column("mgrempno")]
    public int? Mgrempno { get; set; }

    [Column("location")]
    [StringLength(100)]
    public string? Location { get; set; }

    [InverseProperty("DeptnoNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [ForeignKey("Mgrempno")]
    [InverseProperty("Departments")]
    public virtual Employee? MgrempnoNavigation { get; set; }

    [InverseProperty("DeptnoNavigation")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
