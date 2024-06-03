namespace ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using System.Threading.Tasks;

public class TeacherCommandService
{
    private readonly TeacherRepository repository;

    public TeacherCommandService(TeacherRepository repository)
    {
        this.repository = repository;
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        await repository.AddTeacherAsync(teacher);
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        await repository.UpdateTeacherAsync(teacher);
    }

    public async Task DeleteTeacherAsync(int teacherId)
    {
        await repository.DeleteTeacherAsync(teacherId);
    }
}