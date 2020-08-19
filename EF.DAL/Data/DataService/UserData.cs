using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.EntityFrameworkCore;

namespace EF.DAL.Data
{
    public class UserData : IDataService<User>
    {

        private SQliteDBContext context;

        public UserData()
        {
            context = new SQliteDBContext();
        }




        public async Task<User> Create(User entity)
        {
            var entityCreated = await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
            return entityCreated.Entity;
        }

        public async Task<bool> Delete(int id)
        {

            var itemtoremove = context.Users.Where(item => item.ID == id).First();
            context.Users.Remove(itemtoremove);
            await context.SaveChangesAsync();
            return true;


        }

        public async Task<List<User>> GetALL()
        {

            var users = await context.Users.ToListAsync();
            return users;


        }

        public async Task<User> Get(int id)
        {


            return await context.Users.Where(item => item.ID == id).FirstAsync();

        }

        public async Task<User> Update(int id, User entity)
        {
            return await context.Users.Where(item => item.ID == id).FirstAsync();
        }
    }
}
