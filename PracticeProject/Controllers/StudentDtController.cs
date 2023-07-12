using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;
using System.Data;

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDtController : ControllerBase
    {
        private readonly dbPracticeContext _studentDetail;
        dal dal = new dal();
        public StudentDtController(dbPracticeContext Context)
        {
            _studentDetail = Context;
        }

       
        [HttpGet]
        public  IActionResult GetstudentDetail()
        {
            List<StudentDetail> studentDetails = dal.SPGetStudentList();

            return Ok(studentDetails);
                    
        }
        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            StudentDetail studentDetails = dal.GetStudentById(id);

            return Ok(studentDetails);

        }
        [HttpPost]
        public  IActionResult InsertStudent(StudentDetail student)
        {
            return Ok(dal.InsertStudent(student));
                    
        }
        [HttpPut]
        public  IActionResult UpdateStudent(StudentDetail student)
        {
            return Ok(dal.UpdateStudent(student));
                    
        }
       
        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudentById(string id)
        {
            Convert.ToInt32(id);
            bool flag = dal.DeleteStudentById(id);

             return Ok(flag);

        }

    }
}
