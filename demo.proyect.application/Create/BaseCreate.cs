namespace demo.proyect.application.Create;

public abstract class BaseCreate
{
    public bool IsActive { get; set; }
    public string CreateBy {  get; set; }
    public string? UpdateBy { get; set; }
    public string RowGuid { get; set; }
}
