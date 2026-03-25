using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Update;

namespace demo.proyect.application.Repository;

public interface IAreaEntityRepository 
{
    Task<List<AreaResponse>> GetAllAsync();
    Task<AreaResponse?> GetByIdAsync(long id);
    Task<AreaResponse?> GetByRowGuidAsync(string rowGuid);
    Task<AreaResponse> AddAsync(AreaCreate areaEntity);
    Task<AreaResponse> UpdateAsync(AreaUpdate areaEntity);
    Task<bool> ActiveInactiveAsync(long id);
    Task<bool> ActiveInactiveAsync(string rowGuid);
    Task<bool> DeleteAsync(long id);
    Task<bool> DeleteAsync(string rowGuid);
}