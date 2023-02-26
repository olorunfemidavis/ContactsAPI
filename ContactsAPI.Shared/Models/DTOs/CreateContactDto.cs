using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Shared.Models.DTOs;

public class CreateContactDto
{
    /// <summary>
    /// Contact Name
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Phone number in local format
    /// </summary>
    [Required]
    public string Phone { get; set; }
}