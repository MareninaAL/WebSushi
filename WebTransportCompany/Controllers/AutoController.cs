using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTransportCompany.Models;
using WebTransportCompany.Service.Interface;
using WebTransportCompany.Service.ServiceBD;
using WebTransportCompany.Service.ServiceFile;

namespace WebTransportCompany.Controllers
{
    public class AutoController: Controller
    {
        private readonly IAuto service;

        public AutoController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                service = new AutoServiceBD();
            }
            else
            {
                service = new AutoServiceFile();

            }
        }

        [HttpGet]
        public ActionResult Autos()
        {
            return View(service.GetList());
        }


     
        [HttpGet]
        public ActionResult AddAuto()

        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddAuto(Auto auto)
        {
            service.AddElement(auto);
            return RedirectToAction("Autos");
        }

        public ActionResult DeleteAuto(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Autos");
        }




    }
}