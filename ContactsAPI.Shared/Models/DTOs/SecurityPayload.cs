using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Shared.Models.DTOs;

/// <summary>
/// Payload for Login and Register
/// </summary>
public class SecurityPayload
{
    /// <summary>
    /// Username
    /// </summary>
    /// <example>Olorunfemi</example>
    [Required]
    public string UserName { get; set; }
    
    /// <summary>
    /// Password
    /// </summary>
    /// <example>str0ngP@ssw0rd</example>
    [Required]
    public string Password { get; set; }
}