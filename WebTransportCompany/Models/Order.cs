using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    [DataContract]
    public class Order : BaseModel
    {
        [DataMember]
        public DateTime? CreateDate { get; set; }
        [DataMember]
        public decimal? Summa { get; set; }

        public virtual Client Client { get; set; }
        public int? ClientId { set; get; }

        // public virtual List<Roll> roll { get; set; }
        [DataMember]
        [ForeignKey("Order_Id")]
        public virtual List<Roll> Rolls { get; set; }

        [ForeignKey("OrderId_drink")]
        public virtual List<OrderDrink> order_drink { get; set; }

        /*[ForeignKey("OrderId_roll")]
        public virtual List<OrderRoll> order_roll { get; set; } */

        [ForeignKey("OrderId_salad")]
        public virtual List<OrderSalad> order_salad { get; set; }
    }
}