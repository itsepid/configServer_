namespace ConfigServer.Domain.interfaces

public interface IAuthService
{
        Task<string> LoginAsync(string username, string password);
        Task SignupAsync(string username, string password);
}