using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTransportCompany.Models
{
    public class OrderSalad : BaseModel
    {
        public int OrderId_salad { get; set; }

        public int SaladId { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Salad Salad { get; set; }
    }
}