using ContactsAPI.Shared.Models.General;
using LiteDB;

namespace ContactsAPI.Shared.Models.DbModels;

public class User:BaseDbModel
{
    [BsonId]
    public string Id { get; set; } = ObjectId.NewObjectId().ToString();

    /// <summary>
    /// User Name
    /// </summary>
    public string UserName { get; set; }
    
    /// <summary>
    /// Encoded Password
    /// </summary>
    public string Password { get; set; }
    
}