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

    public async Task<IEnumerable<User>> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetItemByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task InsertItemAsync(User item)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteItemByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateItemAsync(User item)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ItemExistsAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UserExistsByUserNameAsync(string userName)
    {
       
    }
}