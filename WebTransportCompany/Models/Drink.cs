using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    public class Drink : BaseModel
    {
        
        [DataMember]
        public decimal Price { get; set; }

        [ForeignKey("DrinkId")]
        public virtual List<OrderDrink> order_drink { get; set; }
    }
}