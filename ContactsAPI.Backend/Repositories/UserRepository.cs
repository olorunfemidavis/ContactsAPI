using ContactsAPI.Backend.Interfaces;
using ContactsAPI.Backend.Services;
using ContactsAPI.Shared.Models.DbModels;

namespace ContactsAPI.Backend.Repositories;

public class UserRepository : IEntityRepository<User>
{
    private LiteDbService _liteDb;

    public UserRepository(LiteDbService liteDb)
    {
        _liteDb = liteDb;
    }
    
/// <summary>
/// Get a User by Id
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
    public Task<User> GetItemByIdAsync(string id)
    {
        return Task.FromResult(_liteDb._user.FindById(id));
    }

/// <summary>
/// Add new User
/// </summary>
/// <param name="item"></param>
    public Task InsertItemAsync(User item)
{
    _liteDb._user.Insert(item);
    return Task.CompletedTask;
}

/// <summary>
/// Delete User by Id
/// </summary>
/// <param name="id"></param>
    public Task DeleteItemByIdAsync(string id)
{
    _liteDb._user.Delete(id);
    return Task.CompletedTask;
}

/// <summary>
/// Update User
/// </summary>
/// <param name="item"></param>
    public Task UpdateItemAsync(User item)
{
    _liteDb._user.Update(item);
    return Task.CompletedTask;
}

/// <summary>
/// Check if a User Exist
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
    public Task<bool> ItemExistsAsync(string id)
    {
        return Task.FromResult(_liteDb._user.Exists(d => d.Id == id && !d.IsDeleted));
    }

/// <summary>
/// Get User by UserName
/// </summary>
/// <param name="userName"></param>
/// <returns></returns>
    public Task<User> GetUserByUserNameAsync(string userName)
    {
        return Task.FromResult(_liteDb._user.FindOne(d=>d.UserName == userName && !d.IsDeleted));
    }

/// <summary>
/// Check if User by UserName Exists
/// </summary>
/// <param name="userName"></param>
/// <returns></returns>
    public Task<bool> UserExistsByUserNameAsync(string userName)
    {
        return Task.FromResult(_liteDb._user.Exists(d => d.UserName == userName));
    }
}