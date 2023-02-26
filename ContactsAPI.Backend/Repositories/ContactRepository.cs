using ContactsAPI.Backend.Interfaces;
using ContactsAPI.Backend.Services;
using ContactsAPI.Shared.Models.DbModels;

namespace ContactsAPI.Backend.Repositories;

public class ContactRepository : IEntityRepository<Contact>
{
    private LiteDbService _liteDb;

    public ContactRepository(LiteDbService liteDb)
    {
        _liteDb = liteDb;
    }

    public async Task<IEnumerable<Contact>> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Contact?> GetItemByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task InsertItemAsync(Contact item)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteItemByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateItemAsync(Contact item)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ItemExistsAsync(string id)
    {
        throw new NotImplementedException();
    }
}