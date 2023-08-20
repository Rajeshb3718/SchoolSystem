using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Repository.Entities;

public partial class Fee
{
    [Key]
    public int FeesId { get; set; }

    public int? ClassId { get; set; }

    public int? FeesAmount { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Fees")]
    public virtual Class? Class { get; set; }
}
