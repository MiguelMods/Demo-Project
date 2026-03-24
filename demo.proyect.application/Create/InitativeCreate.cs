namespace demo.proyect.application.Create;

public class InitativeCreate : BaseCreate
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsReal { get; set; }
    public bool IsExecutable { get; set; }
    public long GoalId { get; set; }
    public long AreaId { get; set; }
}
