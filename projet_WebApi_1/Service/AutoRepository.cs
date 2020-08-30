using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

        public async Task<User> Login(string username, string password)
        {

            var users = await _userData.GetALL();
            return users.FirstOrDefault(x => x.Name == username && ValidatePassword(password, x.PasswordSalt, x.PasswordHash));
        }

        public async Task<User> Register(User user, string password)
        {

            byte[] passwordHash;
            byte[] passwordSalt;
            CreateHash(password, out passwordSalt, out passwordHash);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var createdUser = await _userData.Create(user);

            return createdUser;

        }

        public async Task<bool> UserExist(string username)
        {
            var users = await _userData.GetALL();
            return users.Any(x => x.Name == username);
        }

        #region private methode
        private void CreateHash(string password, out byte[] salt, out byte[] hash)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            salt = new byte[24];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            hash = PBKDF2(password, salt, 1000, 24);

        }
        public bool ValidatePassword(string password, byte[] salt, byte[] hash)
        {


            byte[] testHash = PBKDF2(password, salt, 1000, 24);
            return SlowEquals(hash, testHash);
        }
        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
        private byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
        #endregion
    }
}
