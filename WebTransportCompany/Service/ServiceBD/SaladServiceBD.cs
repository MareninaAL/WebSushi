using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceBD
{
    public class SaladServiceBD : ISalad
    {
        private TCdbContext context = new TCdbContext();

        public void AddElement(BaseModel model)
        {
            context.Salads.Add((Salad)model);
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Salad salad = context.Salads.Find(id);
            if (salad != null)
            {
                context.Salads.Remove(salad);
                context.SaveChanges();
            }
        }

        public BaseModel GetElement(int id)
        {
            Salad salad = context.Salads.Find(id);
            return salad;
        }

        public List<BaseModel> GetList()
        {
            List<BaseModel> BaseModel = new List<BaseModel>();
            List<Salad> Salads = context.Salads.ToList();
            foreach (Salad salads in Salads)
            {
                BaseModel.Add(salads);
            }
            return BaseModel;



        }

        public void UpdateElement(BaseModel model)
        {
            context.Entry((Salad)model).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}