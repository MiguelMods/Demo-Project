namespace demo.proyect.domain.Entities;

public class ColorEntity : CommonNameDescription
{
    public long ColorId { get; set; }
    public string CssClass { get; set; }
    public string Hexadecimal { get; set; }
}