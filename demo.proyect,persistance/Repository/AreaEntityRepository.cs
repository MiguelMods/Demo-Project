using demo.proyect.application;
using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.application.Update;
using demo.proyect.common.Helpers.Results;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class AreaEntityRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IAreaEntityRepository
{

    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<AreaEntity> entity = demoProjectApplicationContext.AreaEntities;
    private const string _entityName = "area";

    public async Task<Result<bool>> ActiveInactiveAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.AreaId == id);

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

    public async Task<Result<AreaResponse>> AddAsync(AreaCreate areaEntity)
    {
        var newEntity = Map(areaEntity);
        var result = await entity.AddAsync(newEntity);
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync();

        if (saveResult <= 0)
            return Result<AreaResponse>.Failure(Messages.EntityNotCreated);
        
        var response = (AreaResponse)result.Entity;
        return response.Success();
    }

    public async Task<Result<bool>> DeleteAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.AreaId == id);

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

    public async Task<Result<List<AreaResponse>>> GetAllAsync()
    {
        var result = entity.Select(x => (AreaResponse)x).ToList();
        return result.Success();
    }

    public async Task<Result<AreaResponse?>> GetByIdAsync(long id)
    {
        var result = await entity.Where(x => x.AreaId == id).Select(x => (AreaResponse)x).FirstOrDefaultAsync();
        return result.Success();
    }

    public async Task<Result<AreaResponse?>> GetByRowGuidAsync(string rowGuid)
    {
        var result = await entity.Where(x => x.RowGuid == rowGuid).Select(x => (AreaResponse)x).FirstOrDefaultAsync();
        return result.Success();
    }

    public async Task<Result<AreaResponse>> UpdateAsync(AreaUpdate areaEntity)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == areaEntity.RowGuid) ??
            throw new Exception("Entidad no encontrada");

        entityOnDb.Name = areaEntity.Name;
        entityOnDb.Description = areaEntity.Description ?? "";
        entityOnDb.SuperiorAreaId = areaEntity.SuperiorAreaId;
        entityOnDb.IsActive = areaEntity.IsActive;
        entityOnDb.UpdatedBy = areaEntity.UpdateBy;
        entityOnDb.UpdatedAt = DateTime.Now;

        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<AreaResponse>.Failure(Messages.EntityNotUpdate);

        var response = (AreaResponse)entityOnDb;
        return response.Success();
    }

    private static AreaEntity Map(AreaCreate areaEntity)
        => new ()
        {
            Name = areaEntity.Name,
            Description = areaEntity.Description ?? "",
            Code = areaEntity.Code,
            SuperiorAreaId = areaEntity.SuperiorAreaId,
            CreatedBy = areaEntity.CreateBy
        };

    public async Task<Result<List<AreaResponse>>> GetAllSubAreasFromAreaId(long areaId)
    {
       var result = await entity.Where(x => x.SuperiorAreaId == areaId).Select(x => (AreaResponse)x).ToListAsync();
        return result.Success();
    }
}