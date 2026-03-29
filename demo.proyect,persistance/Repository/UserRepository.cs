using demo.proyect.application;
using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.application.Update;
using demo.proyect.common.Helpers.Results;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.proyect_persistance.Repository;

public class UserRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IUserRepository
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    private readonly DbSet<UserEntity> userEntities = demoProjectApplicationContext.UserEntities;

    public async Task<Result<UserResponse>> AddAsync(UserCreate userCreate)
    {
        var entity = Map(userCreate);
        var entityResult = await userEntities.AddAsync(entity);
        var saveResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!saveResult)
            return Result<UserResponse>.Failure(Messages.EntityNotCreated);

        var newEntity = (UserResponse)entityResult.Entity;
        return newEntity.Success();
    }

    public async Task<Result<bool>> BlockUserAsync(string userName)
    {
        var userOnDb = await userEntities.FirstOrDefaultAsync(x => x.UserName == userName);

        if (userOnDb is null)
            return Result<bool>.Failure(Messages.EntityNotFound);

        userOnDb?.IsBloked = true;
        var updateResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!updateResult)
            return Result<bool>.Failure(Messages.EntityNotUpdate);

        return updateResult.Success();
    }

    public async Task<Result<UserResponse>> GetUserByUserName(string userName)
    {
        var user = await userEntities.FirstOrDefaultAsync(x => x.UserName == userName);

        if (user is null)
            return Result<UserResponse>.Failure("Usuario o Contraseña incorrectos");

        var response = (UserResponse)user;
        return response.Success();
    }

    public async Task<Result<bool>> UnBlockUserAsync(string userName)
    {
        var userOnDb = await userEntities.FirstOrDefaultAsync(x => x.UserName == userName);

        if (userOnDb is null)
            return Result<bool>.Failure(Messages.EntityNotFound);

        userOnDb?.IsBloked = true;
        var updateResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!updateResult)
            return Result<bool>.Failure(Messages.EntityNotUpdate);

        return updateResult.Success();
    }

    public async Task<Result<UserResponse>> UpdateAsync(UserUpdate userUpdate)
    {
        var userOnDb = await userEntities.FirstOrDefaultAsync(x => x.RowGuid == userUpdate.RowGuid);

        if (userOnDb is null)
            return Result<UserResponse>.Failure(Messages.EntityNotFound);

        userOnDb.UserName = userUpdate.UserName;
        userOnDb.Password = userUpdate.Password;
        userOnDb.IsBloked = userUpdate.IsBloked;
        userOnDb.UpdatedBy = userUpdate.UpdateBy;
        userOnDb.UpdatedAt = DateTime.Now;
        var updateResult = await demoProjectApplicationContext.SaveChangesAsync() > 0;

        if (!updateResult)
            return Result<UserResponse>.Failure(Messages.EntityNotUpdate);

        var response = (UserResponse)userOnDb;
        return response.Success();
    }

    private static UserEntity Map(UserCreate user) => new() { 
        UserName = user.UserName,
        Password = user.Password,
        IsBloked = user.IsBloked,
        AskForNewPassword = false,
        CreatedBy = user.CreateBy
    };
}
