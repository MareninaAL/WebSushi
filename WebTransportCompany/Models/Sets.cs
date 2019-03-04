using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    public class Sets : BaseModel
    {

        [DataMember]
        public decimal Price { get; set; }

        [ForeignKey("SetsId")]
        public virtual List<OrderSets> order_sets { get; set; }
    }
}