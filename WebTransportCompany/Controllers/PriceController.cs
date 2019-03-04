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
    public class PriceController: Controller
    {
        private readonly IAuto service;

        public PriceController()
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
        public ActionResult ListAutos()
        {
            var list = service.GetList();
            ViewBag.ListAutos = list;
            return View();
        }


        [HttpGet]
        public ActionResult Price(string Name, int AutoId)
        {

            Price priceModel = service.GetPrice(Name, AutoId);
            ViewBag.Prices = priceModel;
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddPrice(int Id)
        {
            var Auto = service.GetElement(Id);
            ViewBag.Auto = Auto;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddPrice(Price priceModel)
        {
            service.AddPrice(priceModel);
            return RedirectToAction("ListAutos");
        }


        
    }
}