using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class UserResponse : BaseResponse
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool AskForNewPassword { get; set; }
    public bool IsBloked { get; set; }
    
    public static explicit operator UserResponse(UserEntity userEntity)
        => new() {
            UserId = userEntity.UserId,
            UserName = userEntity.UserName,
            Password = userEntity.Password,
            AskForNewPassword = userEntity.AskForNewPassword,
            IsBloked = userEntity.IsBloked,
            IsActive = userEntity.IsActive,
            CreatedAt = userEntity.CreatedAt,
            CreatedBy = userEntity.CreatedBy,
            UpdatedAt = userEntity.UpdatedAt,
            UpdatedBy = userEntity.UpdatedBy,
            RowGuid = userEntity.RowGuid,
        };
}
