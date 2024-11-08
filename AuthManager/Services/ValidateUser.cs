using AuthManager.DTOs;
using AuthManager.Services.Interfaces;

namespace AuthManager.Services
{
    public class ValidateUser : IValidateUser
    {
        private IHttpClientFactory _clientFactory;
        
        public ValidateUser(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<LoginValidationResponse> ValidateUserLogin(string email, string password)
        {
            var client = _clientFactory.CreateClient();
            var userResponse = await client.GetAsync($"UserManagerApi/users/validate?username={email}&password={password}");

            if(userResponse.IsSuccessStatusCode)
                return new LoginValidationResponse(userResponse.IsSuccessStatusCode, await userResponse.Content.ReadAsStringAsync());

            return new LoginValidationResponse(false);
        }
    }
}
