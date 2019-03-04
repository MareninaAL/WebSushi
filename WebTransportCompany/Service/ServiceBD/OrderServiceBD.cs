using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceBD
{
    public class OrderServiceBD: IOrder
    {
        private TCdbContext context = new TCdbContext();

      

        public void AddElement(BaseModel model)
        {
         //   context.Orders.Add((Order)model);
            context.Orders.Add(new Order
            {
                Id = model.Id,
                Name = model.Name,
                CreateDate = DateTime.Now.Date
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Order b = context.Orders.Find(id);
            if (b != null)
            {
                context.Orders.Remove(b);
                context.SaveChanges();
            }
        }

        public BaseModel GetElement(int id)
        {
            Order order = context.Orders.Find(id);
            return order;
        }

        public List<BaseModel> GetList()
        {
            List<BaseModel> BaseModel = new List<BaseModel>();
            List<Order> Orders = context.Orders.ToList();
         //   List<Price> Price = context.Prices.ToList();
            foreach (Order Order in Orders)
            {
               // Order.Prices = Price.FindAll(rec => rec.OrderId == Order.Id);
                BaseModel.Add(Order);
            }
            return BaseModel;
        } 

        public void UpdateElement(BaseModel model)
        {
            context.Entry((Order)model).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AddRoll(Roll Roll)
        {
            Order Order = context.Orders.Find(Roll.OrderId);
            if (Order.Rolls == null)
            {
                Order.Rolls = new List<Roll>();
            }
            Order.Rolls.Add(Roll);
            context.SaveChanges();
        }

        public Roll GetRoll(string name, int OrderId)
        {
            Roll Roll = context.Rolls.FirstOrDefault(rec => rec.Name.Equals(name) && rec.OrderId == rec.Order.Id);
            return Roll;
        }
    }
}
    