namespace ApiPractice.Domain.Entities;

public class Major
{
    public string? MajorId { get; set; }
    public string? MajorName { get; set; }
    public int EstablishedYear { get; set; }
    public byte MajorStatus { get; set; }
    public ICollection<StudentMajor> StudentMajors = new List<StudentMajor>();
}