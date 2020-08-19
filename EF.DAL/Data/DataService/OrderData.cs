using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.EntityFrameworkCore;

namespace EF.DAL.Data
{
    public class OrderData : IDataService<Order>
    {
        private SQliteDBContext context;

        public OrderData()
        {
            context = new SQliteDBContext();
        }

        public async Task<Order> Create(Order entity)
        {
            var entityCreated = await context.Orders.AddAsync(entity);
            await context.SaveChangesAsync();
            return entityCreated.Entity;
        }

        public async Task<bool> Delete(int id)
        {

            var itemtoremove = context.Orders.Where(item => item.ID == id).First();
            context.Orders.Remove(itemtoremove);
            await context.SaveChangesAsync();
            return true;


        }

        public async Task<List<Order>> GetALL()
        {

            var Orders = await context.Orders.ToListAsync();
            return Orders;


        }

        public async Task<Order> Get(int id)
        {


            return await context.Orders.Where(item => item.ID == id).FirstAsync();

        }

        public async Task<Order> Update(int id, Order entity)
        {
            return await context.Orders.Where(item => item.ID == id).FirstAsync();
        }
    }
}
