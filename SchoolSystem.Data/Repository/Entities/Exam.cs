using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("Exam")]
public partial class Exam
{
    [Key]
    public int ExamId { get; set; }

    public int? ClassId { get; set; }

    public int? SubjectId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? RollNo { get; set; }

    public int? TotalMarks { get; set; }

    public int? OutOfMarks { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Exams")]
    public virtual Class? Class { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Exams")]
    public virtual Subject? Subject { get; set; }
}
