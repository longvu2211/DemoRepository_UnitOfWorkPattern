using ApiPractice.Domain.IRepositories;

namespace ApiPractice.Domain.IUnitOfWork;
/// <summary>
/// implementing the unit of work pattern
/// </summary>
public interface IUnitOfWork
{
    IStudentRepository StudentRepository { get; }
    Task<bool> CommitAsync();
    Task RollbackAsync();
}