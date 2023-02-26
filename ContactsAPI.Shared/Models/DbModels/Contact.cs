using LiteDB;

namespace ContactsAPI.Shared.Models.DbModels;

/// <summary>
/// Contact Model
/// </summary>
public class Contact
{
    [BsonId]
    public string Id { get; set; } = ObjectId.NewObjectId().ToString();

    /// <summary>
    /// Contact Name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Phone number in local format
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Set True if object is marked as Deleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Time to Live Field
    /// </summary>
    public int TTL { get; set; } = -1;

}