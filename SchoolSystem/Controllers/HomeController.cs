using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Data.Contract;
using SchoolSystem.Data.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using SchoolSystem.Models.ViewModels;
using LearnAPI.Service;

namespace SchoolSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        private readonly IDbClassRepository _dbClass;
        private readonly IDbStudentRepository _dbStudentRepository;


        public HomeController(IDbClassRepository dbClass, IDbStudentRepository dbStudentRepository, IAuthentication authentication)
        {
            _dbClass = dbClass;
            _dbStudentRepository = dbStudentRepository;
            _authentication = authentication;
        }
        /// <summary>
        /// Get class data
        /// </summary>
        /// <returns>
        /// Returns class data
        /// </returns>

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/login")]

        public string Login(string username, string password)
        {
            return _authentication.Authenticate(username, password);
             

        }
        /// <summary>
        /// Get class data
        /// </summary>
        /// <returns>
        /// Returns class data
        /// </returns>

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Class>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/Get-class")]
        [Authorize]
        public async Task<IActionResult> GetClassData()
        {
            var classData = await _dbClass.GetClass();

            if (classData == null)
            {
                return NotFound();
            }
            else
                return Ok(classData);
        }

        /// <summary>
        /// Get class data
        /// </summary>
        /// <returns>
        /// Returns class data
        /// </returns>

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Class>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/Add-class")]
        public async Task<IActionResult> SaveClassData(ClassViewModel classViewModel)
        {
            var classData = _dbClass.SaveClassData(classViewModel);

            if (classData == null)
            {
                return NotFound();
            }
            else
                return Ok(classData);
        }

        /// <summary>
        /// Add student data
        /// </summary>
        /// <returns>
        /// Returns student data
        /// </returns>

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Student>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("/Add-student")]
        public async Task<IActionResult> AddStudent(StudentViewModel studentViewModel)
        {
            var studentData = await _dbStudentRepository.InsertSinggleStudent(studentViewModel);

            if (studentData == null)
            {
                return NotFound();
            }
            else
                return Ok(studentData);
        }

        /// <summary>
        /// Get student data
        /// </summary>
        /// <returns>
        /// Returns student data
        /// </returns>

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Student>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/Get-student")]
        public async Task<IActionResult> GetStudent()
        {
            var studentData = await _dbStudentRepository.GetStudentsData();

            if (studentData == null)
            {
                return NotFound();
            }
            else
                return Ok(studentData);
        }
    }
}
