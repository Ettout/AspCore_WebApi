using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EF.DAL.Data;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.EntityFrameworkCore.Internal;

namespace projet_WebApi_1.Service
{
    public class AutoRepository : IAutoRepository
    {
        private IDataService<User> _userData;

        public AutoRepository(IDataService<User> userData)
        {
            _userData = userData;
        }

        public async Task<bool> Login(string username, string password)
        {

            var users = await _userData.GetALL();
            return users.Any(x => x.Name == username && x.PassWord == password);
        }

        public async Task<User> Register(User user)
        {
            /*
             a changer des que la methode aui traite le mot de passe est prete ...
             */

            var createdUser = await _userData.Create(user);

            return createdUser;

        }

        public async Task<bool> UserExist(string username)
        {
            var users = await _userData.GetALL();
            return users.Any(x => x.Name == username);
        }
    }
}
