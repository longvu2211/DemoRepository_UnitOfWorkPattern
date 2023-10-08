using ApiPractice.Domain.Entities;

namespace ApiPractice.Infrastructure.SeedData;

public class UniversityManagementSeed
{
    private readonly UniversityManagementContext _context;

    public UniversityManagementSeed(UniversityManagementContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (!_context.Clubs.Any())
        {
            var clubs = new List<Club>()
            {
                new Club()
                {
                    ClubId = "FEV",
                    ClubName = "FPT Event Club",
                    Description = "FPT Event Club - HCM Campus",
                    EstablishedYear = 2017,
                    ClubStatus = 1,
                },
                new Club()
                {
                    ClubId = "FIA",
                    ClubName = "FPT Information Assurance",
                    Description = "Club for students who like Information Assurance",
                    EstablishedYear = 2018,
                    ClubStatus = 1,
                },
                new Club()
                {
                    ClubId = "DSC",
                    ClubName = "FPT Developers Student Community",
                    Description = "A club for students who like programming and sharing about tech news",
                    EstablishedYear = 2022,
                    ClubStatus = 1,
                },
                new Club()
                {
                    ClubId = "CSC",
                    ClubName = "Coc Sai Gon",
                    Description = "Coc Sai Gon - FPT Campus, official page for hot news",
                    EstablishedYear = 2017,
                    ClubStatus = 1,
                },
            };
            _context.Clubs.AddRange(clubs);
            _context.SaveChanges();
        }
        
        if (!_context.Majors.Any())
        {
            var majors = new List<Major>()
            {
                new Major()
                {
                    MajorId = "SE",
                    MajorName = "Software Engineering",
                    EstablishedYear = 2016,
                    MajorStatus = 1,
                },
                new Major()
                {
                    MajorId = "MKT",
                    MajorName = "Digital Marketing",
                    EstablishedYear = 2016,
                    MajorStatus = 1,
                },
                new Major()
                {
                    MajorId = "AI",
                    MajorName = "Artificial Intelligence",
                    EstablishedYear = 2018,
                    MajorStatus = 1,
                },
                new Major()
                {
                    MajorId = "IB",
                    MajorName = "International Business",
                    EstablishedYear = 2016,
                    MajorStatus = 1,
                },
            };
            _context.Majors.AddRange(majors);
            _context.SaveChanges();
        }
        
        if (!_context.Students.Any())
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    StudentId = "SE171024",
                    FirstName = "Long",
                    LastName = "Vu",
                    Email = "longvse171024@fpt.edu.vn",
                    Password = "1",
                    PhoneNumber = "0866742614",
                    Gender = "Male"
                },
                new Student()
                {
                    StudentId = "SS000001",
                    FirstName = "Huy",
                    LastName = "Nguyen",
                    Email = "huynguyenss000001@fpt.edu.vn",
                    Password = "2",
                    PhoneNumber = "0890123097",
                    Gender = "Male"
                },
                new Student()
                {
                    StudentId = "SS000002",
                    FirstName = "Mai",
                    LastName = "Tran Truc",
                    Email = "maitrantrucss000002@fpt.edu.vn",
                    Password = "3",
                    PhoneNumber = "0887652123",
                    Gender = "Female"
                },
                new Student()
                {
                    StudentId = "SE000003",
                    FirstName = "Tien",
                    LastName = "Nguyen",
                    Email = "tiennguyense000003@fpt.edu.vn",
                    Password = "1",
                    PhoneNumber = "0887872123",
                    Gender = "Male"
                },
            };
            _context.Students.AddRange(students);
            _context.SaveChanges();
        }
    }
}