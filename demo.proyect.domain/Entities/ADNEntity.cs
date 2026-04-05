namespace demo.proyect.domain.Entities;

public class ADNEntity : CommonNameDescription
{
    public long ADNId { get; set; }
    public PeriodEntity Period { get; set; }
    public long PeriodId { get; set; }
    public VisionEntity Vision { get; set; }
    public long VisionId { get; set; }
}