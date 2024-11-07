namespace AuthManager.Services.Interfaces
{
    public interface IJWTService
    {
        string GenerateToken(string email, string role);
    }
}
