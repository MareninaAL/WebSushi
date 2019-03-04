using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceBD
{
    public class RollServiceBD : IRoll
    {
        private TCdbContext context = new TCdbContext();

        public void AddElement(BaseModel model)
        {
            context.Rolls.Add((Roll)model);
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Roll roll = context.Rolls.Find(id);
            if (roll != null)
            {
                context.Rolls.Remove(roll);
                context.SaveChanges();
            }
        }

        public BaseModel GetElement(int id)
        {
            Roll roll = context.Rolls.Find(id);
            return roll;
        }

        public List<BaseModel> GetList()
        {
            List<BaseModel> BaseModel = new List<BaseModel>();
            List<Roll> Rolls = context.Rolls.ToList();
            foreach (Roll rolls in Rolls)
            {
                BaseModel.Add(rolls);
            }
            return BaseModel;



        }

        public void UpdateElement(BaseModel model)
        {
            context.Entry((Roll)model).State = EntityState.Modified;
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