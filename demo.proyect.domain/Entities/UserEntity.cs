namespace demo.proyect.domain.Entities;

public class UserEntity : BaseEntity
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool AskForNewPassword { get; set; }
    public bool IsBloked { get; set; }
    public ICollection<UsersProfilesEntity> UsersProfilesEntities { get; set; }
}
