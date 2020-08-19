using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.EntityFrameworkCore;

namespace EF.DAL.Data.DataService
{
    public class CategoryData : IDataService<Category>
    {
        private SQliteDBContext context;

        public CategoryData()
        {
            context = new SQliteDBContext();
        }

        public async Task<Category> Create(Category entity)
        {
            var entityCreated = await context.Categories.AddAsync(entity);
            await context.SaveChangesAsync();
            return entityCreated.Entity;
        }

        public async Task<bool> Delete(int id)
        {

            var itemtoremove = context.Categories.Where(item => item.ID == id).First();
            context.Categories.Remove(itemtoremove);
            await context.SaveChangesAsync();
            return true;


        }

        public async Task<List<Category>> GetALL()
        {

            var Categorys = await context.Categories.ToListAsync();
            return Categorys;


        }

        public async Task<Category> Get(int id)
        {


            return await context.Categories.Where(item => item.ID == id).FirstAsync();

        }

        public async Task<Category> Update(int id, Category entity)
        {
            return await context.Categories.Where(item => item.ID == id).FirstAsync();
        }
    }

}
