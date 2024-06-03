using System.Text.Json.Serialization;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;

namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Course
{
    [Key]
    public int IdCourse { get; set; }
    [Key]
    public int IdSection { get; set; }
    public string Name { get; set; }
    public List<ClassroomByCourse> ClassroomsByCourse { get; set; }
    public List<TeacherByCourse> TeacherByCourses { get; set; }
    public List<Grade> Grades { get; set; }
    public List<Attendance> Attendances { get; set; }
}