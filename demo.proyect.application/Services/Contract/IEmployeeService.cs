using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Update;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Services.Contract;

public interface IEmployeeService
{
    Task<Result<List<EmployeeResponse>>> GetAllAsync();
    Task<Result<EmployeeResponse>> GetEmployeeByIdAsync(int id);
    Task<Result<EmployeeResponse>> GetEmployeeByRowguidAsync(string rowguid);
    Task<Result<EmployeeResponse>> CreateEmployeeAsync(EmployeeCreate employee);
    Task<Result<EmployeeResponse>> UpdateEmployeeAsync(EmployeeUpdate employee);
    Task<Result<bool>> DeleteEmployeeAsync(string rowguid);
}
