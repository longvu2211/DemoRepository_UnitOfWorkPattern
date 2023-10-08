namespace ApiPractice.Domain.Entities;

public class ClubRegistration
{
    public int No { get; set; }
    public string? StudentId { get; set; }
    public string? ClubId { get; set; }
    public DateTime JoinedDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public byte Status { get; set; }
    public Student? Student { get; set; }
    public Club? Club { get; set; }
}