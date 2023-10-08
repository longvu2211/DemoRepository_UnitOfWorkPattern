namespace ApiPractice.Domain.Entities;

public class Student
{
    public string? StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
    public ICollection<StudentMajor> StudentMajors = new List<StudentMajor>();
    public ICollection<ClubRegistration> ClubRegistrations = new List<ClubRegistration>();
}