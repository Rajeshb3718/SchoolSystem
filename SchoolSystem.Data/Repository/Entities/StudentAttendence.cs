using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("StudentAttendence")]
public partial class StudentAttendence
{
    [Key]
    public int Id { get; set; }

    public int? ClassId { get; set; }

    public int? SubjectId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? RollNo { get; set; }

    public bool? Status { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("StudentAttendences")]
    public virtual Class? Class { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("StudentAttendences")]
    public virtual Subject? Subject { get; set; }
}
