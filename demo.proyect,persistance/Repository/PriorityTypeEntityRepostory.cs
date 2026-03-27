using demo.proyect.application;
using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.common.Helpers.Results;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class PriorityTypeEntityRepostory(DemoProjectApplicationContext demoProjectApplicationContext) : IPriorityTypeEntityRepostory
{
    
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<PriorityTypeEntity> entity = demoProjectApplicationContext.PriorityTypeEntities;
    private const string _entityName = "Tipo_Prioridad";

    public async Task<Result<bool>> ActiveInactiveAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.PriorityTypeId == id);

        if (entityOnDb == null)
            return Result<bool>.Failure(Messages.EntityNameNotFoundByPropertyAndValue(_entityName, "id", $"{id}"));

        entityOnDb.IsActive = !entityOnDb.IsActive;
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        return saveResult ? saveResult.Success() : saveResult.Failure(Messages.EntityNotUpdate);
    }

    public async Task<Result<bool>> ActiveInactiveAsync(string rowGuid)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);

        if (entityOnDb == null)
            return Result<bool>.Failure(Messages.EntityNameNotFoundByPropertyAndValue(_entityName, "RowGuid", $"{rowGuid}"));

        entityOnDb.IsActive = !entityOnDb.IsActive;
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        return saveResult ? saveResult.Success() : saveResult.Failure(Messages.EntityNotUpdate);
    }

    public async Task<Result<PriorityTypeResponse>> AddAsync(PriorityTypeCreate priorityTypeEntity)
    {
        var newEntity = new PriorityTypeEntity() { 
            Name = priorityTypeEntity.Name,
            Description = priorityTypeEntity.Description,
            CreatedBy = priorityTypeEntity.CreateBy
        };
        var addResult = await entity.AddAsync(newEntity);
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<PriorityTypeResponse>.Failure(Messages.EntityNotCreated);

        var entityResult = (PriorityTypeResponse)addResult.Entity;
        return entityResult.Success();
    }

    public async Task<Result<bool>> DeleteAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.PriorityTypeId == id);

        if (entityOnDb == null)
            return Result<bool>.Failure(Messages.EntityNameNotFoundByPropertyAndValue(_entityName, "id", $"{id}"));

        entityOnDb.IsDeleted = true;
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        return saveResult ? saveResult.Success() : saveResult.Failure(Messages.EntityNotDelete);
    }

    public async Task<Result<bool>> DeleteAsync(string rowGuid)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);

        if (entityOnDb == null)
            return Result<bool>.Failure(Messages.EntityNameNotFoundByPropertyAndValue(_entityName, "RowGuid", $"{rowGuid}"));

        entityOnDb.IsDeleted = true;
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        return saveResult ? saveResult.Success() : saveResult.Failure(Messages.EntityNotDelete);
    }

    public async Task<Result<List<PriorityTypeResponse>>> GetAllAsync() 
    {
        var result = entity.Select(x => (PriorityTypeResponse)x).ToList();
        return result.Success();
    }

    public async Task<Result<PriorityTypeResponse?>> GetByIdAsync(long id) 
    {
        var result = await entity.Where(x => x.PriorityTypeId == id).Select(x => (PriorityTypeResponse)x).FirstOrDefaultAsync();
        return result.Success();
    }

    public async Task<Result<PriorityTypeResponse?>> GetByRowGuidAsync(string rowGuid) 
    {
        var result = await entity.Where(x => x.RowGuid == rowGuid).Select(x => (PriorityTypeResponse)x).FirstOrDefaultAsync();
        return result.Success();
    }

    public async Task<Result<PriorityTypeResponse>> UpdateAsync(PriorityTypeEntity priorityTypeEntity)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == priorityTypeEntity.RowGuid) ?? 
            throw new Exception("Entidad no encontrada");

        entityOnDb.Name = priorityTypeEntity.Name ;
        entityOnDb.Description = priorityTypeEntity.Description ;
        entityOnDb.IsActive = priorityTypeEntity.IsActive;
        entityOnDb.UpdatedBy = priorityTypeEntity.UpdatedBy;
        entityOnDb.UpdatedAt = DateTime.Now;

        var result = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!result)
            return Result<PriorityTypeResponse>.Failure(Messages.EntityNotUpdate);

        var entityResult = (PriorityTypeResponse)entityOnDb;
        return entityResult.Success();
    }
}