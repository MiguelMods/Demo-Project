using demo.proyect.application.Repository;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace demo.proyect_persistance.Repository;

public abstract class BaseDefaultRepository<Tentity>(DemoProjectApplicationContext demoProjectApplicationContext) : IBaseDefaultRepository<Tentity> where Tentity : BaseEntity
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;

    public async Task<IEnumerable<Tentity?>> GetAllAsync()
        => await demoProjectApplicationContext.Set<Tentity>().Where(x => x.IsDeleted != true).ToListAsync();
    public async Task<Tentity?> GetByRowGuidAsync(string rowGuid)
        => await demoProjectApplicationContext.Set<Tentity>().Where(x => x.RowGuid == rowGuid && x.IsDeleted != true).FirstOrDefaultAsync();
    public async Task<Tentity?> GetByExpressionAsync(Expression<Func<Tentity, bool>> expression)
        => await demoProjectApplicationContext.Set<Tentity>().Where(x => x.IsDeleted != true).FirstOrDefaultAsync(expression);
    public async Task<IEnumerable<Tentity?>> GetByLikeExpressionAsync(Expression<Func<Tentity, bool>> expression)
        => await demoProjectApplicationContext.Set<Tentity>().Where(x => x.IsDeleted != true).Where(expression).ToListAsync();
    public async Task<Tentity?> AddAsync(Tentity entity)
    {
        var newEntity = await demoProjectApplicationContext.Set<Tentity>().AddAsync(entity);
        return newEntity.Entity;
    }
    public Task<Tentity?> UpdateAsync(Tentity entity)
    {
        var updateEntity = demoProjectApplicationContext.Set<Tentity>().Update(entity);
        return Task.FromResult<Tentity?>(updateEntity.Entity);
    }
    public async Task<bool> DeleteAsync(string rowGuid)
    {
        var entity = await demoProjectApplicationContext.Set<Tentity>().FindAsync(rowGuid) ?? throw new Exception($"Entity with Id: {rowGuid} not found");

        if (entity.IsDeleted)
            return true;

        entity.IsDeleted = true;
        entity.UpdatedAt = DateTime.UtcNow;
        demoProjectApplicationContext.Set<Tentity>().Update(entity);

        return true;
    }
}
