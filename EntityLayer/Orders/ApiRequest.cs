using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Orders
{
    public class ApiRequest
    {
        public int MüsteriSiparisNo { get; set; }
        public bool Statu { get; set; }
        public DateTime DegisimTarihi { get; set; }
    }
}
