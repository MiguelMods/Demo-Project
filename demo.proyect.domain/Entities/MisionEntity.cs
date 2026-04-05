namespace demo.proyect.domain.Entities;

public class  MisionEntity : CommonNameDescription
{
    public long MissionId { get; set; }
    public VisionEntity VisionEntity { get; set; }
    public long VisionId { get; set; }
}