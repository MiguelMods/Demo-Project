namespace demo.proyect.domain.Entities;

public class UsersProfilesEntity : BaseEntity
{
    public long UserId { get; set; }
    public long ProfileId { get; set; }
    public UserEntity User { get; set; }
    public ProfileEntity Profile { get; set; }
}