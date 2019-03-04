using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceFile
{
   public class SaladServiceFile : AbstractService, ISalad
    {
        string Name = "Salad";
        new string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Salad";
        new XmlSerializer xsSubmit = new XmlSerializer(typeof(Salad));

        public SaladServiceFile()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }
    }
}