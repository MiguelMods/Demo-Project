namespace demo.proyect.domain.Entities;

public class CompanyEntity : CommonNameDescription
{
    public long CompanyId { get; set; }
    public SocialContributionLabelEntity SocialContributionLabelEntity { get; set; }
    public string SocualContributionLabel { get; set; }
    public string SocialContributionLabelNumber { get; set; }
    public StructureTypeEntity StructureType { get; set; }
    public long StructureTypeId { get; set; }
    public CompanyTypeEntity CompanyType { get; set; }
    public long CompanyTypeId { get; set; }
}