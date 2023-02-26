using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Shared.Models.DTOs;

public class SetPhonePayload
{
    /// <summary>
    /// Phone number in local format
    /// </summary>
    [Required]
    public string Phone { get; set; }
}