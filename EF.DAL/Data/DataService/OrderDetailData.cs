using System;
using System.Collections.Generic;
using System.Linq;
using EF.DAL.Service;
using EF.DAL.Model;



namespace EF.DAL.Data.DataService
{
    public class OrderDetailData
    {
        public void Create(OrderDetail entity)
        {

            using (SQliteDBContext context = new SQliteDBContext())
            {
                context.OrderDetails.Add(entity);
                context.SaveChangesAsync();

            }
        }

        public void Delete(int id_order, int id_item)
        {
            using (SQliteDBContext context = new SQliteDBContext())
            {
                var orderDetail = context.OrderDetails.Where(o => o.ItemID == id_item && o.OrderID == id_order).First();
                context.OrderDetails.Remove(orderDetail);
                context.SaveChangesAsync();

            }
        }

        public List<OrderDetail> GetALL()
        {
            SQliteDBContext context = new SQliteDBContext();
            return context.OrderDetails.ToList();

        }

        public OrderDetail Get(int id_order, int id_item)
        {
            using (SQliteDBContext context = new SQliteDBContext())
            {

                return context.OrderDetails.Where(o => o.ItemID == id_item && o.OrderID == id_order).First();
            }
        }

        public OrderDetail Update(int id, OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }

}
