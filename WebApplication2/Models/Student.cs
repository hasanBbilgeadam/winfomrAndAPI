using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApplication2.Models
{
    public enum Gender
    {
        male=1,
        female=2,
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }


        public List<Exam> Exams { get; set; } = new();
    }

    public enum ExamType
    {
        first=1,
         second=2,
        third=3, 
    }
    public enum LessonType
    {
        Türkçe=1,
        Mat=2
    }
    public class Exam
    {
        public int Id { get; set; }
        public ExamType ExamType { get; set; }
        public LessonType LessonType { get; set; }
        public int Puan { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }


    }


    public class ExamAddDto
    {
        public ExamType ExamType { get; set; }
        public LessonType LessonType { get; set; }
        public int Puan { get; set; }

        public int StudentId { get; set; }
    }
        

}
