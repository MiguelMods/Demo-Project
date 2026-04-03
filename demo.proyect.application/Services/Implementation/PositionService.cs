using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.application.Services.Contract;

namespace demo.proyect.application.Services.Implementation;

internal class PositionService(IUnitOfWork unitOfWork) : IPositionService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result<List<PositionResponse>>> GetAllAsync()
    {
        var positions = await unitOfWork.PositionRepository.GetAllAsync();
        var positionList = positions.Select(x => (PositionResponse)x).ToList();
        return positionList.Success();
    }
}
