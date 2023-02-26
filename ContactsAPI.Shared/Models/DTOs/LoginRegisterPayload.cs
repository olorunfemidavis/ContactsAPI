using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Shared.Models.DTOs;

public class LoginRegisterPayload
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
}