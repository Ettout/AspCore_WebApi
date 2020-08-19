using System;
using System.Threading.Tasks;
using EF.DAL.Model;

namespace projet_WebApi_1.Service
{
    public interface IAutoRepository
    {

        Task<User> Register(User user);

        Task<bool> Login(string username, string password);

        Task<bool> UserExist(string username);


    }
}
