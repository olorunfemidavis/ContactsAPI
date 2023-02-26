namespace ContactsAPI.Shared.Models.General;

public class BaseDbModel
{
    /// <summary>
    /// Date Entry was Added
    /// </summary>
    public DateTime DateAdded { get; set; }

    /// <summary>
    /// Date Entry was Updated
    /// </summary>
    public DateTime DateUpdated { get; set; }
    /// <summary>
    /// Set True if object is marked as Deleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Time to Live Field
    /// </summary>
    public int TTL { get; set; } = -1;
}