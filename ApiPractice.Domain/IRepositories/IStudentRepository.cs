using ApiPractice.Domain.Entities;

namespace ApiPractice.Domain.IRepositories;
/// <summary>
/// the repository can be extended with custom methods, based on your business requirements
/// </summary>
public interface IStudentRepository : IGenericRepository<Student>
{
    
}