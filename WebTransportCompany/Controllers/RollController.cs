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
    public class RollController : Controller
    {
        private readonly IOrder service;

        public RollController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                service = new OrderServiceBD();
            }
            else
            {
                service = new OrdereServiceFile();

            }
        }

        [HttpGet]
        public ActionResult ListOrders()
        {
            var list = service.GetList();
            ViewBag.ListOrders = list;
            return View();
        }


        [HttpGet]
        public ActionResult Roll(string Name, int OrderId)
        {

            Roll rollModel = service.GetRoll(Name, OrderId);
            ViewBag.Rolls = rollModel;
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
        public ActionResult AddRoll(Roll rollModel)
        {
            service.AddRoll(rollModel);
            return RedirectToAction("Orders");
        }


    }
}