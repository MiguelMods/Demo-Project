using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class ProjectDevelopmentTypeRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IProjectDevelopmentTypeRepository
{

    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<ProjectDevelopmentTypeEntity> projectDevelopmentTypeEntities = demoProjectApplicationContext.ProjectDevelopmentTypeEntities;

    public async Task<bool> ActiveInactiveAsync(long id)
    {
        var entityOnDb = await projectDevelopmentTypeEntities.FirstOrDefaultAsync(x => x.ProjectDevelopmentTypeId == id);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsActive = !entityOnDb.IsActive;
        var result = await demoProjectApplicationContext.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> ActiveInactiveAsync(string rowGuid)
    {
        var entityOnDb = await projectDevelopmentTypeEntities.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsActive = !entityOnDb.IsActive;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<ProjectDevelopmentTypeResponse> AddAsync(ProjectDevelopmentTypeCreate priorityTypeEntity)
    {
        var newEntity = new ProjectDevelopmentTypeEntity()
        {
            Name = priorityTypeEntity.Name,
            Description = priorityTypeEntity.Description,
            CreatedBy = priorityTypeEntity.CreateBy
        };
        var result = await projectDevelopmentTypeEntities.AddAsync(newEntity);
        var save = await demoProjectApplicationContext.SaveChangesAsync();

        if (save > 0)
            return (ProjectDevelopmentTypeResponse)result.Entity;

        return new();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entityOnDb = await projectDevelopmentTypeEntities.FirstOrDefaultAsync(x => x.ProjectDevelopmentTypeId == id);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsDeleted = true;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(string rowGuid)
    {
        var entityOnDb = await projectDevelopmentTypeEntities.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);

        if (entityOnDb == null)
            return false;

        entityOnDb.IsDeleted = true;
        await demoProjectApplicationContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<ProjectDevelopmentTypeResponse>> GetAllAsync()
    {
        var result = projectDevelopmentTypeEntities.Select(x => (ProjectDevelopmentTypeResponse)x).ToList();
        return result;
    }

    public async Task<ProjectDevelopmentTypeResponse?> GetByIdAsync(long id)
    {
        var result = await projectDevelopmentTypeEntities.Where(x => x.ProjectDevelopmentTypeId == id).Select(x => (ProjectDevelopmentTypeResponse)x).FirstOrDefaultAsync();
        return result;
    }

    public async Task<ProjectDevelopmentTypeResponse?> GetByRowGuidAsync(string rowGuid)
    {
        var result = await projectDevelopmentTypeEntities.Where(x => x.RowGuid == rowGuid).Select(x => (ProjectDevelopmentTypeResponse)x).FirstOrDefaultAsync();
        return result;
    }

    public async Task<ProjectDevelopmentTypeResponse> UpdateAsync(ProjectDevelopmentTypeEntity projectDevelopmentTypeEntity)
    {
        var entityOnDb = await projectDevelopmentTypeEntities.FirstOrDefaultAsync(x => x.RowGuid == projectDevelopmentTypeEntity.RowGuid) ??
            throw new Exception("Entidad no encontrada");

        entityOnDb.Name = projectDevelopmentTypeEntity.Name;
        entityOnDb.Description = projectDevelopmentTypeEntity.Description;
        entityOnDb.IsActive = projectDevelopmentTypeEntity.IsActive;
        entityOnDb.UpdatedBy = projectDevelopmentTypeEntity.UpdatedBy;
        entityOnDb.UpdatedAt = DateTime.Now;

        var result = await demoProjectApplicationContext.SaveChangesAsync();

        if (result > 0)
            return (ProjectDevelopmentTypeResponse)entityOnDb;

        return new();
    }
}