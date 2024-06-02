namespace ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TeacherQueryService
{
    private readonly TeacherRepository repository;

    public TeacherQueryService(TeacherRepository repository)
    {
        this.repository = repository;  // Corregido
    }

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
    {
        return await repository.GetAllTeachersAsync();
    }

    public async Task<Teacher> GetTeacherByIdAsync(int id)
    {
        return await repository.GetTeacherByIdAsync(id);
    }
}