using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.EntityFrameworkCore;

namespace EF.DAL.Data.DataService
{
    public class ItemData : IDataService<Item>
    {
        private SQliteDBContext context;

        public ItemData()
        {
            context = new SQliteDBContext();
        }




        public async Task<Item> Create(Item entity)
        {
            var entityCreated = await context.items.AddAsync(entity);
            await context.SaveChangesAsync();
            return entityCreated.Entity;
        }

        public async Task<bool> Delete(int id)
        {

            var itemtoremove = context.items.Where(item => item.ID == id).First();
            context.items.Remove(itemtoremove);
            await context.SaveChangesAsync();
            return true;


        }

        public async Task<List<Item>> GetALL()
        {

            var Items = await context.items.ToListAsync();
            return Items;


        }

        public async Task<Item> Get(int id)
        {


            return await context.items.Where(item => item.ID == id).FirstAsync();

        }

        public async Task<Item> Update(int id, Item entity)
        {
            return await context.items.Where(item => item.ID == id).FirstAsync();
        }
    }

}
