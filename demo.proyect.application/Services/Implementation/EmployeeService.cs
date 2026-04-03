using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.application.Services.Contract;
using demo.proyect.application.Update;
using demo.proyect.common.Helpers.Results;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Services.Implementation;

public class EmployeeService(IUnitOfWork unitOfWork) : IEmployeeService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IEmployeeRepository employeeRepository = unitOfWork.EmployeeRepository;

    public async Task<Result<List<EmployeeResponse>>> GetAllAsync()
    {
        var employees = await employeeRepository.GetAllAsync();
        var list = employees.Select(x => (EmployeeResponse)x).ToList();
        return list.Success();
    }

    public async Task<Result<EmployeeResponse>> GetEmployeeByIdAsync(int id)
    {
        var employee = await employeeRepository.GetByExpressionAsync(x => x.EmployeeId == id);

        if(employee == null)
            return Result<EmployeeResponse>.Failure(Messages.EntityNotFound);

        var response = (EmployeeResponse)employee;
        return response.Success();
    }

    public async Task<Result<EmployeeResponse>> GetEmployeeByRowguidAsync(string rowguid)
    {
        var employee = await employeeRepository.GetByExpressionAsync(x => x.RowGuid == rowguid);

        if (employee == null)
            return Result<EmployeeResponse>.Failure(Messages.EntityNotFound);

        var response = (EmployeeResponse)employee;
        return response.Success();
    }

    public async Task<Result<EmployeeResponse>> CreateEmployeeAsync(EmployeeCreate employee)
    {
        var entity = Map(employee);
        var entityResult = await employeeRepository.AddAsync(entity);
        var saveResult = await unitOfWork.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<EmployeeResponse>.Failure(Messages.EntityNotCreated);
        
        var response = (EmployeeResponse)entityResult;
        return response.Success();
    }

    public async Task<Result<EmployeeResponse>> UpdateEmployeeAsync(EmployeeUpdate employee)
    {
        var entity = Map(employee);
        var entityResult = await employeeRepository.UpdateAsync(entity);
        var saveResult = await unitOfWork.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<EmployeeResponse>.Failure(Messages.EntityNotUpdate);

        var response = (EmployeeResponse)entityResult;
        return response.Success();
    }

    public async Task<Result<bool>> DeleteEmployeeAsync(string rowguid)
    {
        var entity = await employeeRepository.GetByExpressionAsync(x => x.RowGuid == rowguid);

        if (entity == null)
            return Result<bool>.Failure(Messages.EntityNotFound);

        var deleteResult = await employeeRepository.DeleteAsync(rowguid);
        return deleteResult.Success();
    }

    private static EmployeeEntity Map(EmployeeCreate create)
        => new() { 
            FirtName = create.FirstName,
            MiddleName = create.MiddleName,
            Surname = create.Surname,
            PhotoUrl = create.PhotoUrl,
            AreaId = create.AreaId,
            PositionId = create.PositionId,
            SuperiorEmployeeId = create.SuperiorEmployeeId,
            IsActive = true,
            CreatedBy = create.CreateBy,
            Gender = create.Gender,
            IsDeleted = false
        };

    private static EmployeeEntity Map(EmployeeUpdate update)
        => new() { 
            EmployeeId = update.EmployeeId,
            FirtName = update.FirstName,
            MiddleName = update.MiddleName,
            Surname = update.Surname,
            PhotoUrl = update.PhotoUrl,
            AreaId = update.AreaId,
            PositionId = update.PositionId,
            SuperiorEmployeeId = update.SuperiorEmployeeId,
            IsActive = update.IsActive,
            CreatedBy = update.CreateBy,
            Gender = update.Gender,
            IsDeleted = false
        };
}
