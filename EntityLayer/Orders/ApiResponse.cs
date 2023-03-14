using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Orders
{
    public class ApiResponse
    {
        public int MusteriSiparisNo { get; set; }
        public int SistemSiparisNo { get; set; }
        public bool Statu { get; set; }
        public string HataAciklama { get; set; }
    }
}
