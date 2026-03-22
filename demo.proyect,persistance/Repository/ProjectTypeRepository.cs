using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class ProjectTypeRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IProjectTypeRepository
{

    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<ProjectTypeEntity> projectTypeEntities = demoProjectApplicationContext.ProjectTypeEntities;

    public async Task<bool> ActiveInactiveAsync(long id)
    {
        var entityOnDb = await projectTypeEntities.FirstOrDefaultAsync(x => x.ProjectTypeId == id);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsActive = !entityOnDb.IsActive;
        var result = await demoProjectApplicationContext.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> ActiveInactiveAsync(string rowGuid)
    {
        var entityOnDb = await projectTypeEntities.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsActive = !entityOnDb.IsActive;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<ProjectTypeResponse> AddAsync(ProjectTypeCreate projectTypeCreate)
    {
        var newEntity = new ProjectTypeEntity()
        {
            Name = projectTypeCreate.Name,
            Description = projectTypeCreate.Description,
            CreatedBy = projectTypeCreate.CreateBy
        };
        var result = await projectTypeEntities.AddAsync(newEntity);
        var save = await demoProjectApplicationContext.SaveChangesAsync();

        if (save > 0)
            return (ProjectTypeResponse)result.Entity;

        return new();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entityOnDb = await projectTypeEntities.FirstOrDefaultAsync(x => x.ProjectTypeId == id);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsDeleted = true;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(string rowGuid)
    {
        var entityOnDb = await projectTypeEntities.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsDeleted = true;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<ProjectTypeResponse>> GetAllAsync()
    {
        var result = projectTypeEntities.Select(x => (ProjectTypeResponse)x).ToList();
        return result;
    }

    public async Task<ProjectTypeResponse?> GetByIdAsync(long id)
    {
        var result = await projectTypeEntities.Where(x => x.ProjectTypeId == id).Select(x => (ProjectTypeResponse)x).FirstOrDefaultAsync();
        return result;
    }

    public async Task<ProjectTypeResponse?> GetByRowGuidAsync(string rowGuid)
    {
        var result = await projectTypeEntities.Where(x => x.RowGuid == rowGuid).Select(x => (ProjectTypeResponse)x).FirstOrDefaultAsync();
        return result;
    }

    public async Task<ProjectTypeResponse> UpdateAsync(ProjectTypeEntity projectDevelopmentTypeEntity)
    {
        var entityOnDb = await projectTypeEntities.FirstOrDefaultAsync(x => x.RowGuid == projectDevelopmentTypeEntity.RowGuid) ??
            throw new Exception("Entidad no encontrada");

        entityOnDb.Name = projectDevelopmentTypeEntity.Name;
        entityOnDb.Description = projectDevelopmentTypeEntity.Description;
        entityOnDb.IsActive = projectDevelopmentTypeEntity.IsActive;
        entityOnDb.UpdatedBy = projectDevelopmentTypeEntity.UpdatedBy;
        entityOnDb.UpdatedAt = DateTime.Now;

        var result = await demoProjectApplicationContext.SaveChangesAsync();

        if (result > 0)
            return (ProjectTypeResponse)entityOnDb;

        return new();
    }
}
