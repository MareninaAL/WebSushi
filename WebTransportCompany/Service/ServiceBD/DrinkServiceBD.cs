using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceBD
{
    public class DrinkServiceBD : IDrink
    {
        private TCdbContext context = new TCdbContext();

        public void AddElement(BaseModel model)
        {
            context.Drinks.Add((Drink)model);
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Drink drink = context.Drinks.Find(id);
            if (drink != null)
            {
                context.Drinks.Remove(drink);
                context.SaveChanges();
            }
        }

        public BaseModel GetElement(int id)
        {
            Drink drink = context.Drinks.Find(id);
            return drink;
        }

        public List<BaseModel> GetList()
        {
            List<BaseModel> BaseModel = new List<BaseModel>();
            List<Drink> Drinks = context.Drinks.ToList();
            foreach (Drink drinks in Drinks)
            {
                BaseModel.Add(drinks);
            }
            return BaseModel;

          

        }

        public void UpdateElement(BaseModel model)
        {
            context.Entry((Drink)model).State = EntityState.Modified;
            context.SaveChanges();
        }
        


    }
}