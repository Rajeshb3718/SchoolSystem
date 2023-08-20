using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels
{
    public class StudentViewModel
    {
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }     
        public string? Gender { get; set; }
        public long? Mobile { get; set; }    
        public string? RollNo { get; set; }       
        public string? Address { get; set; }
        public int? ClassId { get; set; }

    }
}
