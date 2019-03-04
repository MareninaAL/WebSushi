using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;

namespace WebTransportCompany.Service.ServiceFile
{
    public class RollServiceFile : AbstractService, IRoll
    {

        string Name = "Roll";
        new string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Roll";
        new XmlSerializer xsSubmit = new XmlSerializer(typeof(Roll));

        public RollServiceFile()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }
    }
}