using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Orders
{
    public class MaterialInformation
    {
        [Key]
        public int MalzemeID { get; set; }
        public int MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
    }
}
