using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTransportCompany.Models
{
    
    public class OrderSushi : BaseModel
    {
        public int OrderId_sushi { get; set; }

        public int SushiId { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Sushi Sushi { get; set; }
    }
}