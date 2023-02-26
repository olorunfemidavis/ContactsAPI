using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Shared.Models.DTOs;

/// <summary>
/// Payload for Login and Register
/// </summary>
public class SecurityPayload
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
}