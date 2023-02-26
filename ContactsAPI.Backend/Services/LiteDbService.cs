using ContactsAPI.Shared.Models;
using ContactsAPI.Shared.Models.DbModels;
using LiteDB;

namespace ContactsAPI.Backend.Services;

public class LiteDbService
{
    public readonly ILiteCollection<Contact> _contact;

    public LiteDbService()
    {
        string liteDbLocation = Environment.GetEnvironmentVariable(nameof(liteDbLocation)) ?? @"C:\Temp\ContactData.db";

        var database = new LiteDatabase(liteDbLocation);

        #region LoadCollections

        _contact = database.GetCollection<Contact>(nameof(Contact).ToLower());

        #endregion
    }
}