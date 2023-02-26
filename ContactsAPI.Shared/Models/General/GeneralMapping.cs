using AutoMapper;
using ContactsAPI.Shared.Models.DbModels;
using ContactsAPI.Shared.Models.DTOs;

namespace ContactsAPI.Shared.Models.General;

public class GeneralMapping: Profile
{
    public GeneralMapping()
    {
        CreateMap<Contact, ContactResponse>().ReverseMap();
        CreateMap<CreateContactDto, Contact>();
    }
}