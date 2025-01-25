namespace ConfigServer.Domain.interfaces

public interface IAuthService
{
        Task<User> LoginAsync(string username, string password);
        Task<User> SignupAsync(string username, string password);
}