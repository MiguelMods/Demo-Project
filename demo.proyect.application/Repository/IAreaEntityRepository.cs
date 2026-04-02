using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Update;

namespace demo.proyect.application.Repository;

public interface IAreaEntityRepository 
{
    Task<Result<List<AreaResponse>>> GetAllAsync();
    Task<Result<List<AreaResponse>>> GetAllSubAreasFromAreaId(long areaId);
    Task<Result<AreaResponse?>> GetByIdAsync(long id);
    Task<Result<AreaResponse?>> GetByRowGuidAsync(string rowGuid);
    Task<Result<AreaResponse>> AddAsync(AreaCreate areaEntity);
    Task<Result<AreaResponse>> UpdateAsync(AreaUpdate areaEntity);
    Task<Result<bool>> ActiveInactiveAsync(long id);
    Task<Result<bool>> ActiveInactiveAsync(string rowGuid);
    Task<Result<bool>> DeleteAsync(long id);
    Task<Result<bool>> DeleteAsync(string rowGuid);
}