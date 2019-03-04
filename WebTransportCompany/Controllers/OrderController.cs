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
    public class OrderController : Controller
    {

        private readonly IOrder service;
        private readonly IRoll serviceR;
        private TCdbContext context = new TCdbContext();

        public OrderController()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BD"]) == true)
            {
                service = new OrderServiceBD();
                serviceR = new RollServiceBD();
            }
            else
            {
                service = new OrdereServiceFile();
                serviceR = new RollServiceBD();

            }
        }

        [HttpGet]
        public ActionResult Orders()
        {
            return View(service.GetList());
        }



        [HttpGet]
        public ActionResult Add_in_Order()

        {

            SelectList elem = new SelectList(context.Rolls, "Id", "Name");
            ViewBag.Rolls = elem;
            elem = new SelectList(context.Drinks, "Id", "Name");
            ViewBag.Drinks = elem;
            elem = new SelectList(context.Salads, "Id", "Name");
            ViewBag.Salads = elem;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add_in_Order(Roll roll, Drink drink, Salad salad)
        {
            serviceR.AddElement(roll);
            serviceR.AddElement(drink);
            serviceR.AddElement(salad);
            return RedirectToAction("Orders");
        }

        public ActionResult DeleteOrder(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Orders");
        }
    }
    }