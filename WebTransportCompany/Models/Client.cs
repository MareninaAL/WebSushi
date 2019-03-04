using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTransportCompany.Models
{
    [DataContract]
    public class Client : BaseModel
    {

        [DataMember]
        [Required]
        public string Phone { get; set; }

        [DataMember]
        [Required]
        public string Login { get; set; }

        [DataMember]
        [Required]
        public string Password { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Order> order { get; set; }
    }
}