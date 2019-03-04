using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    public class Roll : BaseModel
    {

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int Order_Id { get; set; }
        public virtual Order Order { get; set; }


        [ForeignKey("RollId")]
        public virtual List<OrderRoll> order_roll { get; set; }
    }
}