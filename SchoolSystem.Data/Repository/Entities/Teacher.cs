using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("Teacher")]
public partial class Teacher
{
    [Key]
    public int TeacherId { get; set; }

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
    public string? Email { get; set; }

    [Unicode(false)]
    public string? Address { get; set; }

    public int? ClassId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Password { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Teachers")]
    public virtual Class? Class { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<TeacherAttendence> TeacherAttendences { get; set; } = new List<TeacherAttendence>();

    [InverseProperty("Teacher")]
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
