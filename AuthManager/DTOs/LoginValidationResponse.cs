namespace AuthManager.DTOs
{
    public record LoginValidationResponse(bool IsValid, string? Role = null);
}
