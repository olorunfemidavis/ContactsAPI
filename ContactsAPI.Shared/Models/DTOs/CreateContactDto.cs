using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Shared.Models.DTOs;

/// <summary>
/// Model for Contact Creation
/// </summary>
public class CreateContactDto
{
    /// <summary>
    /// Contact Name
    /// </summary>
    /// <example>Olorufemi</example>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Phone number in local format
    /// </summary>
    /// <example>07001234455</example>
    [Required]
    public string Phone { get; set; }
}