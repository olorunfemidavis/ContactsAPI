using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Shared.Models.DTOs;

public class SetPhonePayload
{
    /// <summary>
    /// Phone number in local format
    /// </summary>
    /// <example>07001234455</example>
    [Required]
    public string Phone { get; set; }
}