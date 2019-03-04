using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTransportCompany.Models
{
    public class OrderSets : BaseModel
    {
        public int OrderId_sets { get; set; }

        public int SetsId { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Sets Sets { get; set; }
    }
}