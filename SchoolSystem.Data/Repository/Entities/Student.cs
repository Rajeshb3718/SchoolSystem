using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("Student")]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("DOB", TypeName = "date")]
    public DateTime? Dob { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Gender { get; set; }

    public long? Mobile { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RollNo { get; set; }

    [Unicode(false)]
    public string? Address { get; set; }

    public int? ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual Class? Class { get; set; }
}
