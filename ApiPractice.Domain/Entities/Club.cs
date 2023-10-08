namespace ApiPractice.Domain.Entities;

public class Club
{
    public string? ClubId { get; set; }
    public string? ClubName { get; set; }
    public string? Description { get; set; }
    public int EstablishedYear { get; set; }
    public byte ClubStatus { get; set; }
    public ICollection<ClubRegistration> ClubRegistrations = new List<ClubRegistration>();
}