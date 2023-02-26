using ContactsAPI.Shared.Models.DbModels;
using LiteDB;

namespace ContactsAPI.Backend.Services;

public class LiteDbService
{
    public readonly ILiteCollection<Contact> _contact;
    public readonly ILiteCollection<User> _user;


    public LiteDbService()
    {
        string liteDbLocation = Environment.GetEnvironmentVariable(nameof(liteDbLocation)) ?? Path.Combine(Path.GetTempPath(),"ContactData.db");

        var database = new LiteDatabase(liteDbLocation);

        #region LoadCollections

        _contact = database.GetCollection<Contact>(nameof(Contact).ToLower());
        _user = database.GetCollection<User>(nameof(User).ToLower());

        #endregion
    }
}