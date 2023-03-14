using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Orders
{
    public class OrderData
    {
        [Key]
        public int SiparisID { get; set; }
        public int MusteriSiparisNo { get; set; }
        public string CikisAdresi { get; set; }
        public string VarisAdresi { get; set; }
        public int Miktar { get; set; }
        public MiktarBirim MiktarBirim { get; set; }
        public int Agirlik { get; set; }
        public AgirlikBirim AgirlikBirim { get; set; }
        public int MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
        public string Not { get; set; }

    }
}
