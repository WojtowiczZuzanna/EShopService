using Microsoft.Extensions.Options;
using User.Domain.Exceptions;
using User.Domain.Models;

namespace User.Application;

public class LoginService : ILoginService
{
    private readonly IJwtTokenService _jwtTokenService;

    public LoginService(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    public string Login(string username, string password)
    {
        // Tymczasowa weryfikacja użytkownika (na sztywno)
        if (username != "admin" || password != "password")
        {
            throw new InvalidCredentialsException();
        }

        // Przykładowe dane użytkownika
        var userId = 1;
        var roles = new List<string> { "Administrator" };

        return _jwtTokenService.GenerateToken(userId, roles);
    }
}



//using System.Security.Authentication;
//using User.Application;
//using User.Domain;
//using User.Domain.Exceptions;
//using User.Domain.Repositories;

//public class LoginService : ILoginService
//{
//    private readonly IUserRepository _userRepository;
//    private readonly IJwtTokenService _jwtTokenService;

//    public LoginService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
//    {
//        _userRepository = userRepository;
//        _jwtTokenService = jwtTokenService;
//    }

//    public async Task<bool> AuthenticateAsync(string username, string password)
//    {
//        var user = await _userRepository.GetByUsernameAsync(username);

//        if (user == null || user.Password != password) 
//        {
//            return false;
//        }

//        return true;
//    }
//}
