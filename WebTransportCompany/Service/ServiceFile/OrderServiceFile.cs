using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceFile
{
   public class OrdereServiceFile : AbstractService, IOrder
    {
        string Name = "Order";
        new string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Order";
        new XmlSerializer xsSubmit = new XmlSerializer(typeof(Salad));

        public OrdereServiceFile()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }


        public void AddRoll(Roll roll)
        {
            Order order = (Order)base.GetElement(roll.OrderId);
            if (order.Rolls.Find(rec => rec.Name.Equals(roll.Name)) != null)
            {
                throw new Exception("Уже есть ролл с таким названием");
            }
            else
            {
                roll.OrderId = order.Id;
                order.Rolls.Add(roll);
                UpdateElement(order);
            }
        }

        public Roll GetRoll(string name, int Roll_Id)
        {
            Order order = (Order)base.GetElement(Roll_Id);
            Roll roll = order.Rolls.FirstOrDefault(rec => rec.Name == name);
            return roll;
        }
    }
}