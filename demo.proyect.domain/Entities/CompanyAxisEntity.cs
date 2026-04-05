namespace demo.proyect.domain.Entities;

public class CompanyAxisEntity : CommonNameDescription
{
    public long CompanyAxisId { get; set; }
    public PeriodEntity Period { get; set; }
    public long PeriodId { get; set; }
    public ADNEntity ADNEntity { get; set; }
    public long ADNId { get; set; }
}