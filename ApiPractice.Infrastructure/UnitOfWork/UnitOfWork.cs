using ApiPractice.Domain.IRepositories;
using ApiPractice.Domain.IUnitOfWork;
using ApiPractice.Infrastructure.Repositories;

namespace ApiPractice.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly UniversityManagementContext _dbContext;
    private IStudentRepository _studentRepository;

    public UnitOfWork(UniversityManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IStudentRepository StudentRepository
        => _studentRepository = _studentRepository ?? new StudentRepositories(_dbContext);
    
    public async Task<bool> CommitAsync()
    {
        var saved = await _dbContext.SaveChangesAsync();
        return saved > 0;
    }
    /// <summary>
    /// WARNING: I created this method, but I don't know how to use
    /// </summary>
    public async Task RollbackAsync()
    {
        await _dbContext.DisposeAsync();
    }
}