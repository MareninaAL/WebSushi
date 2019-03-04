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
    public class SaladController : Controller
    {
        private readonly ISalad service;

        public SaladController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                service = new SaladServiceBD();
            }
            else
            {
                service = new SaladServiceFile();

            }
        }

        [HttpGet]
        public ActionResult Salads()
        {
            return View(service.GetList());
        }



        [HttpGet]
        public ActionResult AddSalad()

        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddSalad(Salad salad)
        {
            service.AddElement(salad);
            return RedirectToAction("Salads");
        }

        public ActionResult DeleteSalad(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Salads");
        }
    }
}