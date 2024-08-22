using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject5Company.Domain.Entities;

[Table("dependant")]
public partial class Dependant
{
    [Key]
    [Column("dependantno")]
    public int Dependantno { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("sex", TypeName = "character varying")]
    public string? Sex { get; set; }

    [Column("dob")]
    public DateOnly Dob { get; set; }

    [Column("relationship")]
    [StringLength(50)]
    public string Relationship { get; set; } = null!;

    [Column("empno")]
    public int? Empno { get; set; }

    [ForeignKey("Empno")]
    [InverseProperty("Dependants")]
    public virtual Employee? EmpnoNavigation { get; set; }
}
