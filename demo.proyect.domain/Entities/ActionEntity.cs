namespace demo.proyect.domain.Entities;

public class ActionEntity : CommonNameDescription
{
    public long ActionId { get; set; }
    public ActionTypeEntity ActionType { get; set; }
    public long ActionTypeId { get; set; }
}