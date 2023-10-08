using ApiPractice.Domain.Entities;

namespace ApiPractice.Service;
/// <summary>
/// Operations for an entity
/// an operation will go through a service, and then access to the respective repository 
/// </summary>
public interface IStudentService
{
    Task<IEnumerable<Student>> GetStudents();
    Task<Student> GetStudent(string id);
    Task<bool> RemoveStudent(Student student);
    Task<bool> UpdateStudent(Student student);
    Task<bool> AddStudent(Student student);
}