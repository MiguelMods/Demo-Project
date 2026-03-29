using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Update;

namespace demo.proyect.application.Repository;

public interface IUserRepository
{
    Task<Result<UserResponse>> AddAsync(UserCreate userCreate);
    Task<Result<UserResponse>> UpdateAsync(UserUpdate userUpdate);
    Task<Result<UserResponse>> GetUserByUserName(string userName);
    Task<Result<bool>> BlockUserAsync(string userName);
    Task<Result<bool>> UnBlockUserAsync(string userName);
}