using SchoolSystem.Data.Repository.Entities;
using SchoolSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Contract
{
    public interface IDbStudentRepository
    {
        Task<List<Student>> GetStudentsData();
        Task<Student> InsertSinggleStudent(StudentViewModel studentViewModel);
    }
}
