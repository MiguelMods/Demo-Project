using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.application.Services.Contract;
using System.Security.Claims;

namespace demo.proyect.application.Services.Implementation;

public class UserService(IUnitOfWork unitOfWork, ISessionService sessionService) : IUserService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly ISessionService sessionService = sessionService;
    private readonly IUserRepository userRepository = unitOfWork.UserRepository;

    public async Task<Result<ClaimsPrincipal>> SiginAsync(string username, string password)
    {
        var user = await userRepository.GetUserByUserName(username);

        if (!user.IsSuccess)
            return Result<ClaimsPrincipal>.Failure(user.Message);

        var userNameAndPasswordIsValid = user.Data.Password == password;
        var session = await sessionService.CreateSessionAsync(user.Data);

        if (!session.IsSuccess)
            return Result<ClaimsPrincipal>.Failure("");

        return session.Data.Success();
    }
}
