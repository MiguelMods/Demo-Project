namespace demo.proyect.domain.Entities;

public class StateEntity : CommonNameDescription
{
    public long StateId { get; set; }
    public ColorEntity Color { get; set; }
    public long ColorId { get; set; }
}
