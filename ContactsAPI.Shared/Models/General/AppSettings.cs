namespace ContactsAPI.Shared.Models.General;

public class AppSettings
{
    public string Secret { get; set; }
    
    /// <summary>
    /// Token Expiration in Days
    /// </summary>
    public int TokenExpiration { get; set; }
}