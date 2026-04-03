using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class PositionResponse : BaseResponse
{
    public long PositionId { get; set; }
    public string Name { get; set; }
    public static explicit operator PositionResponse(PositionEntity position)
    {
        return new PositionResponse
        {
            PositionId = position.PositionId,
            Name = position.Name
        };
    }
}
