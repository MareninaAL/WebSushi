using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTransportCompany.Models
{
    public class OrderDrink : BaseModel 
    {
        public int OrderId_drink { get; set; }

        public int DrinkId { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Drink Drink { get; set; }
    }
}