namespace demo.proyect.domain.Entities;

public class ActivityEntity : CommonNameDescription
{
    public long ActivityId { get; set; }
    public DateTime Date { get; set; }
    public ActivityTypeEntity ActivityType { get; set; }
    public string Comment { get; set; }
}