using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    public class Sushi : BaseModel
    {

        [DataMember]
        public decimal Price { get; set; }

        [ForeignKey("SushiId")]
        public virtual List<OrderSushi> order_sushi { get; set; }
    }
}