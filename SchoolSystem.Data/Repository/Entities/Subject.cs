using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("Subject")]
public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    public int? ClassId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectName { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Subjects")]
    public virtual Class? Class { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [InverseProperty("Subject")]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    [InverseProperty("Subject")]
    public virtual ICollection<StudentAttendence> StudentAttendences { get; set; } = new List<StudentAttendence>();

    [InverseProperty("Subject")]
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
