using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contract;
using SchoolSystem.Data.Repository;
using SchoolSystem.Data.Repository.Entities;
using SchoolSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Repos
{
    public class DbStudentRepository : IDbStudentRepository
    {
        private readonly SchoolSystemDBContext _schoolSystemDBContext;
        public DbStudentRepository(SchoolSystemDBContext schoolSystemDBContext)
        {
            _schoolSystemDBContext = schoolSystemDBContext;
        }
        public async Task<List<Student>> GetStudentsData()
        {
            var result = await _schoolSystemDBContext.Students.ToListAsync();
            return result;
        }

        public async Task<Student> InsertSinggleStudent(StudentViewModel studentViewModel)
        {
            var requestModel = new Student();
            {
                requestModel.Name = studentViewModel.Name;
                requestModel.Dob = studentViewModel.Dob;
                requestModel.Gender = studentViewModel.Gender;
                requestModel.Mobile= studentViewModel.Mobile;
                requestModel.RollNo = studentViewModel.RollNo;
                requestModel.Address = studentViewModel.Address;    
                requestModel.ClassId = studentViewModel.ClassId;
            }

            await _schoolSystemDBContext.AddAsync(requestModel);
            _schoolSystemDBContext.SaveChanges();
            return requestModel;

        }
    }
}
