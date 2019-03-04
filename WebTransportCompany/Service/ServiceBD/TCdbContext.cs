using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTransportCompany.Models;

namespace WebTransportCompany.Service.ServiceBD
{
    public class TCdbContext: DbContext
    {
        public TCdbContext() : base("TransCompany")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public static TCdbContext Create()
        {
            return new TCdbContext();
        }

        public virtual DbSet<Client> Clients { get; set; }

        /* public virtual DbSet<OrderDrink> orderDrinks { get; set; }
         public virtual DbSet<OrderRoll> order{ get; set; }
         public virtual DbSet<OrderSalad> orderSalads { get; set; } */
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Drink> Drinks { get; set; }

        public virtual DbSet<Roll> Rolls { get; set; }

        public virtual DbSet<Salad> Salads { get; set; }

        public virtual DbSet<Sushi> Sushis { get; set; }

        public virtual DbSet<Sets> Sets { get; set; }

    }
}