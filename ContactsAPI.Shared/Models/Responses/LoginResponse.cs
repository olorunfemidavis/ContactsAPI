namespace ContactsAPI.Shared.Models.Responses;

/// <summary>
/// Login Response Model
/// </summary>
public class LoginResponse
{
    /// <summary>
    /// JWT TOken
    /// </summary>
    public string Token { get; set; }
    
    /// <summary>
    /// Date Expiration of the Token. 
    /// </summary>
    public DateTime ExpiryDate { get; set; }
    
}