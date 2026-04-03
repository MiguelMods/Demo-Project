using demo.proyect.domain.Entities;

namespace demo.proyect.application.Create;

public class EmployeeCreate : BaseCreate
{
    public string Code { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string Surname { get; set; }
    public string? PhotoUrl { get; set; }
    public long AreaId { get; set; }
    public long PositionId { get; set; }
    public long? SuperiorEmployeeId { get; set; }
    public GenderEnum Gender { get; set; }
    public bool CreateUserSystem { get; set; } = false;
}
