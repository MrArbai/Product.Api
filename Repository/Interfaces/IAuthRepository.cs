using Microsoft.AspNetCore.Identity;
using Product.Api.Models;

namespace Product.Api.Repository.Interfaces.Auth
{
    public interface IAuthRepository
    {
        
        Task<User> Register(User user);
        Task<bool> UserExists(string username);
        Task<User> Login(string username, string password);
    }
}