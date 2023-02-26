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

    /// <summary>
    /// Get Contacts with UserId and Pagination. Exclude deleted items.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task<IEnumerable<Contact>> GetItemsAsync(uint page, uint pageSize, string userId)
    {
        var skip = (int)(page-1) * (int)pageSize;
        var limit = (int)Math.Max(0, pageSize);
        
        var list = _liteDb._contact.Query().Where(d => d.UserId == userId && !d.IsDeleted).Skip(skip).Limit(limit).ToEnumerable();
        return Task.FromResult(list);
    }

    /// <summary>
    /// Get Contact By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Contact> GetItemByIdAsync(string id)
    {
        return Task.FromResult(_liteDb._contact.FindById(id));
    }

    /// <summary>
    /// Add new contact
    /// </summary>
    /// <param name="item"></param>
    public Task InsertItemAsync(Contact item)
    {
        _liteDb._contact.Insert(item);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Delete Contact
    /// </summary>
    /// <param name="id"></param>
    public Task DeleteItemByIdAsync(string id)
    {
        _liteDb._contact.Delete(id);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Update Contact
    /// </summary>
    /// <param name="item"></param>
    public Task UpdateItemAsync(Contact item)
    {
        _liteDb._contact.Update(item);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Check if the Contact Exist
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> ItemExistsAsync(string id)
    {
        return Task.FromResult(_liteDb._contact.Exists(d => d.Id == id && !d.IsDeleted));
    }

    public Task<IEnumerable<Contact>> GetAllItemsAsync()
    {
        return Task.FromResult(_liteDb._contact.FindAll());
    }
}