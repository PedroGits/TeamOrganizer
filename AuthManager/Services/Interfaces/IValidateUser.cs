using AuthManager.DTOs;

namespace AuthManager.Services.Interfaces
{
    public interface IValidateUser
    {
       Task<LoginValidationResponse> ValidateUserLogin(string email, string password);
    }
}
