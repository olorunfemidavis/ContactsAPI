using ContactsAPI.Shared.Models.DbModels;

namespace ContactsAPI.Backend.Interfaces;

public interface IJwtAuthentication
{
    Task<(string, DateTime)> Authenticate(User user);
}