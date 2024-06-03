namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CourseQueryService
{
    private readonly CourseRepository _repository;

    public CourseQueryService(CourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _repository.GetAllCoursesAsync();
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        return await _repository.GetCourseByIdAsync(id);
    }
}