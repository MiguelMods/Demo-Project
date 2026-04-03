using demo.proyect.domain.Entities;
using System.Linq.Expressions;

namespace demo.proyect.application.Repository;

public interface IBaseDefaultRepository<Tentity> where Tentity : BaseEntity
{
    Task<IEnumerable<Tentity?>> GetAllAsync();
    Task<Tentity?> GetByRowGuidAsync(string rowGuid);
    Task<Tentity?> GetByExpressionAsync(Expression<Func<Tentity, bool>> expression);
    Task<IEnumerable<Tentity?>> GetByLikeExpressionAsync(Expression<Func<Tentity, bool>> expression);
    Task<Tentity?> AddAsync(Tentity entity);
    Task<Tentity?> UpdateAsync(Tentity entity);
    Task<bool> DeleteAsync(string rowGuid);
}
