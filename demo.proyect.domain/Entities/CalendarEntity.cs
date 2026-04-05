namespace demo.proyect.domain.Entities;

public class CalendarEntity : BaseEntity
{
    public DateTime Date { get; set; }
    public bool IsWorking { get; set; }
    public string Comment { get; set; }
}