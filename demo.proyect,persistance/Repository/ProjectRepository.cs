using demo.proyect.application;
using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.application.Update;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class ProjectRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IProjectRepository
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;

    public async Task<Result<List<ProjectResponse>>> GetAllAsync()
    {
        var result = await demoProjectApplicationContext.ProjectEntities
            .Include(x => x.Area)
            .Include(x => x.SubArea)
            .Include(x => x.Priority)
            .Include(x => x.ProjectType)
            .Include(x => x.ProjectDevelopmentType)
            .Select(x => (ProjectResponse)x).ToListAsync();

        return Result<List<ProjectResponse>>.Success(result);
    }

    public async Task<Result<ProjectResponse>> GetByRowGuidAsync(string rowGuid)
    {
        var result = await demoProjectApplicationContext.ProjectEntities.FirstOrDefaultAsync(x => x.RowGuid == rowGuid);
        return Result<ProjectResponse>.Success((ProjectResponse)result);
    }

    public async Task<Result<ProjectResponse>> GetByIdAsync(long longId)
    {
        var result = await demoProjectApplicationContext.ProjectEntities.FirstOrDefaultAsync(x => x.ProjectId == longId);
        return Result<ProjectResponse>.Success((ProjectResponse)result);
    }

    public async Task<Result<ProjectResponse>> AddAsync(ProjectCreate projectCreate)
    {
        try
        {
            var entityToSave = Map(projectCreate);
            var entityResult = await demoProjectApplicationContext.AddAsync(entityToSave);
            var saveResult = await demoProjectApplicationContext.SaveChangesAsync();

            if (saveResult > 0)
                return Result<ProjectResponse>.Success((ProjectResponse)entityResult.Entity);

            return Result<ProjectResponse>.Failure("El Proyecto no pudo ser registrado");
        }
        catch (Exception ex)
        {
            return Result<ProjectResponse>.Failure(ex.Message);
        }
    }

    public async Task<Result<ProjectResponse>> UpdateAsync(ProjectUpdate projectUpdate)
    {
        try
        {
            var entityOnDb = await demoProjectApplicationContext.ProjectEntities.FirstAsync(x => x.RowGuid == projectUpdate.RowGuid);

            if (entityOnDb is null)
                return Result<ProjectResponse>.Failure("El proyecto no puedo ser actualizado");

            entityOnDb.ProjectId = projectUpdate.ProjectId;
            entityOnDb.Name = projectUpdate.Name;
            entityOnDb.CodeOne = projectUpdate.CodeOne;
            entityOnDb.CodeTwo = projectUpdate.CodeTwo;
            entityOnDb.Name = projectUpdate.Name;
            entityOnDb.Objetive = projectUpdate.Objetive;
            entityOnDb.Scope = projectUpdate.Scope;
            entityOnDb.Description = projectUpdate.Description;
            entityOnDb.AreaId = projectUpdate.AreaId;
            entityOnDb.SubAreaId = projectUpdate.SubAreaId;
            entityOnDb.PoaRoadmap = projectUpdate.PoaRoadMap;
            entityOnDb.WishDate = projectUpdate.WishDate;
            entityOnDb.IsCritical = projectUpdate.IsCritical;
            entityOnDb.UseNormalFlow = projectUpdate.UseNormalFlow;
            entityOnDb.PriorityTypeId = projectUpdate.PriorityTypeId;
            entityOnDb.ProjectTypeId = projectUpdate.ProjectTypeId;
            entityOnDb.ProjectDevelopmentTypeId = projectUpdate.ProjectDevelopmentTypeId;
            entityOnDb.RowGuid = projectUpdate.RowGuid;
            entityOnDb.UpdatedBy = projectUpdate.UpdateBy;
            entityOnDb.UpdatedAt = DateTime.Now;
            entityOnDb.IsActive = projectUpdate.IsActive;

            var saveResult = await demoProjectApplicationContext.SaveChangesAsync();

            return saveResult > 0 ?
                Result<ProjectResponse>.Success((ProjectResponse)entityOnDb) :
                Result<ProjectResponse>.Failure("El proyecto no puedo ser actualizado", (ProjectResponse)entityOnDb);
        }
        catch (Exception ex)
        {
            return Result<ProjectResponse>.Failure(ex.Message);
        }
    }

    private static ProjectEntity Map(ProjectCreate projectCreate)
        => new()
        {
            CodeOne = projectCreate.CodeOne,
            CodeTwo = projectCreate.CodeTwo,
            Name = projectCreate.Name,
            Objetive = projectCreate.Objetive,
            Scope = projectCreate.Scope,
            Description = projectCreate.Description,
            AreaId = projectCreate.AreaId,
            SubAreaId = projectCreate.SubAreaId,
            PoaRoadmap = projectCreate.PoaRoadMap,
            WishDate = projectCreate.WishDate,
            IsCritical = projectCreate.IsCritical,
            UseNormalFlow = projectCreate.UseNormalFlow,
            PriorityTypeId = projectCreate.PriorityTypeId,
            ProjectTypeId = projectCreate.ProjectTypeId,
            ProjectDevelopmentTypeId = projectCreate.ProjectDevelopmentTypeId,
            CreatedBy = projectCreate.CreateBy
        };
}
