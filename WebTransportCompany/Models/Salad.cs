using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    public class Salad : BaseModel
    {
        [DataMember]
        public decimal Price { get; set; }

        [ForeignKey("SaladId")]
        public virtual List<OrderSalad> order_salad { get; set; }
    }
}