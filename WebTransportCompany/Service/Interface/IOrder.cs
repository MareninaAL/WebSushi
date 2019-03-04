using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTransportCompany.Models;

namespace WebTransportCompany.Service.Interface
{
    public interface IOrder : IMain
    {
        void AddRoll(Roll Roll);
        Roll GetRoll(string Name, int OrderId);
    }
}
