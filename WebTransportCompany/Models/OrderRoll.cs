using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTransportCompany.Models
{
    public class OrderRoll : BaseModel
    {
        public int? OrderId_roll { get; set; }

        public int? RollId { get; set; }

        public int? Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Roll Roll { get; set; }
    }
}