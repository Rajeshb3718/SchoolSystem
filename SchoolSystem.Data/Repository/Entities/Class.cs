using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("Class")]
public partial class Class
{
    [Key]
    public int ClassId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ClassName { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [InverseProperty("Class")]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    [InverseProperty("Class")]
    public virtual ICollection<Fee> Fees { get; set; } = new List<Fee>();

    [InverseProperty("Class")]
    public virtual ICollection<StudentAttendence> StudentAttendences { get; set; } = new List<StudentAttendence>();

    [InverseProperty("Class")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("Class")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    [InverseProperty("Class")]
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

    [InverseProperty("Class")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
