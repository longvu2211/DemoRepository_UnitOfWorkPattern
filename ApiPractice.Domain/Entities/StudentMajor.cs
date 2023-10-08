namespace ApiPractice.Domain.Entities;

public class StudentMajor
{
    public int No { get; set; }
    public string? StudentId { get; set; }
    public string? MajorId { get; set; }
    public byte Status { get; set; }
    public Student? Student { get; set; }
    public Major? Major { get; set; }
}