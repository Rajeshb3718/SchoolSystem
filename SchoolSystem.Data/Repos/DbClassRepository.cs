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
    public class DbClassRepository : IDbClassRepository
    {
        private readonly SchoolSystemDBContext _schoolSystemDBContext;
        public DbClassRepository(SchoolSystemDBContext schoolSystemDBContext)
        {
            _schoolSystemDBContext = schoolSystemDBContext;
        }
        public async Task<List<Class>> GetClass()
        {
            var result = await _schoolSystemDBContext.Classes.ToListAsync();
            return result;
        }

        public async Task<Class> SaveClassData(ClassViewModel classViewModel)
        {
            var requestModel = new Class();
            {
                requestModel.ClassName = classViewModel.ClassName;
               
            }
            await _schoolSystemDBContext.AddAsync(requestModel);
            _schoolSystemDBContext.SaveChanges();

            return requestModel;
        }
    }
}
