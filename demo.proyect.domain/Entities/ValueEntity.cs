namespace demo.proyect.domain.Entities;

public class ValueEntity : CommonNameDescription
{
    public long ValueId { get; set; }
    public VisionEntity VisionEntity { get; set; }
    public long VisionId { get; set; }
}