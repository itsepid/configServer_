using System;
using System.Threading.Tasks;
using ConfigServer.Domain.Entities;
using ConfigServer.Application.Interfaces;
using ConfigServer.Application.DTOs;
using ConfigServer.Infrastructure.Repositories;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public UserService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<string> RegisterAsync(int Id, string password)
    {
       
        var existingUser = await _userRepository.GetByIdAsync(Id);
        if (existingUser != null)
            throw new Exception("User already exists.");

        var user = new User(Id, password);
        await _userRepository.AddAsync(user);

        return _jwtService.GenerateJwt(user);
    }

    public async Task<string> LoginAsync(int Id, string password)
    {
        var user = await _userRepository.GetByEmailAsync(Id);
        if (user == null || user.Password != password) 
            throw new Exception("Invalid credentials.");

        
        return _jwtService.GenerateJwt(user);
    }
}
