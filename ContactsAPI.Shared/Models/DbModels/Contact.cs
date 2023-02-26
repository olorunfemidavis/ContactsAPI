using ContactsAPI.Shared.Models.General;
using LiteDB;

namespace ContactsAPI.Shared.Models.DbModels;

/// <summary>
/// Contact Model
/// </summary>
public class Contact:BaseDbModel
{
    [BsonId]
    public string Id { get; set; } = ObjectId.NewObjectId().ToString();

    public string UserId { get; set; }
    /// <summary>
    /// Contact Name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Phone number in local format
    /// </summary>
    public string Phone { get; set; }

}