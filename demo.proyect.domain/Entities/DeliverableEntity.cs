namespace demo.proyect.domain.Entities;

public class DeliverableEntity : CommonNameDescription
{
    public long DeliverableId { get; set; }
    public string Ubication { get; set; }
    public DeliverableTypeEntity DeliverableType { get; set; }
    public long DeliverableTypeId { get; set; }
}