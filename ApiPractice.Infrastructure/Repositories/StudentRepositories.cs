using ApiPractice.Domain.Entities;
using ApiPractice.Domain.IRepositories;

namespace ApiPractice.Infrastructure.Repositories;

public class StudentRepositories : GenericRepository<Student>, IStudentRepository
{
    public StudentRepositories(UniversityManagementContext dbContext) : base(dbContext)
    {
    }
}