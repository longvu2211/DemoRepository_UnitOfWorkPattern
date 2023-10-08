using ApiPractice.Domain.Entities;
using ApiPractice.Domain.IUnitOfWork;

namespace ApiPractice.Service;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private static readonly string DEFAULT_PASSWORD = "123";
    
    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Student>> GetStudents()
    {
        return await _unitOfWork.StudentRepository.GetAll(null,
            orderBy: q => q.OrderBy(s => s.StudentId));
    }

    public async Task<Student> GetStudent(string id)
    {
        return await _unitOfWork.StudentRepository.FindById(id);
    }

    public async Task<bool> RemoveStudent(Student student)
    {
        _unitOfWork.StudentRepository.Remove(student);
        return await _unitOfWork.CommitAsync();
    }

    public async Task<bool> UpdateStudent(Student student)
    { 
        var existingStudent = await _unitOfWork.StudentRepository.FindById(student.StudentId);
        if (existingStudent == null) return false;
        
        existingStudent.FirstName = student.FirstName;
        existingStudent.LastName = student.LastName;
        existingStudent.Email = student.Email;
        existingStudent.PhoneNumber = student.PhoneNumber;
        existingStudent.Address = student.Address;
        existingStudent.Gender = student.Gender;
        
        _unitOfWork.StudentRepository.Update(existingStudent);
        return await _unitOfWork.CommitAsync();
    }

    public async Task<bool> AddStudent(Student student)
    {
        student.Password = DEFAULT_PASSWORD;
        await _unitOfWork.StudentRepository.Add(student);
        return await _unitOfWork.CommitAsync();
    }
}