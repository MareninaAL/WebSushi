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
    public class DrinkController : Controller
    {

        private readonly IDrink service;

        public DrinkController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                service = new DrinkServiceBD();
            }
            else
            {
                service = new DrinkServiceFile();

            }
        }

        [HttpGet]
        public ActionResult Drinks()
        {
            return View(service.GetList());
        }



        [HttpGet]
        public ActionResult AddDrink()

        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddDrink(Drink drink)
        {
            service.AddElement(drink);
            return RedirectToAction("Drinks");
        }

        public ActionResult DeleteDrink(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Drinks");
        }
    }
    }