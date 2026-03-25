using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.application.Update;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class AreaEntityRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IAreaEntityRepository
{

    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<AreaEntity> entity = demoProjectApplicationContext.AreaEntities;

    public async Task<bool> ActiveInactiveAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.AreaId == id);

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

    public async Task<AreaResponse> AddAsync(AreaCreate areaEntity)
    {
        var newEntity = new AreaEntity
        {
            Name = areaEntity.Name,
            Description = areaEntity.Description ?? "",
            Code = areaEntity.Code,
            SuperiorAreaId = areaEntity.SuperiorAreaId,
            CreatedBy = areaEntity.CreateBy
        };
        var result = await entity.AddAsync(newEntity);
        var save = await demoProjectApplicationContext.SaveChangesAsync();

        if (save > 0)
            return (AreaResponse)result.Entity;

        return new();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.AreaId == id);

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

    public async Task<List<AreaResponse>> GetAllAsync()
    {
        var result = entity.Select(x => (AreaResponse)x).ToList();
        return result;
    }

    public async Task<AreaResponse?> GetByIdAsync(long id)
    {
        var result = await entity.Where(x => x.AreaId == id).Select(x => (AreaResponse)x).FirstOrDefaultAsync();
        return result;
    }

    public async Task<AreaResponse?> GetByRowGuidAsync(string rowGuid)
    {
        var result = await entity.Where(x => x.RowGuid == rowGuid).Select(x => (AreaResponse)x).FirstOrDefaultAsync();
        return result;
    }

    public async Task<AreaResponse> UpdateAsync(AreaUpdate areaEntity)
    {
        var entityOnDb = await entity.FirstOrDefaultAsync(x => x.RowGuid == areaEntity.RowGuid) ??
            throw new Exception("Entidad no encontrada");

        entityOnDb.Name = areaEntity.Name;
        entityOnDb.Description = areaEntity.Description ?? "";
        entityOnDb.SuperiorAreaId = areaEntity.SuperiorAreaId;
        entityOnDb.IsActive = areaEntity.IsActive;
        entityOnDb.UpdatedBy = areaEntity.UpdateBy;
        entityOnDb.UpdatedAt = DateTime.Now;

        var result = await demoProjectApplicationContext.SaveChangesAsync();

        if (result > 0)
            return (AreaResponse)entityOnDb;

        return new();
    }
}