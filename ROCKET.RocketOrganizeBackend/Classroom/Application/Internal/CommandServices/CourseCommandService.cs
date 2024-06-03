namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Threading.Tasks;

public class CourseCommandService
{
    private readonly CourseRepository _repository;

    public CourseCommandService(CourseRepository repository)
    {
        _repository = repository;
    }

    public async Task AddCourseAsync(Course course)
    {
        await _repository.AddCourseAsync(course);
    }

    public async Task UpdateCourseAsync(Course course)
    {
        await _repository.UpdateCourseAsync(course);
    }

    public async Task DeleteCourseAsync(int id)
    {
        await _repository.DeleteCourseAsync(id);
    }
}