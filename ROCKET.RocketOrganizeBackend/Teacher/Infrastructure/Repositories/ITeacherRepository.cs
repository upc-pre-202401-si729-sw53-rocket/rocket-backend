namespace ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllTeachersAsync();
    Task<Teacher> GetTeacherByIdAsync(int teacherId);
    Task AddTeacherAsync(Teacher teacher);
    Task UpdateTeacherAsync(Teacher teacher);
    Task DeleteTeacherAsync(int teacherId);
}