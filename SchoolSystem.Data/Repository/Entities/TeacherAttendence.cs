using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("TeacherAttendence")]
public partial class TeacherAttendence
{
    [Key]
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public bool? Status { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("TeacherAttendences")]
    public virtual Teacher? Teacher { get; set; }
}
