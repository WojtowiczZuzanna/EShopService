using Microsoft.AspNetCore.Mvc;
using User.Domain;

namespace User.Application;

public interface ILoginService
{
    //Task<bool> AuthenticateAsync(string username, string password);
    string Login(string username, string password);
}
