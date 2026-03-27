using demo.proyect.application;
using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.common.Helpers.Results;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class ProjectDevelopmentTypeRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IProjectDevelopmentTypeRepository
{

    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<ProjectDevelopmentTypeEntity> entity = demoProjectApplicationContext.ProjectDevelopmentTypeEntities;
    private const string _entityName = "Tipo_desarrollo";

    public async Task<Result<bool>> ActiveInactiveAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.ProjectDevelopmentTypeId == id);

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

    public async Task<Result<ProjectDevelopmentTypeResponse>> AddAsync(ProjectDevelopmentTypeCreate priorityTypeEntity)
    {
        var newEntity = new ProjectDevelopmentTypeEntity()
        {
            Name = priorityTypeEntity.Name,
            Description = priorityTypeEntity.Description,
            CreatedBy = priorityTypeEntity.CreateBy
        };
        var addResult = await entity.AddAsync(newEntity);
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<ProjectDevelopmentTypeResponse>.Failure(Messages.EntityNotCreated);

        var entityResult = (ProjectDevelopmentTypeResponse)addResult.Entity;
        return entityResult.Success();
    }

    public async Task<Result<bool>> DeleteAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.ProjectDevelopmentTypeId == id);

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

    public async Task<Result<List<ProjectDevelopmentTypeResponse>>> GetAllAsync()
    {
        var result = entity.Select(x => (ProjectDevelopmentTypeResponse)x).ToList();
        return result.Success();
    }

    public async Task<Result<ProjectDevelopmentTypeResponse?>> GetByIdAsync(long id)
    {
        var result = await entity.Where(x => x.ProjectDevelopmentTypeId == id).Select(x => (ProjectDevelopmentTypeResponse)x).FirstOrDefaultAsync();
        return result.Success();
    }

    public async Task<Result<ProjectDevelopmentTypeResponse?>> GetByRowGuidAsync(string rowGuid)
    {
        var result = await entity.Where(x => x.RowGuid == rowGuid).Select(x => (ProjectDevelopmentTypeResponse)x).FirstOrDefaultAsync();
        return result.Success();
    }

    public async Task<Result<ProjectDevelopmentTypeResponse>> UpdateAsync(ProjectDevelopmentTypeEntity projectDevelopmentTypeEntity)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == projectDevelopmentTypeEntity.RowGuid);

        if(entityOnDb is null)
            return Result<ProjectDevelopmentTypeResponse>.Failure(Messages.EntityNotFound);

        entityOnDb.Name = projectDevelopmentTypeEntity.Name;
        entityOnDb.Description = projectDevelopmentTypeEntity.Description;
        entityOnDb.IsActive = projectDevelopmentTypeEntity.IsActive;
        entityOnDb.UpdatedBy = projectDevelopmentTypeEntity.UpdatedBy;
        entityOnDb.UpdatedAt = DateTime.Now;

        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<ProjectDevelopmentTypeResponse>.Failure(Messages.EntityNotUpdate);

        var entityResult = (ProjectDevelopmentTypeResponse)entityOnDb;
        return entityResult.Success();
    }
}