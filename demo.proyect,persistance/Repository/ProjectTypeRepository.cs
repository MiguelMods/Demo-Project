using demo.proyect.application;
using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.common.Helpers.Results;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class ProjectTypeRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IProjectTypeRepository
{

    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<ProjectTypeEntity> entity = demoProjectApplicationContext.ProjectTypeEntities;
    private const string _entityName = "tipo_de_proyecto";
    public async Task<Result<bool>> ActiveInactiveAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.ProjectTypeId == id);

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

    public async Task<Result<ProjectTypeResponse>> AddAsync(ProjectTypeCreate projectTypeCreate)
    {
        var newEntity = new ProjectTypeEntity()
        {
            Name = projectTypeCreate.Name,
            Description = projectTypeCreate.Description,
            CreatedBy = projectTypeCreate.CreateBy
        };
        var addResult = await entity.AddAsync(newEntity);
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<ProjectTypeResponse>.Failure(Messages.EntityNotCreated);

        var entityResult = (ProjectTypeResponse)addResult.Entity;
        return entityResult.Success();
    }

    public async Task<Result<bool>> DeleteAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.ProjectTypeId == id);

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


    public async Task<Result<List<ProjectTypeResponse>>> GetAllAsync()
    {
        var result = entity.Select(x => (ProjectTypeResponse)x).ToList();
        return result.Success();
    }

    public async Task<Result<ProjectTypeResponse?>> GetByIdAsync(long id)
    {
        var result = await entity.Where(x => x.ProjectTypeId == id).Select(x => (ProjectTypeResponse)x).FirstOrDefaultAsync();
        return result.Success();
    }

    public async Task<Result<ProjectTypeResponse?>> GetByRowGuidAsync(string rowGuid)
    {
        var result = await entity.Where(x => x.RowGuid == rowGuid).Select(x => (ProjectTypeResponse)x).FirstOrDefaultAsync();
        return result.Success();
    }

    public async Task<Result<ProjectTypeResponse>> UpdateAsync(ProjectTypeEntity projectDevelopmentTypeEntity)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == projectDevelopmentTypeEntity.RowGuid) ??
            throw new Exception("Entidad no encontrada");

        entityOnDb.Name = projectDevelopmentTypeEntity.Name;
        entityOnDb.Description = projectDevelopmentTypeEntity.Description;
        entityOnDb.IsActive = projectDevelopmentTypeEntity.IsActive;
        entityOnDb.UpdatedBy = projectDevelopmentTypeEntity.UpdatedBy;
        entityOnDb.UpdatedAt = DateTime.Now;

        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<ProjectTypeResponse>.Failure(Messages.EntityNotUpdate);

        var entityResult = (ProjectTypeResponse)entityOnDb;
        return entityResult.Success();
    }
}
