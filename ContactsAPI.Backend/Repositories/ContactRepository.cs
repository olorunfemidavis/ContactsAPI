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
    
}