using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("TeacherSubject")]
public partial class TeacherSubject
{
    [Key]
    public int Id { get; set; }

    public int? ClassId { get; set; }

    public int? SubjectId { get; set; }

    public int? TeacherId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("TeacherSubjects")]
    public virtual Class? Class { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("TeacherSubjects")]
    public virtual Subject? Subject { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("TeacherSubjects")]
    public virtual Teacher? Teacher { get; set; }
}
