using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

[Table("Expense")]
public partial class Expense
{
    [Key]
    public int ExpenseId { get; set; }

    public int? ClassId { get; set; }

    public int? SubjectId { get; set; }

    public int? ChargeAmount { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Expenses")]
    public virtual Class? Class { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Expenses")]
    public virtual Subject? Subject { get; set; }
}
