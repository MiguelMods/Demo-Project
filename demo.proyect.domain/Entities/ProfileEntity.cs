namespace demo.proyect.domain.Entities;

public class ProfileEntity : BaseEntity
{
    public long ProfileId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<UsersProfilesEntity> UsersProfilesEntities { get; set; }
}
