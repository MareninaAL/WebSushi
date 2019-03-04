using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceFile
{
    public class DrinkServiceFile : AbstractService, IDrink
    {
        string Name = "Drink";
        new string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Drink";
        new XmlSerializer xsSubmit = new XmlSerializer(typeof(Drink));

        public DrinkServiceFile()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }

    
        
    }
}