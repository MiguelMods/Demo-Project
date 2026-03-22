using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class PriorityTypeEntityRepostory(DemoProjectApplicationContext demoProjectApplicationContext) : IPriorityTypeEntityRepostory
{
    
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<PriorityTypeEntity> entity = demoProjectApplicationContext.PriorityTypeEntities;
    
    public async Task<bool> ActiveInactiveAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.PriorityTypeId == id);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsActive = !entityOnDb.IsActive;
        var result = await demoProjectApplicationContext.SaveChangesAsync();
        
        return result > 0;
    }

    public async Task<bool> ActiveInactiveAsync(string rowGuid)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsActive = !entityOnDb.IsActive;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<PriorityTypeResponse> AddAsync(PriorityTypeCreate priorityTypeEntity)
    {
        var newEntity = new PriorityTypeEntity() { 
            Name = priorityTypeEntity.Name,
            Description = priorityTypeEntity.Description,
            CreatedBy = priorityTypeEntity.CreateBy
        };
        var result = await entity.AddAsync(newEntity);
        var save = await demoProjectApplicationContext.SaveChangesAsync();

        if(save > 0)
            return (PriorityTypeResponse)result.Entity;

        return new();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.PriorityTypeId == id);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsDeleted = true;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(string rowGuid)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsDeleted = true;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<PriorityTypeResponse>> GetAllAsync() 
    {
        var result = entity.Select(x => (PriorityTypeResponse)x).ToList();
        return result;
    }

    public async Task<PriorityTypeResponse?> GetByIdAsync(long id) 
    {
        var result = await entity.Where(x => x.PriorityTypeId == id).Select(x => (PriorityTypeResponse)x).FirstOrDefaultAsync();
        return result;
    }

    public async Task<PriorityTypeResponse?> GetByRowGuidAsync(string rowGuid) 
    {
        var result = await entity.Where(x => x.RowGuid == rowGuid).Select(x => (PriorityTypeResponse)x).FirstOrDefaultAsync();
        return result;
    }

    public async Task<PriorityTypeResponse> UpdateAsync(PriorityTypeEntity priorityTypeEntity)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == priorityTypeEntity.RowGuid) ?? 
            throw new Exception("Entidad no encontrada");

        entityOnDb.Name = priorityTypeEntity.Name ;
        entityOnDb.Description = priorityTypeEntity.Description ;
        entityOnDb.IsActive = priorityTypeEntity.IsActive;
        entityOnDb.UpdatedBy = priorityTypeEntity.UpdatedBy;
        entityOnDb.UpdatedAt = DateTime.Now;

        var result = await demoProjectApplicationContext.SaveChangesAsync();

        if (result > 0)
            return (PriorityTypeResponse)entityOnDb;

        return new();
    }
}