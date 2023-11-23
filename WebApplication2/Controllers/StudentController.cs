using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetStudents")]
        public IActionResult GetStudents([FromQuery] PagingParameter p,[FromQuery]StudentFilter  sf)
        {
            var query = _context.Students.AsQueryable();
            if (sf.Gender != null)
            {
                

                query = query.Where(x => x.Gender == sf.Gender.Value);
            }
            if (sf.Age != null)
            {
                query = query.Where(x => x.Age >= sf.Age.Value);
            }


            Console.WriteLine(p.PageSize.Value+" pagesize");
            Console.WriteLine(p.PageNumber.Value+" pagenumber");


         query =    query.Skip(p.PageSize.Value*(p.PageNumber.Value-1)).Take(p.PageSize.Value);




            return Ok(query.ToList());
        }


        [HttpPost("AddExamToStudent")]
        public IActionResult AddExamToStudent(ExamAddDto dto)
        {
            var item =  _context.Students.Find(dto.StudentId);

            if (item == null) return BadRequest("böyle biri yoh");


            item.Exams.Add(new()
            {


                ExamType = dto.ExamType,
                LessonType = dto.LessonType,
                Puan = dto.Puan


            });

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("GetAvegare/{studentId}/{lessonType}")]
        public IActionResult GetAvegare(int studentId, int lessonType)
        {

            var item = _context.Students.Where(x => x.Id == studentId).Include(x => x.Exams.Where(x => x.LessonType == (LessonType)lessonType)).First();


                int sum = 0;
            if (item.Exams.Count(x=>x.LessonType == (LessonType)lessonType) == 3)
            {

                item.Exams.Where(x => x.LessonType == (LessonType)lessonType).ToList().ForEach(x =>
                {
                    sum += x.Puan;

                });


            }

            else
            {
                return BadRequest("öğrecnin bu derste 3 sınavı tamamlamadı ortalama hesaplanamaz");
            }
            var result = sum / 3.0;
            return Ok(result.ToString());
        }

        [HttpGet("TestException")]
        public IActionResult TestException()
        {
            throw new DivideByZeroException();

            return Ok();
        }
    }





    public  class PagingParameter
    {
        public int? PageSize { get; set; } = 10;
        public int? PageNumber { get; set; } = 1;
    }

    public class StudentFilter
    {
        public Gender? Gender { get; set; } 
        public int? Age { get; set; }
    }
}
