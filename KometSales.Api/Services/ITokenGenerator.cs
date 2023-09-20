namespace KometSales.Api.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(string username, string roleName);
    }
}
