namespace demo.proyect.domain.Entities;

public class PeriodicityEntity : CommonNameDescription
{
    public long PeriodicityId { get; set; }
    public string Code { get; set; }
    public int OpenPeriod { get; set; }
    public int ToPrintInd { get; set; }
}