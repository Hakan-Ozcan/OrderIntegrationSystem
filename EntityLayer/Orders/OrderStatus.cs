using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Orders
{
    public class OrderStatus
    {
        [Key]
        public int StatusID { get; set; }
        public bool SiparisAlindi{ get; set; }
        public bool YolaCikti { get; set; }
        public bool DagitimMerkezinde { get; set; }
        public bool DagitimaCikti { get; set; }
        public bool TeslimEdildi { get; set; }
        public bool TeslimEdilemedi { get; set; }
    }
}
