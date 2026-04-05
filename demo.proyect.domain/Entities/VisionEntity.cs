namespace demo.proyect.domain.Entities;

public class VisionEntity : CommonNameDescription 
{
    public long VisionId { get; set; }
    public CompanyEntity Company { get; set; }
    public long CompanyId { get; set; }
}